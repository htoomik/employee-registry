using EmployeeRegistry.Contracts;
using EmployeeRegistry.EndpointHandlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var handler = new EmployeeHandler();

app.MapGet("/employees", () => handler.Get())
    .WithName("GetEmployees")
    .WithOpenApi();

app.MapPost("/employees", (CreateEmployeeRequest request) => handler.Post(request))
    .WithName("CreateEmployee")
    .WithOpenApi();

app.MapDelete("/employees", (Guid id) => handler.Delete(id))
    .WithName("DeleteEmployee")
    .WithOpenApi();

app.Run();