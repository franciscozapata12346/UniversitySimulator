using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversitySimulator.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sql;
using Microsoft.Data.SqlTypes;
using System.Data;

namespace UniversitySimulator.Data
{
    public class UsuarioData : ApplicationDbContext
    {
        public UsuarioData()
        {

        }

        public static string Base64Encode(string word)
        {
            byte[] byt = System.Text.Encoding.UTF8.GetBytes(word);
            return Convert.ToBase64String(byt);
        }
        public static string Base64Decode(string word)
        {
            byte[] b = Convert.FromBase64String(word);
            return System.Text.Encoding.UTF8.GetString(b);
        }

        public bool CreateUser(string nombre, string apellido, string dni, string pass, string email, int legajo)
        {
            bool usuarioCreado = false;
            pass = Base64Encode(pass);
            try
            {
                BeginTransaction();
                SqlCommand cmd = new SqlCommand("INSERT INTO Usuarios(legajo, dni, nombre, apellido, email, pass, id_rol)" +
                " VALUES (@legajo, @dni, @nombre, @apellido, @email, @pass, @id_rol)");
                cmd.Parameters.AddWithValue("@legajo", legajo);
                cmd.Parameters.AddWithValue("@dni", dni);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@apellido", apellido);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@pass", pass);
                cmd.Parameters.AddWithValue("@id_rol", 2);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteReader();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        usuarioCreado = true;
                    }
                }

                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                throw ex;
            }
            finally 
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }
            return usuarioCreado;
        }
        
    }
}
