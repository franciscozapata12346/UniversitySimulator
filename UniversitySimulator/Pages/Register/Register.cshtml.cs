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
        [BindProperty]
        public string ErrorServidor { get; set; }


        public RegisterModel()
        {
            
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            usuarioService = new UsuarioService();
            Usuario usuario = new Usuario();
            
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (usuarioService.ValidateUser(DNIUsuario, EmailUsuario)) 
            {
                usuario.Legajo = Usuario.LegajoSeed++;
                if (usuarioService.CreateUser(NombreUsuario, ApellidoUsuario, DNIUsuario, PasswordUsuario,
                EmailUsuario, usuario.Legajo))
                {
                    ViewData["flag"] = true;
                    usuario.Nombre = NombreUsuario;
                    usuario.Apellido = ApellidoUsuario;
                    usuario.DNI = DNIUsuario;
                    usuario.Email = EmailUsuario;


                    return RedirectToPage("MostrarDatos", usuario);
                }
                else
                {
                    Usuario.LegajoSeed--;
                    ViewData["flag"] = false;
                    return Page();
                }
            }
            else
            {
                ErrorServidor = "Ya existe un usuario con este DNI o Email";
                return Page();
            }


            
            
        }


    }
}



