using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Tokens.Constants;

namespace Proyecto_Tokens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var listEmployee = EmployeeConstans.Employees;
            return Ok(listEmployee);
        }
    }
}
