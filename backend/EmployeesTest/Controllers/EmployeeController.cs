using EmployeesTest.Context;
using EmployeesTest.Models;
using EmployeesTest.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        public EmployeeRepository employee { get; set; }

        public EmployeeController(AppDbContext context)
        {
            employee = new EmployeeRepository(context);
        }

        [HttpGet]
        public ActionResult<IList<Employee>> GetEmployees()
        {            
            var result = employee.GetEployees();
            return new ObjectResult(new { result }) { StatusCode = 200 };
        }
    }
}
