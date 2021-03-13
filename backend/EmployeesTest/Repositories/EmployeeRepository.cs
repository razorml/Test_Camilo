namespace EmployeesTest.Repositories
{
    using EmployeesTest.Context;
    using EmployeesTest.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

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
                    DocumentNum = result.Entity.DocumentNum,
                    LastName = result.Entity.LastName,
                    Name = result.Entity.Name,
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
            var result = this.dbContext.Employees.FirstOrDefault();
            Employees employeeResult = null;
            try
            {
                employeeResult = new Employees()
                {
                    //LastName = result.Entity.LastName,
                    //Name = result.Entity.Name,
                    //Position = result.Entity.Position
                };
                this.dbContext.SaveChanges();
            }
            catch 
            {

            }            
            return this.dbContext.Employees.FirstOrDefault();
        }

        /// <summary>
        /// Elimina un emleado
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
