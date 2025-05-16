using FluentValidation;
using OnlineJobPortal.Common.Models.Skill;
using OnlineJobPortal.Data.Contracts;
using OnlineJobPortal.Data.Entities;

namespace OnlineJobPortal.Service.Validators;

public class UpdateSkillValidator : AbstractValidator<UpdateSkillModel>
{
    public UpdateSkillValidator(IBaseRepository<Skill> skillReposiory, IBaseRepository<Level> levelRepository)
    {
        RuleFor(x => x.SkillId)
           .MustAsync(async (skillId, cancel) =>
           {
               Skill? skill = await skillReposiory.GetByIdAsync(skillId);
               if (skill is null)
               {
                   return false;
               }
               return true;
           }).When(x => x.SkillId.HasValue).WithMessage("No such skill");


        RuleFor(x => x.LevelId)
           .MustAsync(async (levelId, cancel) =>
           {
               Level? level = await levelRepository.GetByIdAsync(levelId);
               if (level is null)
                   return false;
               return true;
           }).When(x => x.LevelId.HasValue).WithMessage("No such level");
    }
}
