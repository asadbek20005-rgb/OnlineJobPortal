using OnlineJobPortal.Common.Dtos;
using OnlineJobPortal.Common.Models.Vacancy;
using OnlineJobPortal.Common.Results;
using OnlineJobPortal.Data.Entities;
using OnlineJobPortal.Service.Contracts;

namespace OnlineJobPortal.Api.MinimalApies;

public static class VacancyEndpoints
{
    public static void CreateVacancy(this WebApplication app)
    {
        app.MapPost("/api/Employers/{employerId:guid}/Vacancies", async
            (Guid employerId, IVacancyService service, CreateVacancyModel model) =>
        {
            await service.CreateAsync(employerId, model);
            if (service.IsValid)
            {
                return Result<Vacancy>.SuccessResult(null);
            }
            var errors = service.GetAllErrors();
            return Result<Vacancy>.Failure(errors);
        })
            .WithTags("Vacancies");
    }


    public static void GetAll(this WebApplication app)
    {
        app.MapGet("/api/Vacancies", async (IVacancyService service) =>
        {
            var vacancies = await service.GetAll();
            if (service.IsValid)
            {
                return Result<List<VacancyDto>>.SuccessResult(vacancies);
            }

            var errors = service.GetAllErrors();
            return Result<List<VacancyDto>>.Failure(errors);
        }).WithTags("Vacancies");
    }

    public static void GetVacancyFilter(this WebApplication app)
    {
        app.MapGet("/api/Vacancies/filter", async (IVacancyService service, [AsParameters] VacancyFilterModel model) =>
        {
            var vacancyDtos = await service.GetAllVacanciesBy(model);
            if (service.IsValid)
            {
                return Result<List<VacancyDto>>.SuccessResult(vacancyDtos);
            }
            var errors = service.GetAllErrors();
            return Result<List<VacancyDto>>.Failure(errors);
        }).WithTags("Vacancies"); ;
    }

}