using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [Route("api/[controller]")]
        public IActionResult getAllEmployees()
        {
            return Ok(iemployee.getAllEmoloyees());

        }
    }
}
