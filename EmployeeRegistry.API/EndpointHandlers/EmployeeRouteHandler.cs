using EmployeeRegistry.Contracts.Requests;
using EmployeeRegistry.Contracts.Responses;
using EmployeeRegistry.Domain.CommandHandlers;
using EmployeeRegistry.Domain.Commands;
using EmployeeRegistry.Domain.QueryHandlers;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EmployeeRegistry.EndpointHandlers;

public class EmployeeRouteHandler(
    CreateEmployeeCommandHandler createEmployeeCommandHandler,
    DeleteEmployeeCommandHandler deleteEmployeeCommandHandler,
    EmployeesQueryHandler employeesQueryHandler)
{
    public async Task<Results<Ok<PagedResult<EmployeeDto>>, BadRequest<string>>> Get()
    {
        try
        {
            var data = await employeesQueryHandler.Handle();
            var result = new PagedResult<EmployeeDto>(data);
            return TypedResults.Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return TypedResults.BadRequest(e.Message);
        }
    }

    public async Task<Results<Ok<Guid>, BadRequest<string>>> Post(CreateEmployeeRequest request)
    {
        try
        {
            var command = new CreateEmployeeCommand(request.Email, request.FirstName, request.LastName);
            var id = await createEmployeeCommandHandler.Handle(command);
            return TypedResults.Ok(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return TypedResults.BadRequest(e.Message);
        }
    }

    public async Task<Results<NoContent, BadRequest<string>>> Delete(Guid id)
    {
        try
        {
            var command = new DeleteEmployeeCommand(id);
            await deleteEmployeeCommandHandler.Handle(command);
            return TypedResults.NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return TypedResults.BadRequest(e.Message);
        }
    }
}