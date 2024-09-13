namespace EmployeeRegistry.Domain;

public interface IEmployeeStore
{
    List<Employee> GetAll();
    void Add(Employee employee);
    void Delete(Guid id);
}