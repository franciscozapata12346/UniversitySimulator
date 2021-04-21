using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversitySimulator.Models
{
    public class Usuarios
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        public static int Legajo { get; set; }
        [Required]
        public string DNI { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
