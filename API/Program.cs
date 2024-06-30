using API.Application.ErrorHandling;
using API.Application.ErrorHandling.Handlers.Interfaces;
using API.Application.ErrorHandling.Interfaces;
using API.Application.Filters;
using API.Auth;
using AutoMapper;
using BLL.Helpers.Automapper;
using BLL.Services.MainPage;
using BLL.Services.Tests.TestsService.BaseTestsService;
using BLL.Services.Users.Settings;
using DAL;
using DAL.Repositories.MainPage;
using DAL.Repositories.Tests;
using DAL.Repositories.Users;
using DAL.UnitsOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Shared.Models.Program;
using System.Reflection;

public class Program
{
    public static Settings Settings { get; private set; } = new Settings();

    public static async Task Main(string[] args)
    {
        Settings = await Settings.ReadFromFile("settings.json");

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
        builder.Services.AddDbContext<PlatformContext>();
        //builder.Services.AddScoped<ITestRepository, TestRepository>();
        //builder.Services.AddScoped<IMainPageRepository, MainPageRepository>();
        //builder.Services.AddScoped<IUserRepository, UserRepository>();

        builder.Services.AddScoped<IUnitOfWork, UnitOfWorkPlatform>();

        ConnectServices(builder);

        builder.Services.AddScoped<IObjectsProvider<IExceptionControllerHandler>, ErrorHandlersProvider>();

        builder.Services.AddAuthorization();
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = AuthOptions.ISSUER,
                    ValidAudience = AuthOptions.AUDIENCE,
                    IssuerSigningKey = AuthOptions.GetSecurityKey()
                };
            });

        builder.Services.AddSingleton(provider => new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AutomapperProfile());

            cfg.AllowNullCollections = true;
        }).CreateMapper());

        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Tester API",
                Description = "An ASP.NET Core Web API for managing Tests items",
            });

            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = @"Write authorization JWT token",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer",
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        builder.Services.AddControllers(config =>
        {
            config.Filters.Add<WebAPIExceptionFilterAttribute>();
        });
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();


        app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

        app.MapControllers();

        app.Run();

    }

    public static void ConnectServices(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IBaseTestService, BaseTestService>();
        builder.Services.AddScoped<IMainPageService, MainPageService>();
    }
}
