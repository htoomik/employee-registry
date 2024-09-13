using EmployeeRegistry.Contracts;

namespace EmployeeRegistry.EndpointHandlers;

public class EmployeeHandler
{
    public async Task<PagedResult<EmployeeDto>> Get()
    {
        var data = new List<EmployeeDto> { new(Guid.NewGuid(), "email", "First", "Last") };
        var result = new PagedResult<EmployeeDto>(data);
        return result;
    }

    public async Task<EmployeeDto> Post(CreateEmployeeRequest request)
    {
        return new EmployeeDto(Guid.NewGuid(), request.Email, request.FirstName, request.LastName);
    }

    public async Task Delete(Guid id)
    {
    }
}