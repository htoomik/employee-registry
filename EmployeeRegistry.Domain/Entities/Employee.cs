namespace EmployeeRegistry.Domain.Entities;

public record Employee(Guid Id, string Email, string FirstName, string LastName);