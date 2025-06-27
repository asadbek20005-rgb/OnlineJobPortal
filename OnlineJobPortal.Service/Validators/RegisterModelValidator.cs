using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnlineJobPortal.Common.Models.User;
using OnlineJobPortal.Data.Contracts;
using OnlineJobPortal.Data.Entities;

namespace OnlineJobPortal.Service.Validators;

public class RegisterModelValidator : AbstractValidator<RegisterModel>
{
    public RegisterModelValidator(IBaseRepository<Role> roleRepository, IBaseRepository<Vacancy> vacancyRepository)
    {


        RuleFor(x => x.Password)
            .Must(x => x.Any(char.IsUpper)).WithMessage("Password must have 1 upper letter")
            .Must(x => x.Any(char.IsDigit)).WithMessage("Password must have 1 digit")
            .Must(x => x.Any(char.IsLower)).WithMessage("Password must have 1 lower letter");


        RuleFor(x => x.RoleId)
            .MustAsync(async (roleId, cancel) =>
            {   
                bool roleExist = await (await roleRepository.GetAllAsync()).AnyAsync(x => x.Id == roleId);
                return roleExist;
            }).WithMessage("Invalid Role Id");
    }


}
