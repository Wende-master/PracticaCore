﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaCore.Models
{
    public class Pedididos
    {
        public string CodigoPedido { get; set; }
        public string CodigoCliente { get; set; }
        public string FechaEntrega {get; set;}
        public string FormaEnvio { get; set;}   
        public int Importe { get; set; }    

    }
}
