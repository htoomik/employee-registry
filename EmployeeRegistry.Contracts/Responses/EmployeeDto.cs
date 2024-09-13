namespace EmployeeRegistry.Contracts.Responses;

public record EmployeeDto(Guid Id, string Email, string FirstName, string LastName);