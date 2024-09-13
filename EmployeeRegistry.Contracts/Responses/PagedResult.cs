namespace EmployeeRegistry.Contracts.Responses;

public record PagedResult<T>(List<T> Data);