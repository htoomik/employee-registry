using EmployeeRegistry.Contracts;
using EmployeeRegistry.Domain;
using EmployeeRegistry.Domain.Commands;

namespace EmployeeRegistry.EndpointHandlers;

public class EmployeeHandler(IEmployeeStore store)
{
    public async Task<PagedResult<EmployeeDto>> Get()
    {
        var data = store
            .GetAll()
            .Select(MapToEmployeeDto)
            .ToList();
        var result = new PagedResult<EmployeeDto>(data);
        return result;
    }

    public async Task<Guid> Post(CreateEmployeeRequest request)
    {
        var command = new CreateEmployeeCommand(request.Email, request.FirstName, request.LastName);
        var id = store.Add(command);
        return id;
    }

    public async Task Delete(Guid id)
    {
        store.Delete(id);
    }

    private static EmployeeDto MapToEmployeeDto(Employee e)
    {
        return new EmployeeDto(e.Id, e.Email, e.FirstName, e.LastName);
    }
}