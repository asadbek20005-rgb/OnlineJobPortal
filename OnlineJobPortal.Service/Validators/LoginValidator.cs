using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnlineJobPortal.Common.Models.User;
using OnlineJobPortal.Data.Contracts;
using OnlineJobPortal.Data.Entities;
using System.Data;

namespace OnlineJobPortal.Service.Validators;

public class LoginValidator : AbstractValidator<LoginModel>
{
    public LoginValidator(IBaseRepository<Role> _roleRepository)
    {
        RuleFor(x => x.RoleId)
            .NotEmpty()
            .NotNull()
            .MustAsync(async (roleId, cancel) =>
            {
                return await (await _roleRepository.GetAllAsync()).AnyAsync(x => x.Id == roleId);
            }).WithMessage("Invalid Role Id");

    }
}
