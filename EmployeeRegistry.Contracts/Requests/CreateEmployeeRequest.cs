namespace EmployeeRegistry.Contracts.Requests;

public record CreateEmployeeRequest(string Email, string FirstName, string LastName);