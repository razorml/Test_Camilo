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

        /// <summary>
        /// Realiza el llamado al listado de los empleados registrados
        /// </summary>
        /// <returns>IList</returns>
        [HttpGet]
        public ActionResult<IList<Employees>> GetEmployees()
        {            
            var result = employee.GetEmployees();
            return new ObjectResult(new { result }) { StatusCode = 200 };
        }
        /// <summary>
        /// realiza el llamado a un registro de un empleado por codigo
        /// </summary>
        /// <param name="id">Codigo del empleado</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<IList<Employees>> GetEmployee([FromRoute] int id)
        {
            var result = employee.GetEmployee(id);
            return new ObjectResult(new { result }) { StatusCode = 200 };
        }

        /// <summary>
        /// Realiza el llamado a la creacion del empleado
        /// </summary>
        /// <param name="employees">datos del empleado</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<IList<Employees>> CreateEmployee([FromBody] Employees employees)
        {
            var result = employee.CreateEmployee(employees);
            return new ObjectResult(new { result }) { StatusCode = 200 };
        }

        /// <summary>
        /// Realiza el llamado para la acutalizcion de empleados
        /// 
        /// </summary>
        /// <param name="employees"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<IList<Employees>> UpdateEmployee([FromBody] Employees employees)
        {
            var result = employee.UpdateEmployee(employees);
            return new ObjectResult(new { result }) { StatusCode = 200 };
        }

        /// <summary>
        /// Realiza el llamada a la eliminacion un empleado por codigo
        /// </summary>
        /// <param name="id">Codigo del empleado</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult<IList<Employees>> DeleteEmployee([FromRoute] int id)
        {
            var result = employee.DeleteEmployee(id);
            return new ObjectResult(new { result }) { StatusCode = 200 };
        }
    }
}
