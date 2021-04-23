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

        public void CargarForm(string Nombre, string Apellido, string DNI, string Email, string Legajo) 
        {
            ViewData["UserName"] = Nombre;
            ViewData["UserLastName"] = Apellido;
            ViewData["UserDni"] = DNI;
            ViewData["UserEmail"] = Email;
            ViewData["UserLegajo"] = Legajo;
        }
        public void OnGet()
        {
            
        }
    }
}
