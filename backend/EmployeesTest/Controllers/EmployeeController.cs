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
        public ActionResult<IList<Employees>> GetEmployees()
        {            
            var result = employee.GetEmployees();
            return new ObjectResult(new { result }) { StatusCode = 200 };
        }
        [HttpGet("{id}")]
        public ActionResult<IList<Employees>> GetEmployee([FromRoute] int id)
        {
            var result = employee.GetEmployee(id);
            return new ObjectResult(new { result }) { StatusCode = 200 };
        }
    }
}
