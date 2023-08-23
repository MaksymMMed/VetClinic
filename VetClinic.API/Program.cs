using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using VetClinic.BLL.Configs;
using VetClinic.BLL.Services.Interfaces;
using VetClinic.BLL.Services.Realizations;
using VetClinic.BLL.TokenFactory;
using VetClinic.DAL;
using VetClinic.DAL.Entities;
using VetClinic.DAL.Repository.Interfaces;
using VetClinic.DAL.Repository.Realizations;
using VetClinic.DAL.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Sql Server 
builder.Services.AddDbContext<AppDatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MainBase")));

// Identity
builder.Services.AddDefaultIdentity<BaseAccount>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AppDatabaseContext>();

builder.Services.AddIdentityCore<Customer>().AddEntityFrameworkStores<AppDatabaseContext>();
builder.Services.AddIdentityCore<Doctor>().AddEntityFrameworkStores<AppDatabaseContext>();

// Mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Services and repos
builder.Services.AddTransient<IAnimalRepository, AnimalRepository>();
builder.Services.AddTransient<IAppointmentRepository, AppointmentRepository>();

builder.Services.AddTransient<IAnimalService, AnimalService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IAppointmentService, AppointmentService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddSingleton<JwtTokenConfiguration>();
builder.Services.AddSingleton<IJwtTokenFactory,JwtTokenFactory>();

//Jwt Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {

            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
        };
    }
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TeamworkSystem.WebAPI",
        Version = "v1"
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme.
                                    Enter 'Bearer' [space] and then your token in the
                                    text input below. Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
               {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
});

// Authorization

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("HighLevel", policy =>
    {
        policy.RequireClaim("UserType", "Doctor");
    });
    options.AddPolicy("LowLevel", policy =>
    {
        policy.RequireClaim("UserType","Customer","Doctor");
    });
});

// Ignore reference cycles
builder.Services.AddControllers()
    .AddNewtonsoftJson(o =>
    {
        o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });


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

app.MapControllers();

app.Run();
