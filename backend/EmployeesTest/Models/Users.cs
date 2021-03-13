namespace EmployeesTest.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Users
    {
        /// <summary>
        /// Codigo del empleado
        /// </summary>
        [Key]
        public int EmployeeId { get; set; }
        /// <summary>
        /// Nombre de usuario
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Contraseña
        /// </summary>
        public string Password { get; set; }
    }
}
