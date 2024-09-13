using EmployeeRegistry.Contracts;
using EmployeeRegistry.Domain;
using EmployeeRegistry.Domain.CommandHandlers;
using EmployeeRegistry.Domain.QueryHandlers;
using EmployeeRegistry.EndpointHandlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IEmployeeStore, EmployeeStore>();
builder.Services.AddTransient<EmployeeHandler>();
builder.Services.AddTransient<CreateEmployeeCommandHandler>();
builder.Services.AddTransient<DeleteEmployeeCommandHandler>();
builder.Services.AddTransient<EmployeesQueryHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var handler = app.Services.GetRequiredService<EmployeeHandler>();

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