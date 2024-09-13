using System.Collections.Concurrent;
using EmployeeRegistry.Domain.Commands;

namespace EmployeeRegistry.Domain;

public class EmployeeStore : IEmployeeStore
{
    private static readonly ConcurrentDictionary<Guid, Employee> Employees = new();

    public List<Employee> GetAll()
    {
        return Employees.Values.ToList();
    }

    public Guid Add(CreateEmployeeCommand command)
    {
        // Let's pretend this was generated in the database
        var id = Guid.NewGuid();

        if (Employees.Values.Any(e => e.Email == command.Email))
        {
            throw new Exception($"Duplicate email address {command.Email}");
        }

        var employee = new Employee(id, command.Email, command.FirstName, command.LastName);

        var success = Employees.TryAdd(id, employee);
        if (!success)
        {
            throw new Exception("Could not add employee");
        }

        return id;
    }

    public void Delete(Guid id)
    {
        if (!Employees.ContainsKey(id))
        {
            throw new Exception($"No employee with ID {id}");
        }

        var success = Employees.Remove(id, out _);
        if (!success)
        {
            throw new Exception("Could not delete employee");
        }
    }
}