using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversitySimulator.Models;
using UniversitySimulator.Services;

namespace UniversitySimulator.Pages.Home
{
    public class PrincipalModel : PageModel
    {        
        public IActionResult OnGet(Usuario usuario)
        {
            //if (usuario.DNI == null) 
            //{
            //    return RedirectToPage("Index");
            //}

            return Page();
        }
    }
}
