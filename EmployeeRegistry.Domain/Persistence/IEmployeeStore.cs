using EmployeeRegistry.Domain.Entities;

namespace EmployeeRegistry.Domain.Persistence;

public interface IEmployeeStore
{
    List<Employee> GetAll();
    void Add(Employee employee);
    void Delete(Guid id);
}