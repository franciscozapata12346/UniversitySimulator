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

namespace UniversitySimulator.Pages
{
    public class RegisterModel : PageModel
    {

        public UsuarioService usuarioService { get; set; }
        [Required]
        public string NombreUsuario { get; set; }
        [Required]
        public string ApellidoUsuario { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailUsuario { get; set; }
        [Required]
        public string DNIUsuario { get; set; }
        [Required]
        public string PasswordUsuario { get; set; }
        [BindProperty]
        public bool flag { get; set; }

        public RegisterModel()
        {
            usuarioService = new UsuarioService();
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (usuarioService.CreateUser(NombreUsuario, ApellidoUsuario, EmailUsuario, DNIUsuario, PasswordUsuario))
            {
                flag = true;
            }



            return Redirect("MostrarDatos");
        }

            
    }
}



