using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversitySimulator.Services;

namespace UniversitySimulator.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public UsuarioService usuarioService { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            usuarioService = new UsuarioService();
        }

        public void OnGet()
        {

        }
    }
}
