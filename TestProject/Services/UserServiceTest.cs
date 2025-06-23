using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Moq;
using OnlineJobPortal.Common.Models.Otp;
using OnlineJobPortal.Common.Models.User;
using OnlineJobPortal.Data.Contracts;
using OnlineJobPortal.Data.Entities;
using OnlineJobPortal.Service.Contracts;
using OnlineJobPortal.Service.Services;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace TestProject.Services;

public class UserServiceTest
{
    private readonly Mock<IBaseRepository<User>> _mockUserRepository;
    private readonly IMock<IBaseRepository<City>> _mockCityRepository;
    private readonly IMock<IRedisService> _redisService;
    private readonly IMock<IOtpService> _otpService;
    private readonly IMock<IValidator<UpdateUserBasicDetailModel>> _updateUserBasicValidator;
    private readonly Mock<IValidator<RegisterModel>> _registerModelValidator;
    private readonly IMock<IValidator<OtpModel>> _otpModelValidator;
    private readonly Mock<IBaseRepository<Role>> _roleRepository;

    private readonly Mock<IMapper> _mapper;
    private readonly UserService _userService;
    public UserServiceTest()
    {
        _roleRepository = new Mock<IBaseRepository<Role>>();
        _mockUserRepository = new Mock<IBaseRepository<User>>();
        _mockCityRepository = new Mock<IBaseRepository<City>>();
        _redisService = new Mock<IRedisService>();
        _otpService = new Mock<IOtpService>();
        _updateUserBasicValidator = new Mock<IValidator<UpdateUserBasicDetailModel>>();
        _registerModelValidator = new Mock<IValidator<RegisterModel>>();
        _otpModelValidator = new Mock<IValidator<OtpModel>>();
        _mapper = new Mock<IMapper>();

        _userService = new UserService(
            _mockUserRepository.Object,
            _mockCityRepository.Object,
            _roleRepository.Object,
            _redisService.Object,
            _otpService.Object,
            _updateUserBasicValidator.Object,
            _registerModelValidator.Object,
            _otpModelValidator.Object,
            _mapper.Object);
    }



    [Fact]
    public async Task RegisterAsync_ShouldReturnNull_WhenValidationResultIsInvalid()
    {
        // Arrange

        var model = new RegisterModel
        {
            PhoneNumber = "123",
        };

        var validatonResult = new ValidationResult()
        {
            Errors = new List<ValidationFailure>()
               {
                   new ValidationFailure("PhoneNumber", "Invalid PhoneNumber")
               }
        };

        _registerModelValidator
            .Setup(x => x.ValidateAsync(model, default))
            .ReturnsAsync(validatonResult);

        // Act
        var result = await _userService.RegisterAsync(model);

        // Assert

        Assert.Null(result);
    }


    [Fact]

    public async Task RegisterAsync_ShouldReturnNull_WhenUserAlreadyExistInDatabase()
    {
        var model = new RegisterModel
        {
            PhoneNumber = "+998945631282",
        };

        var db = new List<User>
        {
            new User {PhoneNumber= "+998945631282"}
        }.AsQueryable();

        _registerModelValidator.Setup(x => x.ValidateAsync(model, default))
            .ReturnsAsync(new ValidationResult());

        _mockUserRepository.Setup(x => x.GetAllAsync())
             .ReturnsAsync(db);


        var result = await _userService.RegisterAsync(model);


        Assert.Null(result);
    }


    [Fact]
    public async Task RegisterAsync_ThrowException_WhenRoleIdNotFound()
    {
        var model = new RegisterModel
        {
            PhoneNumber = "+998945631282",
            RoleId = 2,
            Password = "dsadadsmdmfe"
        };

        var newUser = new User
        {
            PasswordHash = "ddddddddddddddddddddddd"
        };

        var db = new List<Role>
        {
            new Role {Id= 1,}
        }.AsQueryable();

        _mapper
            .Setup(x => x.Map<User>(model))
            .Returns(newUser);


        _registerModelValidator.Setup(x => x.ValidateAsync(model, default))
         .ReturnsAsync(new ValidationResult());

        //_mockUserRepository.Setup(x => x.GetAllAsync())
        //     .ReturnsAsync(db);


        _roleRepository
            .Setup(x => x.GetAllAsync())
            .ReturnsAsync(db);


        var result = await _userService.RegisterAsync(model);

        await Assert.ThrowsAsync<Exception>(() => _userService.RegisterAsync(model));
    }
}