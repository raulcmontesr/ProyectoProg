using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFacturaMvc.Models
{
    public class ClienteVendedor
    {
        public List<Model.Entity.Venta> Ventas { get; set; }
        public List<Model.Entity.Cliente> Clientes { get; set; }
    }
}