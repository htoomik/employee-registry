namespace EmployeeRegistry.Domain.Commands;

public record CreateEmployeeCommand(string Email, string FirstName, string LastName);