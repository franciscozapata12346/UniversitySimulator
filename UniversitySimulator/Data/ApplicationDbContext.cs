using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniversitySimulator.Models;

namespace UniversitySimulator.Data
{
    public class ApplicationDbContext
    {
        public static SqlConnection _connection;
        public static SqlTransaction _transaction;

        public ApplicationDbContext()
        {
            var configuation = GetConfiguration();
            _connection = new SqlConnection(configuation.GetSection("Data").GetSection("ConnectionStrings").Value);
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }


        //protected static string ConnectionString
        //{
        //    get
        //    {
        //        return ConnectionStrings["ConexionBD"].ConnectionString;
        //    }
        //}

        protected static SqlConnection Connection
        {
            get { return _connection; }
            set { _connection = value; }
        }

        protected static SqlTransaction Transaction
        {
            get { return _transaction; }
            set { _transaction = value; }
        }

        public static void BeginTransaction()
        {
            int TimeOut = 36; // 36x250ms = 9 segundos.
            while (_connection != null)
            {
                Thread.Sleep(250);
                TimeOut--;

                if (TimeOut == 0)
                {
                    RollbackTransaction();
                }
            }

           // _connection = new SqlConnection(ConnectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public static void CommitTransaction()
        {
            _transaction.Commit();
            _transaction.Dispose();
            _connection.Dispose();
            _connection = null;
        }

        public static void RollbackTransaction()
        {
            _transaction.Rollback();
            _transaction.Dispose();
            _connection.Dispose();
            _connection = null;
        }
    }
}
