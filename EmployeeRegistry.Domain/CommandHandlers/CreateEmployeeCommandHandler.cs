using EmployeeRegistry.Domain.Commands;
using EmployeeRegistry.Domain.CommandValidators;
using EmployeeRegistry.Domain.Entities;
using EmployeeRegistry.Domain.Persistence;

namespace EmployeeRegistry.Domain.CommandHandlers;

public class CreateEmployeeCommandHandler(IEmployeeStore store)
{
    public async Task<Guid> Handle(CreateEmployeeCommand command)
    {
        if (!CreateEmployeeCommandValidator.Validate(command, out var errorMessage))
        {
            throw new Exception(errorMessage);
        }

        var exists = store.GetAll().Any(e => e.Email == command.Email);
        if (exists)
        {
            throw new Exception($"Duplicate email address {command.Email}");
        }

        // Let's pretend this was generated in the database
        var id = Guid.NewGuid();
        var employee = new Employee(id, command.Email, command.FirstName, command.LastName);
        store.Add(employee);

        return id;
    }
}