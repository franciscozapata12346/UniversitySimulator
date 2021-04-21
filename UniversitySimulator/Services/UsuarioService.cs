using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversitySimulator.Models;
using UniversitySimulator.Data;

namespace UniversitySimulator.Services
{
    public class UsuarioService
    {
        public Usuarios usuario { get; set; }
        public UsuarioData usuarioData { get; set; }


        public UsuarioService(ApplicationDbContext _context) 
        {
            usuario = new Usuarios();
            usuarioData = new UsuarioData(_context);            
        }

        public void CreateUser() 
        {
            Usuarios.Legajo++;
            usuarioData.Post(usuario);
        }
    }
}
