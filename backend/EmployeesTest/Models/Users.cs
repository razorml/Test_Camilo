namespace EmployeesTest.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    public class Users
    {
        /// <summary>
        /// Codigo del empleado
        /// </summary>
        [Key]
        public int UserId { get; set; }
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
