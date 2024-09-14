using EmployeeRegistry.Domain.CommandHandlers;
using EmployeeRegistry.Domain.Commands;
using EmployeeRegistry.Domain.Entities;
using EmployeeRegistry.Domain.Persistence;

namespace EmployeeRegistry.Test.Domain.CommandHandlers;

public class DeleteEmployeeCommandHandlerTests
{
    [Fact]
    public async Task When_EmployeeExists_Should_Delete()
    {
        var employeeId = Guid.NewGuid();

        // Arrange
        var store = new EmployeeStore();
        store.Add(new Employee(employeeId, "exists@example.net", "first", "last"));

        var command = new DeleteEmployeeCommand(employeeId);
        var handler = new DeleteEmployeeCommandHandler(store);

        // Act
        await handler.Handle(command);

        // Assert
        Assert.Null(store.GetAll().SingleOrDefault(e => e.Id == employeeId));
    }

    [Fact]
    public async Task When_EmployeeDoesNotExist_Should_Throw()
    {
        var employeeId = Guid.NewGuid();

        // Arrange
        var store = new EmployeeStore();

        var command = new DeleteEmployeeCommand(employeeId);
        var handler = new DeleteEmployeeCommandHandler(store);

        // Act, Assert
        await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(command));
    }
}