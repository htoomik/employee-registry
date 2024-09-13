using System.Collections.Concurrent;
using EmployeeRegistry.Domain.Entities;

namespace EmployeeRegistry.Domain.Persistence;

public class EmployeeStore : IEmployeeStore
{
    private static readonly ConcurrentDictionary<Guid, Employee> Employees = new();

    public List<Employee> GetAll()
    {
        return Employees.Values.ToList();
    }

    public void Add(Employee employee)
    {
        var success = Employees.TryAdd(employee.Id, employee);
        if (!success)
        {
            throw new Exception("Could not add employee");
        }
    }

    public void Delete(Guid id)
    {
        var success = Employees.Remove(id, out _);
        if (!success)
        {
            throw new Exception("Could not delete employee");
        }
    }
}