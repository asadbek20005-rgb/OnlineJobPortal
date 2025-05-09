using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineJobPortal.Common.Models.Otp;
using OnlineJobPortal.Common.Models.User;
using OnlineJobPortal.Common.Statics;
using OnlineJobPortal.Data.Contracts;
using OnlineJobPortal.Data.Entities;
using OnlineJobPortal.Service.Contracts;
using StatusGeneric;
namespace OnlineJobPortal.Service.Services;

public class UserService(IBaseRepository<User> userRepository, IMapper mapper,
    IBaseRepository<City> cityRepository,
    IRedisService redisService,
    IOtpService otpService) : StatusGenericHandler, IUserService
{
    private readonly IBaseRepository<User> _userRepository = userRepository;
    private readonly IBaseRepository<City> _cityRepository = cityRepository;
    private readonly IRedisService _redisService = redisService;
    private readonly IOtpService _otpService = otpService;
    private readonly IMapper _mapper = mapper;

    public async Task<int?> RegisterAsync(RegisterModel model)
    {
        if (await UserIsExistInDb(model.PhoneNumber) || await UserIsExistInCache(model.PhoneNumber))
        {
            AddError($"User already exist");
            return null;
        }

      
        var newUser = _mapper.Map<User>(model);
        newUser.PasswordHash = HashPassword(newUser, model.Password);
        newUser.RoleId = 1;

        await _redisService.SetItemAsync(StaticData.UserRedisKey, newUser);
        int code = await _otpService.GenerateCodeToPhoneNumberAsync(model.PhoneNumber);
        return code;
    }



    public async Task VerifyRegisterAsync(OtpModel model)
    {

        await _otpService.VerifyAsync(model);
        User? user = await _redisService.GetItemAsync<User>(StaticData.UserRedisKey);

        if (user is null)
        {
            AddError("Verification is failed, please register");
            return;
        }

        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();
    }


    public async Task<int?> LoginAysnc(LoginModel model)
    {
        User? user = await (await _userRepository.GetAllAsync())
            .Where(u => u.PhoneNumber == model.PhoneNumber)
            .FirstOrDefaultAsync();
        if (user is null)
        {
            AddError("Invalid phone number");
            return null;
        }

        bool verificationPasswordResult = VerifyPassword(user, model.Password);
        if (verificationPasswordResult is false)
        {
            AddError("Invalid password");
        }

        await _redisService.SetItemAsync(StaticData.UserRedisKey, user);
        int code = await _otpService.GenerateCodeToPhoneNumberAsync(model.PhoneNumber);
        return code;
    }


    public async Task<string> VerifyLoginAsync(OtpModel model)
    {
        await _otpService.VerifyAsync(model);

        User? user = await _redisService.GetItemAsync<User>(StaticData.UserRedisKey);

        if (user is null)
        {
            AddError("Verification is failed, please login");
        }

        return "token";

    }






    #region privateMethods
    private async Task<bool> UserIsExistInDb(string phoneNumber)
    {
        bool isUserExist = await (await _userRepository.GetAllAsync())
            .AnyAsync(user => user.PhoneNumber == phoneNumber);


        return isUserExist;
    }

    private bool VerifyPassword(User user, string password)
    {
        PasswordVerificationResult result = new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, password);
        if (result is PasswordVerificationResult.Failed)
            return false;
        if (result is PasswordVerificationResult.Success)
            return true;
        return false;
    }

    private async Task<bool> UserIsExistInCache(string phoneNumber)
    {
        User? user = await _redisService.GetItemAsync<User>(StaticData.UserRedisKey);
        if (user is not null && user.PhoneNumber == phoneNumber)
            return true;
        return false;
    }

    private string HashPassword(User user, string password)
    {
        var hashedPassword = new PasswordHasher<User>().HashPassword(user, password);
        return hashedPassword;
    }

    private async Task<City?> GetCityByIdAsync(int cityId)
    {
        City? city = await _cityRepository.GetByIdAsync(cityId);
        if (city is null)
        {
            return null;
        }
        return city;
    }


    #endregion


}
