using BankingSystem.Application;
using BankingSystem.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();


var app = builder.Build();

app.UseHttpsRedirection();

app.UseSwagger();   
app.UseSwaggerUI();

app.MapControllers();


app.Run();
