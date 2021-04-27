using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversitySimulator.Models;
using UniversitySimulator.Services;

namespace UniversitySimulator.Pages.Register
{
    public class MostrarDatosModel : PageModel
    {
        


        public MostrarDatosModel()
        {
            
        }

        public void OnGet(Usuario usuario)
        {
            ViewData["NombreUsuario"] = usuario.Nombre;
            ViewData["ApellidoUsuario"] = usuario.Apellido;
            ViewData["DNIUsuario"] = usuario.DNI;
            ViewData["EmailUsuario"] = usuario.Email;
            ViewData["LegajoUsuario"] = usuario.Legajo;
        }
        //public void OnGet()
        //{
            
        //}
    }
}
