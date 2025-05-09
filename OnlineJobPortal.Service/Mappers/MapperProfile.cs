using AutoMapper;
using OnlineJobPortal.Common.Models.Resume;
using OnlineJobPortal.Common.Models.User;
using OnlineJobPortal.Data.Entities;

namespace OnlineJobPortal.Service.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<RegisterModel, User>();
        CreateMap<CreateResumeModel, Resume>();
       
    }
}