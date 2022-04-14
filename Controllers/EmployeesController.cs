using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REST_API_CRUD.Models;
using REST_API_CRUD.Repositories;

namespace REST_API_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployee iemployee;

        public EmployeesController(IEmployee iemployee)
        {
            this.iemployee = iemployee;

        }

        [HttpGet]
        public IActionResult getAllEmployees()
        {
            return Ok(iemployee.getAllEmployees());

        }




        [HttpGet("{id}")]
        public IActionResult getEmployee(Guid id)
        {
            var employeeReturned = iemployee.getEmployeeById(id);

            if(employeeReturned != null)
            {
                return Ok(employeeReturned);
            }

            return NotFound($"The employee with the ID: {id} was not found");


        }


        [HttpPost]
        public IActionResult addEmployee(Employee employee)
        {
            iemployee.addEmployee(employee);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id, employee);

        }


        [HttpDelete("{id}")]
        public IActionResult deleteEmployee(Guid id)
        {
            var employeeToBeDeleted = iemployee.getEmployeeById(id);

            if (employeeToBeDeleted != null)
            {
                iemployee.deleteEmployee(employeeToBeDeleted);
                return Ok();
            }

            return NotFound($"The employee with the ID: {id} was not found");

        }


        [HttpPatch("{id}")]
        public IActionResult editEmployee(Guid id, Employee employee)
        {
            var employeeToBeEdited = iemployee.getEmployeeById(id);

            if (employeeToBeEdited != null)
            {
                employee.Id = employeeToBeEdited.Id;

                iemployee.editEmployee(employee);

                return Ok(employee);

            }

            return NotFound($"The employee with the ID: {id} was not found");


        }
    }
}
