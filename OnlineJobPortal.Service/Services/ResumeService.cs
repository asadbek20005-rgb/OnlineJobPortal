using AutoMapper;
using OnlineJobPortal.Common.Models.Resume;
using OnlineJobPortal.Data.Contracts;
using OnlineJobPortal.Data.Entities;
using OnlineJobPortal.Service.Contracts;

namespace OnlineJobPortal.Service.Services;

public class ResumeService(
    IBaseRepository<Resume> resumeRepostory,
    IMapper mapper) : IResumeService
{
    private readonly IBaseRepository<Resume> _resumeRepository = resumeRepostory;
    private readonly IMapper _mapper = mapper;
    public async Task Create(CreateResumeModel model)
    {


        Resume resume = _mapper.Map<Resume>(model);
        await _resumeRepository.AddAsync(resume);
        await _resumeRepository.UpdateAsync(resume);
    }
}
