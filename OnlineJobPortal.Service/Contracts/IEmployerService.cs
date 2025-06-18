using OnlineJobPortal.Common.Dtos;
using OnlineJobPortal.Common.Models.Otp;
using OnlineJobPortal.Common.Models.User;
using OnlineJobPortal.Common.Results;

namespace OnlineJobPortal.Service.Contracts;

public interface IEmployerService
{
    Task RegisterAsync();
    Task<int?> RegisterAsync(RegisterModel model);
    Task VerifyRegisterAsync(OtpModel model);
    Task<int?> LoginAysnc(LoginModel model);
    Task<string> VerifyLoginAsync(OtpModel model);
    Task<Result<UserDto>> GetProfileAsync(Guid userId);
    Task EditProfileAsync(Guid userId, UpdateUserBasicDetailModel model);
    Task EditPhoneNumberAsync(Guid userId, UpdatePhoneNumberModel model);
}
