using FluentValidation;
using OnlineJobPortal.Common.Models.Resume;
using OnlineJobPortal.Data.Contracts;
using OnlineJobPortal.Data.Entities;

namespace OnlineJobPortal.Service.Validators;

public class CreateResumeValidator : AbstractValidator<CreateResumeModel>
{
    public CreateResumeValidator(
        IBaseRepository<City> cityRepository,
        IBaseRepository<Status> statusRepository,
        IBaseRepository<Level> levelRepository,
        IBaseRepository<Skill> skillRepository,
        IBaseRepository<Profession> professionRepository,
        IBaseRepository<Currency> currencyRepository,
        IBaseRepository<WorkingHour> workingHourRepository,
        IBaseRepository<TypeOfEmployment> typeOfEmploymentRepository)
    {
        RuleFor(x => x.CreateUserBasicDetail).SetValidator(new CreateUserBasicDetailValidator(cityRepository, statusRepository));
        RuleFor(x => x.CreateEducationModel).SetValidator(new CreateEducationValidator(levelRepository));
        RuleFor(x => x.CreatSkillModel).SetValidator(new CreateSkillValidator(skillRepository, levelRepository));
        RuleFor(x => x.CreateWorkExperiance).SetValidator(new CreateWokrExperianceValidator());
        RuleFor(x => x.CreateContact).SetValidator(new CreateContactValidator());
        RuleFor(x => x.Specializations).MinimumLength(10).WithMessage("Specializations must be minimum 10 length");
        RuleFor(x => x.AboutMe).MinimumLength(10).WithMessage("AboutMe must be minimum 10 length");
        RuleFor(x => x.ProfessionId).MustAsync(async (professionId, cancel) =>
        {
            Profession? profession = await professionRepository.GetByIdAsync(professionId);
            if (profession is null) return false;
            return true;
        }).WithMessage("Nu such profession");
        RuleFor(x => x.CurrencyId).MustAsync(async (currencyId, cancel) =>
        {
            Currency? currency = await currencyRepository.GetByIdAsync(currencyId);
            if (currency is null) return false;
            return true;
        }).WithMessage("Nu such currency");
        RuleFor(x => x.WorkingHourId).MustAsync(async (workingHourId, cancel) =>
        {
            WorkingHour? workingHour = await workingHourRepository.GetByIdAsync(workingHourId);
            if (workingHour is null) return false;
            return true;
        }).WithMessage("No such working hour");
        RuleFor(x => x.TypeOfEmploymentId).MustAsync(async (typeOfEmploymentId, cancel) =>
        {
            TypeOfEmployment? typeOfEmployment = await typeOfEmploymentRepository.GetByIdAsync(typeOfEmploymentId);
            if (typeOfEmployment is null) return false;
            return true;
        }).WithMessage("No such type of employment");



    }
}