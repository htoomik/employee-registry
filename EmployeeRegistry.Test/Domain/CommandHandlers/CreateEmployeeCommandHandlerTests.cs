using EmployeeRegistry.Domain.CommandHandlers;
using EmployeeRegistry.Domain.Commands;
using EmployeeRegistry.Domain.Entities;
using EmployeeRegistry.Domain.Persistence;

namespace EmployeeRegistry.Test.Domain.CommandHandlers;

public class CreateEmployeeCommandHandlerTests
{
    // We could use a mock for IEmployeeStore, but the store is already a fake one, so there's no need.
    // But because it's a fake with a static data store, tests will collide if run in parallel.
    // Use distinct data in each test to prevent problems.

    [Fact]
    public async Task When_DuplicateEmailAddress_Should_Throw()
    {
        const string email = "exists@example.net";

        // Arrange
        var store = new EmployeeStore();
        store.Add(new Employee(Guid.NewGuid(), email, "first", "last"));

        var command = new CreateEmployeeCommand(email, "new first", "new last");
        var handler = new CreateEmployeeCommandHandler(store);

        // Act, Assert
        await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(command));
    }

    [Fact]
    public async Task When_DuplicateOtherData_Should_NotThrow()
    {
        // Arrange
        var store = new EmployeeStore();
        store.Add(new Employee(Guid.NewGuid(), "email@example.net", "first", "last"));

        var command = new CreateEmployeeCommand("other@example.net", "first", "last");
        var handler = new CreateEmployeeCommandHandler(store);

        // Act, Assert
        await handler.Handle(command);
    }

    [Fact]
    public async Task Should_AddEmployeeToStore()
    {
        const string email = "employee@example.net";
        const string firstName = "first";
        const string lastName = "last";

        // Arrange
        var store = new EmployeeStore();

        var command = new CreateEmployeeCommand(email, firstName, lastName);
        var handler = new CreateEmployeeCommandHandler(store);

        // Act
        var id = await handler.Handle(command);

        // Assert
        var employee = store.GetAll().SingleOrDefault(e => e.Id == id);
        Assert.NotNull(employee);
        Assert.Equal(email, employee.Email);
        Assert.Equal(firstName, employee.FirstName);
        Assert.Equal(lastName, employee.LastName);
    }
}