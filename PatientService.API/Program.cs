using Microsoft.EntityFrameworkCore;
using PatientService.Application.Patients;
using PatientService.Application.Patients.Commands;
using PatientService.Application.Patients.Mapping;
using PatientService.Application.Patients.Queries;
using PatientService.Infrastructure.Persistence;
using PatientService.Infrastructure.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(o =>
    o.UseNpgsql(builder.Configuration.GetConnectionString("db")));

builder.Services.AddScoped<IPatientRepository, PatientRepository>();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(typeof(PatientProfile).Assembly);
});

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<CreatePatientHandler>();
    cfg.RegisterServicesFromAssemblyContaining<DeletePatientHandler>();
    cfg.RegisterServicesFromAssemblyContaining<UpdatePatientHandler>();
    cfg.RegisterServicesFromAssemblyContaining<SearchPatientsHandler>();
});


builder.Services.AddControllers()
    .AddJsonOptions(o => o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
