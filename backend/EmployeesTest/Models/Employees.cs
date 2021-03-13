namespace EmployeesTest.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Employees
    {
        /// <summary>
        /// Codigo del empleado
        /// </summary>
        [Key]
        public int EmployeeId { get; set; }
        /// <summary>
        /// Nombre
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Apellido
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Numero de documento
        /// </summary>
        public string DocumentNum { get; set; }
        /// <summary>
        /// Cargo
        /// </summary>
        public string Position { get; set; }

    }
}
