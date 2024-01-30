using PracticaCore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaCore.Repositories
{
    public class RepositoryClientes
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public RepositoryClientes()
        {
            string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=NETCORE;Persist Security Info=True;User ID=SA;Password=MCSD2023";
            this.connection = new SqlConnection(connectionString);
            this.command = new SqlCommand();
            this.command.Connection = this.connection;
        }

        public List<string> GetClientes()
        {
            this.command.CommandType = CommandType.StoredProcedure;
            this.command.CommandText = "SP_CLIENTES";
            this.connection.Open();
            this.reader = command.ExecuteReader();
            List<string> clientes = new List<string>();
            while (this.reader.Read()) 
            {
                clientes.Add(this.reader["Empresa"].ToString());
            }
            this.reader.Close();
            this.connection.Close();
            return clientes;
        }

        public Cliente GetClientes(string nombreClient) 
        {
            SqlParameter pamCodigoCliente = new SqlParameter("@codcliente", nombreClient);
            this.command.Parameters.Add(pamCodigoCliente);

            this.command.CommandType = CommandType.StoredProcedure;
            this.command.CommandText = "SP_CLIENTES_DATA";
            this.connection.Open();
            this.reader = this.command.ExecuteReader();

            Cliente cliente = new Cliente();
            while(this.reader.Read())
            {
                cliente.Empresa = this.reader["Empresa"].ToString();
                cliente.Contacto = this.reader["Contacto"].ToString();
                cliente.Cargo = this.reader["Cargo"].ToString();
                cliente.Telefono = this.reader["Telefono"].ToString();
            }
            this.reader.Close();
            this.connection.Close();
            this.command.Parameters.Clear();
            return cliente;
        }
    }
}
