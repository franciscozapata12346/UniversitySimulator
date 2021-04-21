using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversitySimulator.Models;
using Microsoft.EntityFrameworkCore;

namespace UniversitySimulator.Data
{
    public class UsuarioData : ControllerBase
    {
        public ApplicationDbContext context { get; set; }

        public UsuarioData(ApplicationDbContext _context) 
        {
            context = _context;
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody] Usuarios usuario)
        {
            try
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
