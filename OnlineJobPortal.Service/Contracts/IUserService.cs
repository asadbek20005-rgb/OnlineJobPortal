using OnlineJobPortal.Common.Models.Otp;
using OnlineJobPortal.Common.Models.User;
using StatusGeneric;

namespace OnlineJobPortal.Service.Contracts;

public interface IUserService : IStatusGeneric
{
    Task<int?> RegisterAsync(RegisterModel model);
    Task VerifyRegisterAsync(OtpModel model);
    Task<int?> LoginAysnc(LoginModel model);
    Task<string> VerifyLoginAsync(OtpModel model);
}
