using Microsoft.EntityFrameworkCore;
using OnlineJobPortal.Data.Bases;
using OnlineJobPortal.Data.Entities;
using System.Security.Cryptography.X509Certificates;

namespace OnlineJobPortal.Data.Contexts;

public class OnlineJobPortalDbContext : DbContext
{
    public OnlineJobPortalDbContext(DbContextOptions<OnlineJobPortalDbContext> contextOptions) :base(contextOptions)
    {

    }


    public DbSet<City> Cities { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Level> Levels { get; set; }
    public DbSet<Profession> Professions { get; set; }
    public DbSet<Resume> Resumes { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<TypeOfEmployment> TypeOfEmployments { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Vacancy> Vacancies { get; set; }
    public DbSet<WorkExperience> WorkExperiences { get; set; }
    public DbSet<WorkingHour> WorkingHours { get; set; }
    public DbSet<Otp> Otps { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(Date).IsAssignableFrom(entityType.ClrType) && entityType.ClrType != typeof(Date))
            {
                modelBuilder.Entity(entityType.ClrType)
                    .Property(nameof(Date.CreatedDate))
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            }
        }
    }


}
