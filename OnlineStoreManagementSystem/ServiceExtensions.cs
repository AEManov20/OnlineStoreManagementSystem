using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.EntityFrameworkCore;
using OnlineStoreManagementSystem.Data;
using OnlineStoreManagementSystem.Repositories;

namespace OnlineStoreManagementSystem;

public static class ServiceExtensions
{
    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddRepositories();
        builder.Services.AddControllers(opt =>
            opt.ModelMetadataDetailsProviders.Add(new SystemTextJsonValidationMetadataProvider()))
            .AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                // opt.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
            });
    }
    
    public static void AddAutoMapper(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper();
    }

    public static void AddDbContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ApplicationDbContext>(opt =>
        {
            opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")!);

            if (builder.Environment.IsDevelopment())
                opt.EnableSensitiveDataLogging();

            opt.EnableThreadSafetyChecks();
            opt.EnableDetailedErrors();
        });
        builder.Services.AddScoped<DbContext, ApplicationDbContext>();
    }
    
    public static void AddLogging(this WebApplicationBuilder builder)
    {
        builder.Services.AddLogging(config => config.AddConsole());
    }
    
    public static void AddSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(opt =>
        {
            // opt.AddSecurityRequirement(new OpenApiSecurityRequirement()
            // {
            //     {
            //         new OpenApiSecurityScheme
            //         {
            //             Reference = new OpenApiReference
            //             {
            //                 Type = ReferenceType.SecurityScheme,
            //                 Id = "Bearer",
            //             },
            //             Scheme = "oauth2",
            //             Name = "Bearer",
            //             In = ParameterLocation.Header,
            //         },
            //         new List<string>()
            //     },
            // });

            // opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            // {
            //     Name = "Authorization",
            //     In = ParameterLocation.Header,
            //     Type = SecuritySchemeType.ApiKey,
            //     Scheme = "Bearer",
            // });
        });
    }
}