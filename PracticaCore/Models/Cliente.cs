using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaCore.Models
{
    public class Cliente
    {
        public string CodiGoCliente { get; set; }
        public string Empresa { get; set; }
        public string Cargo { get; set;}
        public string Ciudad { get; set; }
        public string Telefono { get; set; }
        public string Contacto { get; set; }

        public Cliente ()
        {

        }
    }
}
