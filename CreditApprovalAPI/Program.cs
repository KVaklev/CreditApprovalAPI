using CreditApprovalAPI.Data;
using CreditApprovalAPI.Mapping;
using CreditApprovalAPI.Repositories;
using CreditApprovalAPI.Repository;
using CreditApprovalAPI.Services;
using CreditApprovalAPI.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Get the XML comments file path
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    // Tell Swagger to use the XML comments
    c.IncludeXmlComments(xmlPath);
});

// Add DbContext with In-Memory DB
builder.Services.AddDbContext<CreditDbContext>(options =>
    options.UseInMemoryDatabase("CreditDb"));

// Configure JSON serialization to convert enum values to their string representations
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Register MediatR
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreditRequestCreateValidator>();

// Register Services and Repositories
builder.Services.AddScoped<ICreditRequestRepository, CreditRequestRepository>();
builder.Services.AddScoped<ICreditRequestService, CreditRequestService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
