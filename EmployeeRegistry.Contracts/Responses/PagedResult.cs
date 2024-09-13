namespace EmployeeRegistry.Contracts;

public record PagedResult<T>(List<T> Data);