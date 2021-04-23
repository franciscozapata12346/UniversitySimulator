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
using Microsoft.Extensions.Configuration;
using System.IO;

namespace UniversitySimulator.Data
{
    public class UsuarioData
    {
        public static SqlConnection _connection;

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.
                GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
        public UsuarioData()
        {
            //var configuation = GetConfiguration();
            //configuation.GetSection("Data").GetSection("ConnectionStrings").Value
            _connection = new SqlConnection("Data Source=DESKTOP-7VGDV0F;Initial Catalog=db_university_simulator;Integrated Security=True");
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
               // BeginTransaction();
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
                _connection.Open();
                cmd.Connection = _connection;
                SqlDataReader dr1 =  cmd.ExecuteReader();
                dr1.Close();

                SqlCommand cm2 = new SqlCommand("SELECT dni FROM Usuarios " +
                    " WHERE dni = @dni ");
                cm2.Connection = _connection;
                cm2.Parameters.AddWithValue("@dni", dni);
                cm2.CommandType = CommandType.Text;
                SqlDataReader dr2 = cm2.ExecuteReader();
                if (dr2.HasRows) 
                {
                    usuarioCreado = true;
                }

                //CommitTransaction();
            }
            catch (Exception ex)
            {
                //RollbackTransaction();
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
