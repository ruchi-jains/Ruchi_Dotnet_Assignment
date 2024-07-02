using Ruchi_Employee_management_system.Interface;
using Ruchi_Employee_management_system.Service;
using Ruchi_Employee_management_system.CosmosDB;
using Ruchi_Employee_management_system.Common;
using Ruchi_Employee_management_system.ServiceFilters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ICosmosDBService, CosmosDBService>();
builder.Services.AddAutoMapper(typeof(AutomapperProfile));
builder.Services.AddScoped<EmployeeFilter>();
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
