using Application.Validators.Products;
using FluentValidation.AspNetCore;
using Infrastructure.Services;
using Infrastructure;
using Persistence;
using Infrastructure.Filters;
using Infrastructure.Services.Storage.Local;
using Infrastructure.Enums;
using Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddPersistenceServices();

builder.Services.AddApplicationServices();

builder.Services.AddInfrastructureServices();

builder.Services.AddStorage<LocalStorage>();

// Bu þekilde de kullanýlabilir
//builder.Services.AddStorage<StorageType.Local>();

// verilen linkdeki bütün headerlara, tüm methodlara izin ver
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod()));

// fluent validation'ý tanýtmak için configuration yapýldý
builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>()).AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>()).ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);
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

app.UseStaticFiles();

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
