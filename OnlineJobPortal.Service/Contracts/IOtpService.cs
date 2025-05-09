using OnlineJobPortal.Common.Models.Otp;
using StatusGeneric;

namespace OnlineJobPortal.Service.Contracts;

public interface IOtpService 
{
    Task<int> GenerateCodeToPhoneNumberAsync(string phoneNumber);
    Task VerifyAsync(OtpModel model);
}
