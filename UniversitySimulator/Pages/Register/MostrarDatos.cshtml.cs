using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversitySimulator.Models;

namespace UniversitySimulator.Pages.Register
{
    public class MostrarDatosModel : PageModel
    {
        public void OnGet(Usuarios usuarios)
        {
            ViewData["UserName"] = usuarios.Nombre;
            ViewData["UserLastName"] = usuarios.Apellido;
            ViewData["UserDni"] = usuarios.DNI;
            ViewData["UserEmail"] = usuarios.Email;
            ViewData["UserLegajo"] = Usuarios.Legajo;
        }
    }
}
