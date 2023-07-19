using Microsoft.EntityFrameworkCore;
using VetClinic.DAL;
using VetClinic.DAL.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MainBase")));

builder.Services.AddDefaultIdentity<BaseAccount>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AppDatabaseContext>();

builder.Services.AddIdentityCore<Customer>().AddEntityFrameworkStores<AppDatabaseContext>();
builder.Services.AddIdentityCore<Doctor>().AddEntityFrameworkStores<AppDatabaseContext>();

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
