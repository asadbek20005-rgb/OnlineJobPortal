using OnlineJobPortal.Common.Models.Resume;

namespace OnlineJobPortal.Service.Contracts;

public interface IResumeService
{
    Task Create(CreateResumeModel model);
}
