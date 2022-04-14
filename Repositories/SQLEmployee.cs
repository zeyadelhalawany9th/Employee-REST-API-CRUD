using REST_API_CRUD.Models;

namespace REST_API_CRUD.Repositories
{
    public class SQLEmployee : IEmployee
    {
        private EmployeeContext employeeContext;

        public SQLEmployee(EmployeeContext employeeContext)
        {
            this.employeeContext = employeeContext;
        }



        public Employee addEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();

            employeeContext.Employees.Add(employee);

            employeeContext.SaveChanges();

            return employee;
        }

        public void deleteEmployee(Employee employee)
        {
            var employeeToBeDeleted = employeeContext.Employees.Find(employee.Id);

            if(employeeToBeDeleted != null)
            {
                employeeContext.Employees.Remove(employeeToBeDeleted);
                employeeContext.SaveChanges();
            }
        }

        public Employee editEmployee(Employee employee)
        {
            var employeeToBeEdited = employeeContext.Employees.Find(employee.Id);

            if (employeeToBeEdited != null)
            {
                employeeToBeEdited.Name = employee.Name;
                employeeContext.Employees.Update(employeeToBeEdited);
                employeeContext.SaveChanges();
        
            }

            return employee;

        }

        public List<Employee> getAllEmployees()
        {
            return employeeContext.Employees.ToList();
        }

        public Employee getEmployeeById(Guid id)
        {
            // return employeeContext.Employees.SingleOrDefault(x => x.Id == id);

            var employee = employeeContext.Employees.Find(id);
            return employee;
        }
    }
}
