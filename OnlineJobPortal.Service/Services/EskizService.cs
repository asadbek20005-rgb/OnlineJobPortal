using Newtonsoft.Json.Linq;
using OnlineJobPortal.Common.Models.Eskiz;
using OnlineJobPortal.Service.Contracts;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace OnlineJobPortal.Service.Services;

public class EskizService(HttpClient httpClient) : IEskizService
{
    private readonly string _email = "muhammadjonmakhkamboev@gmail.com";
    private readonly string _password = "t2vinMrOZ8SYmfa3khRHgXQLNVVlmq5zly79oIMo";
    private string? _token;
    public async Task<Tuple<bool, string>> SendSmsAsync(string phoneNumber, string code)
    {
        if (string.IsNullOrEmpty(_token))
        {
            await AuthenticateAsync();
        }
        string message = $"Verification code is: {code}. Do not share this code with anyone. The code will expire in 2 minutes.";
        var requestData = new { mobile_phone = phoneNumber, message, from = "4546" };
        var content = new StringContent(JsonSerializer.Serialize(requestData), Encoding.UTF8, "application/json");
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
        var response = await httpClient.PostAsync("https://notify.eskiz.uz/api/message/sms/send", content);
        var responseString = await response.Content.ReadAsStringAsync();
        return new(true, "Success");
    }

    private async Task AuthenticateAsync()
    {
        var requestData = new { email = _email, password = _password };
        var content = new StringContent(JsonSerializer.Serialize(requestData), Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync("https://notify.eskiz.uz/api/auth/login", content);
        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();
        var responseJson = JsonSerializer.Deserialize<EskizAuthResponse>(responseString);
        _token = responseJson?.Data.Token;
    }
}
