

using estimacion_proyecto.core.Core;
using estimacion_proyecto.data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog;
using System.Text;

var logger = NLog.LogManager.Setup().LoadConfigurationFromFile().GetCurrentClassLogger();
logger.Error("Inicio la ejecución");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();

    // Logger File
    builder.Logging.ClearProviders();
    // builder.Host.UseNLog();

    var connectionString = builder.Configuration.GetConnectionString("sstDb");
    builder.Services.AddDbContext<ProyectoDbContext>(options => options.UseSqlServer(connectionString));

    builder.Services.AddTransient<IUsuarioCore, UsuarioCore>();
    builder.Services.AddTransient<IUsuarioDatos, UsuarioDatos>();

    builder.Services.AddTransient<IProyectoCore, ProyectoCore>();
    builder.Services.AddTransient<IProyectoDatos, ProyectoDatos>();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // Add CORS support
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("MyAllowAllHeadersPolicy", policy =>
        {
            policy.WithOrigins("*")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
    });

    builder.Services.AddControllers();


    //Auth
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
    {

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
        };
    });

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddSwaggerGen(c =>
    {
        //c.EnableAnnotations();
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Estimacion de Proyectos - Servicios",
            Version = "v.1.0.10",
            Description = "Web Api",
            TermsOfService = new Uri("https://www.itsense.com.co"),
            Contact = new OpenApiContact
            {
                Name = "Contáctanos - Website",
                Url = new Uri("https://www.itsense.com.co")
            },
            License = new OpenApiLicense
            {
                Name = "Licencia",
                Url = new Uri("https://www.itsense.com.co")
            }
        });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter a valid token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "Bearer"
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type=ReferenceType.SecurityScheme,
                        Id="Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });


    });

    var services = builder.Services;

    var app = builder.Build();

    app.UseCors("MyAllowAllHeadersPolicy");

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

   

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{

	throw;
}

