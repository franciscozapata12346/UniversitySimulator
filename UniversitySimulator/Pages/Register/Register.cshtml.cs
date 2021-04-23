using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversitySimulator.Services;
using UniversitySimulator.Data;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web;
using System.Collections;
using UniversitySimulator.Models;
using UniversitySimulator.Pages.Register;

namespace UniversitySimulator.Pages
{
    public class RegisterModel : PageModel
    {

        public UsuarioService usuarioService { get; set; }
        [BindProperty]
        [Required]
        public string NombreUsuario { get; set; }
        [BindProperty]
        [Required]
        public string ApellidoUsuario { get; set; }
        [BindProperty]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailUsuario { get; set; }
        [BindProperty]
        [Required]
        public string DNIUsuario { get; set; }
        [BindProperty]
        [Required]
        public string PasswordUsuario { get; set; }
        [BindProperty]
        public bool flag { get; set; }

        public RegisterModel()
        {
            
        }

        public void OnGet()
        {
            //
        }

        public IActionResult OnPost()
        {
            usuarioService = new UsuarioService();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (usuarioService.CreateUser(NombreUsuario, ApellidoUsuario, DNIUsuario, PasswordUsuario, EmailUsuario))
            {
                ViewData["flag"] = true;


            }
            MostrarDatosModel mostrarDatos = new MostrarDatosModel();
            mostrarDatos.CargarForm(NombreUsuario, ApellidoUsuario, DNIUsuario, PasswordUsuario, EmailUsuario);
            return Redirect("MostrarDatos");
        }


    }
}



