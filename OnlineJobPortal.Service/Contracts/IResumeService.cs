using OnlineJobPortal.Common.Dtos;
using OnlineJobPortal.Common.Models.Resume;
using StatusGeneric;

namespace OnlineJobPortal.Service.Contracts;

public interface IResumeService : IStatusGeneric
{
    Task CreateAsync(Guid userId, CreateResumeModel model);
    Task DeletePerminanlyAsync(Guid userId, int resumeId);
    Task HideAsync(Guid userId, int resumeId);
    Task<List<ResumeDto>> GetAllResumesAsync();
    Task<List<ResumeDto>> GetAllUserResumes(Guid userId);
    Task<ResumeDto?> GetUserResumeByIdAsync(Guid userId, int resumeId);
    Task EditAsync(Guid userId, int resumeId, UpdateResumeModel model); 
}
