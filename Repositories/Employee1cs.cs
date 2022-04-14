using REST_API_CRUD.Models;

namespace REST_API_CRUD.Repositories
{
    public class Employee1 : IEmployee
    {
        private List<Employee> EmployeesList = new List<Employee>()
        {
            new Employee()
            {
                Id = Guid.NewGuid(),
                Name = "name1"
            },

            new Employee()
            {
                Id = Guid.NewGuid(),
                Name = "name2"
            }
        };

        public Employee addEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();   
            EmployeesList.Add(employee);

            return employee;
           
        }

        public void deleteEmployee(Employee employee)
        {
            EmployeesList.Remove(employee); 
        }

        public Employee editEmployee(Employee employee)
        {
            var employeeToBeEdited = getEmployeeById(employee.Id);  

            employeeToBeEdited.Name = employee.Name;

            return employeeToBeEdited;


        }

        public List<Employee> getAllEmployees()
        {
            return EmployeesList;
        }

        public Employee getEmployeeById(Guid id)
        {

            return EmployeesList.SingleOrDefault(x => x.Id == id);
        }
    }
}
