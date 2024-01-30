using PracticaCore.Models;
using PracticaCore.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#region PROCEDIMIENTOS
//create procedure SP_CLIENTES
//as
//	select Empresa from clientes
//go
//create procedure SP_CLIENTES_DATA
//(@codcliente nvarchar(50))
//as
//  select* from clientes where CodigoCliente = @codcliente
//go

//create procedure SP_PEDIDOS_CLIENTE
//(@codigocliente nvarchar(50))
//as
//    select CodigoPedido from Pedidos
//	where CodigoCliente = @codigocliente
//go

#endregion

namespace PracticaCore
{
    public partial class FormPractica : Form
    {
        RepositoryClientes repo;
        RepositoryPedido repoPedido;
        public FormPractica()
        {
            InitializeComponent();
            this.repo = new RepositoryClientes();
            this.repoPedido = new RepositoryPedido();
            LoadClientes();
        }

        private void LoadClientes()
        {
            List<string> clientes = this.repo.GetClientes();
            foreach (string client in clientes)
            {
                this.cmbclientes.Items.Add(client);
            }
        }

        private void cmbclientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombreClient = this.cmbclientes.SelectedItem.ToString();
            Cliente cliente = this.repo.GetClientes(nombreClient);

            this.txtempresa.Text = cliente.Empresa;
            this.txtcontacto.Text = cliente.Contacto;
            this.txtcargo.Text = cliente.Cargo;
            this.txtciudad.Text = cliente.Ciudad;
            this.txttelefono.Text = cliente.Telefono;

            string codigoCliente = this.cmbclientes.SelectedItem.ToString();
            Pedididos pedididos = this.repoPedido.GetPedidos(codigoCliente);
            this.lstpedidos.Items.Add(pedididos);
        }

        private void lstpedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
