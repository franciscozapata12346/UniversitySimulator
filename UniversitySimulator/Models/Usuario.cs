using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversitySimulator.Models
{
    public class Usuario
    {

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Email { get; set; }
        public int Legajo { get; set; }
        public static int LegajoSeed { get; set; }

        public string DNI { get; set; }

        public string Password { get; set; }
    }
}
