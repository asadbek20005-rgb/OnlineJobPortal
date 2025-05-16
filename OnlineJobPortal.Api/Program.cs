using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using OnlineJobPortal.Api.CustomMiddlewares;
using OnlineJobPortal.Api.CustomMiddlewares.Extensions;
using OnlineJobPortal.Data.Contexts;
using OnlineJobPortal.Data.Contracts;
using OnlineJobPortal.Data.Repositories;
using OnlineJobPortal.Service.Contracts;
using OnlineJobPortal.Service.Mappers;
using OnlineJobPortal.Service.Services;
using OnlineJobPortal.Service.Validators;
using Serilog;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRedisService, RedisService>();
builder.Services.AddScoped<IOtpService, OtpService>();
builder.Services.AddScoped<IResumeService, ResumeService>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateResumeValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateSkillValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateContactValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateEducationValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateUserBasicDetailValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateWokrExperianceValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateResumeValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateSkillValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateContactValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateEducationValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateUserBasicDetailValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateWorkExperianceValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<RegisterModelValidator>();

builder.Services.AddDbContext<OnlineJobPortalDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddSingleton<IConnectionMultiplexer>
    (ConnectionMultiplexer
    .Connect("localhost:6379,abortConnect=false,connectTimeout=20000,syncTimeout=20000,defaultDatabase=0"));

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Host.UseSerilog();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {

    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandlerMiddleware();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
