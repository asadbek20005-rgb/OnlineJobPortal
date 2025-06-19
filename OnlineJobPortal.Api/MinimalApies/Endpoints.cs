namespace OnlineJobPortal.Api.MinimalApies;

public static class Endpoints
{
    public static void EndPoints(this WebApplication app)
    {
        app.CreateVacancy();
        app.GetAll();
        app.GetVacancyFilter();
    }
}
