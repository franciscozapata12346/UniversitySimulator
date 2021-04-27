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
        public Usuario usuario { get; set; }
        public UsuarioData usuarioData { get; set; }


        public UsuarioService() 
        {
            usuario = new Usuario();
            usuarioData = new UsuarioData();            
        }

        public bool CreateUser(string nombre, string apellido, string dni, string pass, string email, int legajo) 
        {

            return usuarioData.CreateUser(nombre, apellido, dni, pass, email, legajo);
            

        }

        public bool ValidateUser(string dni, string email)
        {

            return usuarioData.ValidateUser(dni, email);


        }
    }
}
