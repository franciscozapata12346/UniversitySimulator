using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversitySimulator.Services;
using UniversitySimulator.Data;

namespace UniversitySimulator.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public UsuarioService usuarioService { get; set; }

        public RegisterModel(ApplicationDbContext _context) 
        {
        
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid){
                return Page();
            }
            usuarioService.CreateUser();

            return Redirect("MostrarDatos");
        }
    }
}
