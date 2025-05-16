using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnlineJobPortal.Common.Dtos;
using OnlineJobPortal.Common.Models.Resume;
using OnlineJobPortal.Data.Contracts;
using OnlineJobPortal.Data.Entities;
using OnlineJobPortal.Service.Contracts;
using StatusGeneric;

namespace OnlineJobPortal.Service.Services;

public class ResumeService(
    IBaseRepository<Resume> resumeRepostory,
    IMapper mapper,
    IValidator<CreateResumeModel> validator,
    IBaseRepository<Contact> contactRepository,
    IBaseRepository<Education> educationRepository,
    IBaseRepository<WorkExperience> workExperianceRepository,
    IBaseRepository<User> userRepository,
    IValidator<UpdateResumeModel> updateValidator) : StatusGenericHandler, IResumeService
{
    private readonly IBaseRepository<Resume> _resumeRepository = resumeRepostory;
    private readonly IMapper _mapper = mapper;
    private readonly IValidator<CreateResumeModel> _validator = validator;
    private readonly IValidator<UpdateResumeModel> _updateValidator = updateValidator;
    private readonly IBaseRepository<Contact> _contactRepository = contactRepository;
    private readonly IBaseRepository<Education> _educationRepository = educationRepository;
    private readonly IBaseRepository<WorkExperience> _workExperianceRepository = workExperianceRepository;
    private readonly IBaseRepository<User> _userRepository = userRepository;
    public async Task CreateAsync(Guid userId, CreateResumeModel model)
    {
        var validationResult = await _validator.ValidateAsync(model);
        if (!validationResult.IsValid)
        {
            foreach (var err in validationResult.Errors)
            {
                AddError(err.ErrorMessage);
            }
            return;
        }

        using var transaction = await _resumeRepository.BeginTransactionAsync();
        try
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user is null)
            {
                AddError("No such user");
                return;
            }

            User mappedUser = _mapper.Map(model.CreateUserBasicDetail, user);
            await _userRepository.SaveChangesAsync();

            WorkExperience workExperience = _mapper.Map<WorkExperience>(model.CreateWorkExperiance);
            await _workExperianceRepository.AddAsync(workExperience);
            await _workExperianceRepository.SaveChangesAsync();


            Contact contact = _mapper.Map<Contact>(model.CreateContact);
            await _contactRepository.AddAsync(contact);
            await _contactRepository.SaveChangesAsync();

            Education education = _mapper.Map<Education>(model.CreateEducationModel);
            await _educationRepository.AddAsync(education);
            await _educationRepository.SaveChangesAsync();

            Resume resume = _mapper.Map<Resume>(model);
            resume.ContactId = contact.Id;
            resume.EducationId = education.Id;
            resume.SkillId = model.CreatSkillModel.SkillId;
            resume.WorkExperianceId = workExperience.Id;
            resume.UserId = mappedUser.id;
            await _resumeRepository.AddAsync(resume);
            await _resumeRepository.SaveChangesAsync();

            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw new Exception(ex.Message);
        }
    }

    public async Task DeletePerminanlyAsync(Guid userId, int resumeId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user is null)
        {
            AddError("No such user");
            return;
        }

        Resume? resume = await (await _resumeRepository.GetAllAsync())
            .Where(resume => resume.UserId == user.id)
            .FirstOrDefaultAsync();

        if (resume is null)
        {
            AddError($"Resume not found");
            return;
        }

        resume.IsDeleted = true;
        await _resumeRepository.SaveChangesAsync();

    }

    public async Task EditAsync(Guid userId, int resumeId, UpdateResumeModel model)
    {
        var validationResult = await _updateValidator.ValidateAsync(model);
        if (!validationResult.IsValid)
        {
            foreach (var error in validationResult.Errors)
            {
                AddError($"{error.ErrorMessage}");
            }
            return;
        }


        Resume? resume = await (await _resumeRepository.GetAllAsync())
            .Where(resume => resume.UserId == userId && resume.Id == resumeId)
            .FirstOrDefaultAsync();

        if (resume is null)
        {
            AddError("No such resume");
            return;
        }

        Resume updatedResume = _mapper.Map(model, resume);


        await _resumeRepository.UpdateAsync(updatedResume);
        await _userRepository.SaveChangesAsync();
    }

    public async Task<List<ResumeDto>> GetAllResumesAsync()
    {
        var resumes = await (await _resumeRepository.GetAllAsync())
            .Where(resume => resume.IsHided == false && resume.IsDeleted == false)
            .ToListAsync();

        return _mapper.Map<List<ResumeDto>>(resumes);
    }

    public async Task<List<ResumeDto>> GetAllUserResumes(Guid userId)
    {
        List<Resume> resumes = await (await _resumeRepository.GetAllAsync())
            .Where(resume => resume.UserId == userId)
            .ToListAsync();

        return _mapper.Map<List<ResumeDto>>(resumes);

    }

    public async Task<ResumeDto?> GetUserResumeByIdAsync(Guid userId, int resumeId)
    {
        Resume? resume = await (await _resumeRepository.GetAllAsync())
            .Where(resume => resume.UserId == userId && resume.Id == resumeId)
            .FirstOrDefaultAsync();

        if (resume is null)
        {
            AddError("Resume not found");
            return null;
        }

        return _mapper.Map<ResumeDto>(resume);
    }

    public async Task HideAsync(Guid userId, int resumeId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user is null)
        {
            AddError("No such user");
            return;
        }

        Resume? resume = await (await _resumeRepository.GetAllAsync())
            .Where(resume => resume.UserId == user.id)
            .FirstOrDefaultAsync();

        if (resume is null)
        {
            AddError($"Resume not found");
            return;
        }

        resume.IsHided = true;
        await _resumeRepository.SaveChangesAsync();
    }

}