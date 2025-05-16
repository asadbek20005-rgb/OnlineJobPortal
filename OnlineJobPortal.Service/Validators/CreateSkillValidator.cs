using FluentValidation;
using OnlineJobPortal.Common.Models.Skill;
using OnlineJobPortal.Data.Contracts;
using OnlineJobPortal.Data.Entities;

namespace OnlineJobPortal.Service.Validators;

public class CreateSkillValidator : AbstractValidator<CreatSkillModel>
{
    public CreateSkillValidator(IBaseRepository<Skill> skillReposiory, IBaseRepository<Level> levelRepository)
    {
        RuleFor(x => x.SkillId)
            .NotNull()
            .MustAsync(async (skillId, cancel) =>
            {
                Skill? skill = await skillReposiory.GetByIdAsync(skillId);
                if(skill is null)
                {
                    return false;
                }
                return true;
            }).WithMessage("No such skill");


        RuleFor(x => x.LevelId)
           .MustAsync(async (levelId, cancel) =>
           {
               Level? level = await levelRepository.GetByIdAsync(levelId);  
               if(level is null) 
                   return false;
               return true;
           }).WithMessage("No such level");

        
    }
}
