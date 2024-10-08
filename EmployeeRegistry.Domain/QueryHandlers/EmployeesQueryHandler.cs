using EmployeeRegistry.Contracts.Responses;
using EmployeeRegistry.Domain.Entities;
using EmployeeRegistry.Domain.Persistence;

namespace EmployeeRegistry.Domain.QueryHandlers;

public class EmployeesQueryHandler(IEmployeeStore store)
{
    public async Task<List<EmployeeDto>> Handle()
    {
        return store.GetAll().Select(MapToEmployeeDto).ToList();
    }

    private static EmployeeDto MapToEmployeeDto(Employee e)
    {
        return new EmployeeDto(e.Id, e.Email, e.FirstName, e.LastName);
    }
}