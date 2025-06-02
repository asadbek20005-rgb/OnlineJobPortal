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
                return Result<Vacancy>.Success(null);
            }
            var errors = service.GetAllErrors();
            return Result<Vacancy>.BadRequest(errors);
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
                return Result<List<VacancyDto>>.Success(vacancies);
            }

            var errors = service.GetAllErrors();
            return Result<List<VacancyDto>>.BadRequest(errors);
        }).WithTags("Vacancies");
    }
}
