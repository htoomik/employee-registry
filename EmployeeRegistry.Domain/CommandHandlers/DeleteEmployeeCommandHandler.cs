using EmployeeRegistry.Domain.Commands;
using EmployeeRegistry.Domain.Persistence;

namespace EmployeeRegistry.Domain.CommandHandlers;

public class DeleteEmployeeCommandHandler(IEmployeeStore store)
{
    public async Task Handle(DeleteEmployeeCommand command)
    {
        if (store.GetAll().All(e => e.Id != command.Id))
        {
            throw new Exception($"No employee with ID {command.Id}");
        }

        store.Delete(command.Id);
    }
}