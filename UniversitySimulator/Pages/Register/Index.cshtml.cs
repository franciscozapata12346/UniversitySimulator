using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversitySimulator.Services;
using UniversitySimulator.Models;
using System.ComponentModel.DataAnnotations;
using Renci.SshNet;

namespace UniversitySimulator.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        
        public UsuarioService usuarioService { get; set; }
        [BindProperty]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [BindProperty]
        [Required]
        public string Password { get; set; }
        [BindProperty]
        public string ErrorServidor { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            usuarioService = new UsuarioService();
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid) 
            {
                return Page();
            }
            Usuario usuario = usuarioService.ConsultarUsuario(Email, Password);
            if ( usuario.DNI != null) 
            {
                ViewData["pagina"] = "principal";
               return RedirectToPage("/Home/Principal", usuario);
            }
            else
            {
                ErrorServidor = "No se encontro un usuario en la base de datos";
                return Page();
            }
            
        }
    }
}
