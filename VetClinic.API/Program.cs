using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

app.UseAuthorization();

app.MapControllers();

app.Run();
