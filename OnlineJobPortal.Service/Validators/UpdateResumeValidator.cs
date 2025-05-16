using FluentValidation;
using OnlineJobPortal.Common.Models.Resume;
using OnlineJobPortal.Data.Contracts;
using OnlineJobPortal.Data.Entities;

namespace OnlineJobPortal.Service.Validators;

public class UpdateResumeValidator : AbstractValidator<UpdateResumeModel>
{
    public UpdateResumeValidator(IBaseRepository<City> cityRepository,
        IBaseRepository<Status> statusRepository,
        IBaseRepository<Level> levelRepository,
        IBaseRepository<Skill> skillRepository,
        IBaseRepository<Profession> professionRepository,
        IBaseRepository<Currency> currencyRepository,
        IBaseRepository<WorkingHour> workingHourRepository,
        IBaseRepository<TypeOfEmployment> typeOfEmploymentRepository)
    {


        //RuleFor(x => x.UserBasicDetail)
        //    .NotNull()
        //    .SetValidator(new UpdateUserBasicDetailValidator(cityRepository, statusRepository))
        //    .When(x => x.UserBasicDetail is not null);


        RuleFor(x => x.EducationModel).SetValidator(new UpdateEducationValidator(levelRepository));
        RuleFor(x => x.SkillModel).SetValidator(new UpdateSkillValidator(skillRepository, levelRepository));
        RuleFor(x => x.WorkExperianceModel).SetValidator(new UpdateWorkExperianceValidator());
        RuleFor(x => x.ContactModel).SetValidator(new UpdateContactValidator());
        RuleFor(x => x.Specializations).MinimumLength(10).When(model => !string.IsNullOrEmpty(model.Specializations)).WithMessage("Specializations must be minimum 10 length");
        RuleFor(x => x.AboutMe).MinimumLength(10).When(model => !string.IsNullOrEmpty(model.AboutMe)).WithMessage("AboutMe must be minimum 10 length");

        RuleFor(x => x.ProfessionId).MustAsync(async (professionId, cancel) =>
        {
            Profession? profession = await professionRepository.GetByIdAsync(professionId);
            if (profession is null) return false;
            return true;
        }).When(x => x.ProfessionId.HasValue).WithMessage("Nu such profession");

        RuleFor(x => x.CurrencyId).MustAsync(async (currencyId, cancel) =>
        {
            Currency? currency = await currencyRepository.GetByIdAsync(currencyId);
            if (currency is null) return false;
            return true;
        }).When(x => x.CurrencyId.HasValue).WithMessage("Nu such currency");

        RuleFor(x => x.WorkingHourId).MustAsync(async (workingHourId, cancel) =>
        {
            WorkingHour? workingHour = await workingHourRepository.GetByIdAsync(workingHourId);
            if (workingHour is null) return false;
            return true;
        }).When(x => x.WorkingHourId.HasValue).WithMessage("No such working hour");

        RuleFor(x => x.TypeOfEmploymentId).MustAsync(async (typeOfEmploymentId, cancel) =>
        {
            TypeOfEmployment? typeOfEmployment = await typeOfEmploymentRepository.GetByIdAsync(typeOfEmploymentId);
            if (typeOfEmployment is null) return false;
            return true;
        }).When(x => x.TypeOfEmploymentId.HasValue).WithMessage("No such type of employment");
    }
}
