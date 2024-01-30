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
    public class RepositoryPedido
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public RepositoryPedido()
        {
            string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=NETCORE;Persist Security Info=True;User ID=SA;Password=MCSD2023";
            this.connection = new SqlConnection(connectionString);
            this.command = new SqlCommand();
            this.command.Connection = this.connection;
        }

//        create procedure SP_PEDIDOS
//as
//	select CodigoPedido from Pedidos
//go

        public Pedididos GetPedidos(string codigoClient)
        {
            SqlParameter pamCodigoCliente = new SqlParameter("@codigocliente", codigoClient);
            this.command.Parameters.Add(pamCodigoCliente);

            this.command.CommandType = CommandType.StoredProcedure;
            this.command.CommandText = "SP_PEDIDOS_CLIENTE";
            this.connection.Open();
            this.reader = command.ExecuteReader();
            Pedididos pedidos = new Pedididos();
            while (this.reader.Read())
            {
                pedidos.CodigoPedido = (this.reader["CodigoPedido"].ToString());
                
            }
            this.reader.Close();
            this.connection.Close();
            return pedidos;
        }
    }
}
