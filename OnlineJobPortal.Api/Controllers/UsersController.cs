using Microsoft.AspNetCore.Mvc;
using OnlineJobPortal.Common.Dtos;
using OnlineJobPortal.Common.Models.Otp;
using OnlineJobPortal.Common.Models.User;
using OnlineJobPortal.Service.Contracts;
using OnlineJobPortal.Service.Extensions;

namespace OnlineJobPortal.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpPost("account/register")]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        int? code = await _userService.RegisterAsync(model);
        if (_userService.IsValid)
        {
            return Ok(code);
        }

        _userService.CopyToModelState(ModelState);
        return BadRequest(ModelState);
    }

    [HttpPost("account/verify-register")]
    public async Task<IActionResult> VerifyRegister(OtpModel model)
    {

        await _userService.VerifyRegisterAsync(model);
        if (_userService.IsValid)
        {
            return Ok("done");
        }
        _userService.CopyToModelState(ModelState);
        return BadRequest(ModelState);
    }

    [HttpPost("account/login")]
    public async Task<IActionResult> Login(LoginModel loginModel)
    {
        int? code = await _userService.LoginAysnc(loginModel);
        if (_userService.IsValid)
        {
            return Ok(code);
        }

        _userService.CopyToModelState(ModelState);
        return BadRequest(ModelState);
    }

    [HttpPost("account/verify-login")]
    public async Task<IActionResult> VerifyLogin(OtpModel model)
    {
        string token = await _userService.VerifyLoginAsync(model);
        if (_userService.IsValid)
        {
            return Ok(token);
        }

        _userService.CopyToModelState(ModelState);
        return BadRequest(ModelState);
    }

    [HttpGet("profile")]
    public async Task<IActionResult> GetProfile(Guid userId)
    {
        UserDto? user = await _userService.GetProfileAsync(userId);
        if (_userService.IsValid)
        {
            return Ok(user);
        }

        _userService.CopyToModelState(ModelState);
        return BadRequest(ModelState);
    }

    [HttpPut("profile")]
    public async Task<IActionResult> UpdateProfile(Guid userId, UpdateUserBasicDetailModel model)
    {
        await _userService.EditProfileAsync(userId, model);
        if (_userService.IsValid)
        {
            return Ok("Done");
        }

        _userService.CopyToModelState(ModelState);
        return BadRequest(ModelState);
    }
}