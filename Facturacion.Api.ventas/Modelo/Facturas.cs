using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Facturacion.Api.ventas.Modelo
{
    public class Facturas
    {
        [Key]
        public int FacturaId { get; set; }
        public DateTime? FechaFacturacion { get; set; }
        public ICollection<ListaCompras> ListaCompras { get; set; }
        public int ClientesId { get; set; }
        public string FacturaGuid { get; set; }
    }
}
