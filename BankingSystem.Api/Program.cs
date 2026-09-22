using BankingSystem.Api.Exceptions;
using BankingSystem.Application;
using BankingSystem.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddProblemDetails();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();


var app = builder.Build();

app.UseExceptionHandler();


app.UseHttpsRedirection();

app.UseSwagger();   
app.UseSwaggerUI();

app.MapControllers();


app.Run();
