using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineJobPortal.Common.Dtos;
using OnlineJobPortal.Common.Models.Otp;
using OnlineJobPortal.Common.Models.User;
using OnlineJobPortal.Common.Results;
using OnlineJobPortal.Common.Statics;
using OnlineJobPortal.Data.Contracts;
using OnlineJobPortal.Data.Entities;
using OnlineJobPortal.Service.Contracts;
using StatusGeneric;

namespace OnlineJobPortal.Service.Services;

public class UserService(IBaseRepository<User> userRepository, IMapper mapper,
    IBaseRepository<City> cityRepository,
    IRedisService redisService,
    IOtpService otpService,
    IValidator<UpdateUserBasicDetailModel> validator,
    IValidator<RegisterModel> registerValidator,
    IValidator<OtpModel> otpValidator,
    IBaseRepository<Role> roleRepository) : StatusGenericHandler, IUserService
{
    private readonly IBaseRepository<User> _userRepository = userRepository;
    private readonly IBaseRepository<City> _cityRepository = cityRepository;
    private readonly IRedisService _redisService = redisService;
    private readonly IOtpService _otpService = otpService;
    private readonly IMapper _mapper = mapper;
    private readonly IValidator<UpdateUserBasicDetailModel> _validator = validator;
    private readonly IValidator<RegisterModel> _registerValidator = registerValidator;
    private readonly IValidator<OtpModel> _otpValidator = otpValidator;
    private readonly IBaseRepository<Role> _roleRepository = roleRepository;

    public async Task<int?> RegisterAsync(RegisterModel model)
    {
        var validationResult = await _registerValidator.ValidateAsync(model);
        if (!validationResult.IsValid)
        {
            foreach (var error in validationResult.Errors)
            {
                AddError($"Error: {error.ErrorMessage}");
            }
            return null;
        }

        if (await UserIsExistInDb(model.PhoneNumber) || await UserIsExistInCache(model.PhoneNumber))
        {
            AddError($"User already exist");
            return null;
        }


        var newUser = _mapper.Map<User>(model);
        newUser.PasswordHash = HashPassword(newUser, model.Password);
        newUser.RoleId = await GetRoleIdAsync(model.RoleId);

        await _redisService.SetItemAsync(StaticData.UserRedisKey, newUser);
        int code = await _otpService.GenerateCodeToPhoneNumberAsync(model.PhoneNumber);

        await _otpService.SendSMSAsync(model.PhoneNumber, $"Varification code: {code}");

        return code;
    }
    public async Task VerifyRegisterAsync(OtpModel model)
    {

        var validationResult = await _otpValidator.ValidateAsync(model);
        if (!validationResult.IsValid)
        {
            foreach (var error in validationResult.Errors)
            {
                AddError(error.ErrorMessage);
            }
            return;
        }


        await _otpService.VerifyAsync(model);
        User? user = await _redisService.GetItemAsync<User>(StaticData.UserRedisKey);

        if (user is null)
        {
            AddError("Verification is failed, please register");
            return;
        }

        user.RoleId = 1;
        user.StatusId = 1;
        user.LanguageId = 1;
        user.LevelId = 15;

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
    public async Task<Result<UserDto>> GetProfileAsync(Guid userId)
    {
        User? user = await (await _userRepository.GetAllAsync())
            .Where(user => user.id == userId)
            .FirstOrDefaultAsync();

        if (user is null)
        {
            return Result<UserDto>.BadRequest("User Not Found");
        }
        UserDto userDto = _mapper.Map<UserDto>(user);
        return Result<UserDto>.Success(userDto);
    }

    public async Task EditProfileAsync(Guid userId, UpdateUserBasicDetailModel model)
    {
        var validationResult = await _validator.ValidateAsync(model);
        if (!validationResult.IsValid)
        {
            foreach (var error in validationResult.Errors)
            {
                AddError($"Errors: {error}");
            }
            return;
        }

        User? user = await _userRepository.GetByIdAsync(userId);
        if (user is null)
        {
            AddError($"{nameof(user)} is null");
            return;
        }

        User updatedUser = _mapper.Map(model, user);
        await _userRepository.UpdateAsync(updatedUser);
        await _userRepository.SaveChangesAsync();
    }
    public async Task EditPhoneNumberAsync(Guid userId, UpdatePhoneNumberModel model)
    {
        User? user = await _userRepository.GetByIdAsync(userId);
        if (user is null)
        {
            AddError("User not found");
            return;
        }

        if (user.PhoneNumber == model.NewPhoneNumber)
        {
            AddError("Enter new phoneNumber");
            return;
        }

        bool varificationPasswordResult = VerifyPassword(user, model.CurrentPassword);
        if (varificationPasswordResult is false)
        {
            AddError("Enter current password");
            return;
        }

        bool phoneNumberIsUsed = await (await _userRepository.GetAllAsync())
            .AsNoTracking()
            .AnyAsync(x => x.PhoneNumber == model.NewPhoneNumber);

        if (phoneNumberIsUsed)
        {
            AddError("Enter another phone number");
            return;
        }

        user.PhoneNumber = model.NewPhoneNumber;

        await _userRepository.UpdateAsync(user);
        await _userRepository.SaveChangesAsync();
    }
    public Task GetAllUsers()
    {
        return _userRepository.GetAllAsync();
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


    private async Task<int> GetRoleIdAsync(int id)
    {
        int roleId = await (await _roleRepository.GetAllAsync())
            .Where(x => x.Id == id).Select(x => x.Id).FirstOrDefaultAsync();
        return roleId;
    }


    #endregion


}
