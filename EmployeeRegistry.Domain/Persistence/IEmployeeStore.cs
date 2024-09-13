using EmployeeRegistry.Domain.Commands;

namespace EmployeeRegistry.Domain;

public interface IEmployeeStore
{
    List<Employee> GetAll();
    Guid Add(CreateEmployeeCommand employee);
    void Delete(Guid id);
}