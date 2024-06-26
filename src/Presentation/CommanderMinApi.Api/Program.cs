using CommanderMinApi.Presentation;
using CommanderMinApi.Application;
using CommanderMinApi.Persistence;
using Carter;
using CommanderMinApi.Authentication;

var builder = WebApplication.CreateBuilder(args);

//Test
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCarter();

builder.Services.AddPresentationServices()
    .AddPersistenceServices(builder.Configuration)
    .AddApplicationServices()
    .AddAuthenticationServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment() && app.Environment.IsProduction())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// This class inherits the ICarterModule. Every class that uses this interface, will automatically be registered at 
// startup. app.MapCarter() in program.cs
//
app.MapCarter();

app.Run();