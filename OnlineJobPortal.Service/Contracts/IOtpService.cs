using OnlineJobPortal.Common.Models.Otp;

namespace OnlineJobPortal.Service.Contracts;

public interface IOtpService
{
    Task<int> GenerateCodeToPhoneNumberAsync(string phoneNumber);
    Task VerifyAsync(OtpModel model);
    Task<string> SendSMSAsync(string toPhoneNumber);
}
