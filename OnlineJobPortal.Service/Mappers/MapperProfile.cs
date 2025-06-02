using AutoMapper;
using OnlineJobPortal.Common.Dtos;
using OnlineJobPortal.Common.Models.Company;
using OnlineJobPortal.Common.Models.Contact;
using OnlineJobPortal.Common.Models.Education;
using OnlineJobPortal.Common.Models.Resume;
using OnlineJobPortal.Common.Models.Skill;
using OnlineJobPortal.Common.Models.User;
using OnlineJobPortal.Common.Models.Vacancy;
using OnlineJobPortal.Common.Models.WorkExperiance;
using OnlineJobPortal.Data.Entities;

namespace OnlineJobPortal.Service.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<RegisterModel, User>();
        CreateMap<CreateUserBasicDetailModel, User>();
        CreateMap<CreateWorkExperianceModel, WorkExperience>();
        CreateMap<CreateContactModel, Contact>();
        CreateMap<CreateEducationModel, Education>();
        CreateMap<CreatSkillModel, Skill>();
        CreateMap<CreateResumeModel, Resume>();
        CreateMap<Resume, ResumeDto>();
        CreateMap<User, UserDto>();
        CreateMap<Language, LanguageDto>();
        CreateMap<CreateCompanyModel, Company>();
        CreateMap<CreateVacancyModel, Vacancy>();
        CreateMap<Vacancy,VacancyDto>();



        CreateMap<UpdateResumeModel, Resume>()
           .ForMember(dest => dest.ProfessionId, opts => opts.Condition(src => src.ProfessionId != null))
           .ForMember(dest => dest.IncomeLevelPerMonth, opts => opts.Condition(src => src.IncomeLevelPerMonth != null))
           .ForMember(dest => dest.CurrencyId, opts => opts.Condition(src => src.CurrencyId != null))
           .ForMember(dest => dest.Specializations, opts => opts.Condition(src => src.Specializations != null))
           .ForMember(dest => dest.WorkingHourId, opts => opts.Condition(src => src.WorkingHourId != null))
           .ForMember(dest => dest.TypeOfEmploymentId, opts => opts.Condition(src => src.TypeOfEmploymentId != null))
           .ForMember(dest => dest.AboutMe, opts => opts.Condition(src => src.AboutMe != null))
           .ForMember(dest => dest.WorkExperiance, opts => opts.Condition(src => src.WorkExperianceModel != null))
           .ForMember(dest => dest.Education, opts => opts.Condition(src => src.EducationModel != null))
           .ForMember(dest => dest.SkillId, opts => opts.Condition(src => src.SkillModel != null))
           .ForMember(dest => dest.Contact, opts => opts.Condition(src => src.ContactModel != null));










        CreateMap<UpdateUserBasicDetailModel, User>()
            .ForMember(dest => dest.FullName, opts => opts.Condition(src => src.FullName != null))
            .ForMember(dest => dest.Email, opts => opts.Condition(src => src.Email != null))
            .ForMember(dest => dest.CityId, opts => opts.Condition(src => src.CityId != null))
            .ForMember(dest => dest.StatusId, opts => opts.Condition(src => src.StatusId != null))
            .ForMember(dest => dest.LanguageId, opts => opts.Condition(src => src.LanguageId != null))
            .ForMember(dest => dest.LevelId, opts => opts.Condition(src => src.LevelId != null));





        CreateMap<UpdateSkillModel, Skill>()
           .ForMember(dest => dest.Id, opts => opts.Condition(src => src.SkillId != null))
           .ForMember(dest => dest.LevelId, opts => opts.Condition(src => src.LevelId != null));



        CreateMap<UpdateEducationModel, Education>()
           .ForMember(dest => dest.Name, opts => opts.Condition(src => src.Name != null))
           .ForMember(dest => dest.Faculty, opts => opts.Condition(src => src.Faculty != null))
           .ForMember(dest => dest.GraduationYear, opts => opts.Condition(src => src.GraduationYear != null))
           .ForMember(dest => dest.LevelId, opts => opts.Condition(src => src.LevelId != null));



        CreateMap<UpdateContactModel, Contact>()
           .ForMember(dest => dest.PhoneNumber, opts => opts.Condition(src => src.PhoneNumber != null))
           .ForMember(dest => dest.Email, opts => opts.Condition(src => src.Email != null))
           .ForMember(dest => dest.Details, opts => opts.Condition(src => src.Details != null));


        CreateMap<UpdateWorkExperianceModel, WorkExperience>()
           .ForMember(dest => dest.CompanyName, opts => opts.Condition(src => src.CompanyName != null))
           .ForMember(dest => dest.Website, opts => opts.Condition(src => src.Website != null))
           .ForMember(dest => dest.Details, opts => opts.Condition(src => src.Details != null))
           .ForMember(dest => dest.JobTitle, opts => opts.Condition(src => src.JobTitle != null))
           .ForMember(dest => dest.GettingStarted, opts => opts.Condition(src => src.GettingStarted != null))
           .ForMember(dest => dest.Ending, opts => opts.Condition(src => src.Ending != null))
           .ForMember(dest => dest.Responsibilities, opts => opts.Condition(src => src.Responsibilities != null));




    }
}