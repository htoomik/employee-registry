using EmployeeRegistry.Contracts;
using EmployeeRegistry.Domain.CommandHandlers;
using EmployeeRegistry.Domain.Commands;
using EmployeeRegistry.Domain.QueryHandlers;

namespace EmployeeRegistry.EndpointHandlers;

public class EmployeeHandler(
    CreateEmployeeCommandHandler createEmployeeCommandHandler,
    DeleteEmployeeCommandHandler deleteEmployeeCommandHandler,
    EmployeesQueryHandler employeesQueryHandler)
{
    public async Task<PagedResult<EmployeeDto>> Get()
    {
        var data = await employeesQueryHandler.Handle();
        var result = new PagedResult<EmployeeDto>(data);
        return result;
    }

    public async Task<Guid> Post(CreateEmployeeRequest request)
    {
        var command = new CreateEmployeeCommand(request.Email, request.FirstName, request.LastName);
        var id = await createEmployeeCommandHandler.Handle(command);
        return id;
    }

    public async Task Delete(Guid id)
    {
        var command = new DeleteEmployeeCommand(id);
        await deleteEmployeeCommandHandler.Handle(command);
    }
}