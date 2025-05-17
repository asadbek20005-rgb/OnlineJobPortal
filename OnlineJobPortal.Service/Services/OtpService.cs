using Microsoft.EntityFrameworkCore;
using OnlineJobPortal.Common.Models.Otp;
using OnlineJobPortal.Common.Statics;
using OnlineJobPortal.Data.Contracts;
using OnlineJobPortal.Data.Entities;
using OnlineJobPortal.Service.Contracts;
using OnlineJobPortal.Service.Exceptions;
using System.Text;

namespace OnlineJobPortal.Service.Services;

public class OtpService(IRedisService redisService, IBaseRepository<Otp> otpRepository) : IOtpService
{
    private readonly IRedisService _redisService = redisService;
    private readonly IBaseRepository<Otp> _otpRepository = otpRepository;
    public async Task<int> GenerateCodeToPhoneNumberAsync(string phoneNumber)
    {
        int code = new Random().Next(1111, 9999);
        await _redisService.SetItemAsync(phoneNumber, code);
        return code;
    }

    public async Task SendSMSAsync(string toPhoneNumber, string message)
    {
        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(StaticData.BaseUrl);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(StaticData.ApiKey);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


            var json = $@"
            {{
                ""from"": ""{StaticData.Sender}"",
                ""messages"": [
                    {{
                        ""destinations"": [
                            {{
                                ""to"": ""{toPhoneNumber}""
                            }}
                        ],
                        ""text"": ""{message}""
                    }}
                ]
            }}";


            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/sms/2/text/advanced", content);
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Response: {responseContent}");
        }
    }

    public async Task VerifyAsync(OtpModel model)
    {
        if (await CodeIsExpired(model.Code))
        {
            throw new CodeIsExpiredException();
        }

        int code = await _redisService.GetItemAsync<int>(model.PhoneNumber);
        if (code is 0 || code != model.Code)
        {
            throw new InvalidPhoneNumberOrCode();
        }


        var newOtp = new Otp
        {
            PhoneNumber = model.PhoneNumber,
            Code = code,
            IsExpired = true,
            CreatedDate = DateTime.UtcNow
        };

        await _otpRepository.AddAsync(newOtp);
        await _otpRepository.SaveChangesAsync();

    }


    private async Task<bool> CodeIsExpired(int code)
    {
        bool isExpired = await (await _otpRepository
            .GetAllAsync())
            .Where(x => x.Code == code)
            .AnyAsync(x => x.IsExpired);
        return isExpired;
    }
}
