using REST_API_CRUD.Models;

namespace REST_API_CRUD.Repositories
{
    public interface IEmployee
    {
        List<Employee> getAllEmoloyees();

        Employee getEmployeeById(Guid id);

        Employee addEmployee(Employee employee);

        void deleteEmployee(Employee employee);

        Employee editEmployee(Employee employee);   


    }
}
