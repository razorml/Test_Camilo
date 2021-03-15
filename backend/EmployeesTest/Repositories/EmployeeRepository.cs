namespace EmployeesTest.Repositories
{
    using EmployeesTest.Context;
    using EmployeesTest.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    public class EmployeeRepository
    {
       
        private AppDbContext dbContext;
        public EmployeeRepository(AppDbContext context)
        {
            this.dbContext = context;
        }
        /// <summary>
        /// Obtiene una lista de empleados
        /// </summary>
        /// <returns>IList<Employee></returns>
        public IList<Employees> GetEmployees() 
        {
           return this.dbContext.Employees.ToList();
        }
        /// <summary>
        /// Obtine un solo empleado
        /// </summary>
        /// <param name="employeeId">Codigo del empleado</param>
        /// <returns>Employee</returns>
        public Employees GetEmployee(int employeeId) 
        {
           return this.dbContext.Employees.FirstOrDefault(x => x.EmployeeId.Equals(employeeId));
        }
        /// <summary>
        /// Crea el empleado
        /// </summary>
        /// <returns></returns>
        public Employees CreateEmployee(Employees employee) 
        {
            var result = this.dbContext.Employees.Add(employee);
            this.dbContext.SaveChanges();
            Employees employeeResult = null;
            try
            {
                employeeResult = new Employees()
                {
                    EmployeeId = result.Entity.EmployeeId,
                    Name = result.Entity.Name,
                    LastName = result.Entity.LastName,
                    DocumentNum = result.Entity.DocumentNum,
                    Position = result.Entity.Position
                };
            }
            catch
            {
                throw new Exception("Error Insertando el empleado");
            }            
            return employeeResult;
        }

        /// <summary>
        /// Actualiza un empleado
        /// </summary>
        /// <param name="employeeId">Codigo del empleado</param>
        /// <returns>IList</returns>
        public Employees UpdateEmployee(Employees employee)
        {
            var result = this.dbContext.Employees.Where(x => x.EmployeeId.Equals(employee.EmployeeId));
            foreach (Employees item in result)
            {
                item.Name = employee.Name;
                item.LastName = employee.LastName;
                item.Position = employee.Position;
            }
            this.dbContext.SaveChanges();
            return this.dbContext.Employees.FirstOrDefault(x => x.EmployeeId.Equals(employee.EmployeeId));
        }

        /// <summary>
        /// Elimina un empleado
        /// </summary>
        /// <param name="employeeId">Codigo del empleado</param>
        /// <returns>IList</returns>
        public IList<Employees>DeleteEmployee(int employeeId)
        {
            var employeeRemove = this.dbContext.Employees.SingleOrDefault(x => x.EmployeeId == employeeId);
            if (employeeRemove != null) 
            {
                this.dbContext.Employees.Remove(employeeRemove);
                this.dbContext.SaveChanges();
            }
            return this.dbContext.Employees.ToList();
        }

    }
}
