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

        public Usuario LoadUsuario(SqlDataReader dr)
        {
            List<object> list = new List<object>();
            foreach (var item in dr)
            {
                list.Add(item);

            }
            string passDesCript = Base64Decode(list[0].ToString()); ;
            Usuario usuario = new Usuario()
            {
                Legajo = Int32.Parse(list[1].ToString()),
                DNI = list[2].ToString(),
                Nombre = list[3].ToString(),
                Apellido = list[4].ToString(),
                Email = list[5].ToString(),                           
                Password = passDesCript,
            };
            return usuario;
        }

        public Usuario ConsultarUsuario(string email, string password)
        {
            List<string> list = new List<string>();
            Usuario usuario = new Usuario();
            password = Base64Encode(password);
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios " +
                    " WHERE pass=@password AND email=@email");
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.CommandType = CommandType.Text;
                _connection.Open();
                cmd.Connection = _connection;
                SqlDataReader dr1 = cmd.ExecuteReader();
                if (dr1.HasRows)
                {
                    usuario = LoadUsuario(dr1);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally 
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }
            return usuario;
        }

        public bool ValidateUser(string dni, string email)
        {
            bool rtado = true;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios " +
                    " WHERE dni=@dni OR email=@email");                
                cmd.Parameters.AddWithValue("@dni", dni);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.CommandType = CommandType.Text;
                _connection.Open();
                cmd.Connection = _connection;
                SqlDataReader dr1 = cmd.ExecuteReader();
                if (dr1.HasRows)
                {
                    rtado = false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }
            return rtado;
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
                SqlCommand cmd = new SqlCommand("INSERT INTO Usuarios(legajo, dni, nombre, apellido, email, pass)" +
                " VALUES (@legajo, @dni, @nombre, @apellido, @email, @pass)");
                cmd.Parameters.AddWithValue("@legajo", legajo);
                cmd.Parameters.AddWithValue("@dni", dni);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@apellido", apellido);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@pass", pass);
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
            }
            catch (Exception ex)
            {
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
