using OnlineJobPortal.Common.Dtos;
using OnlineJobPortal.Common.Models.Vacancy;
using StatusGeneric;

namespace OnlineJobPortal.Service.Contracts;

public interface IVacancyService : IStatusGeneric
{
    Task CreateAsync(Guid employerId, CreateVacancyModel model);
    Task<List<VacancyDto>?> GetAllVacanciesBy(VacancyFilterModel model);
    Task<List<VacancyDto>> GetAll();
    Task UpdateAsync(int vacancyId, UpdateVacancyModel model);
    Task DeleteAsync(int vacancyId);
    Task AddToFavourites(int vacancyId);
    Task Reply();
}