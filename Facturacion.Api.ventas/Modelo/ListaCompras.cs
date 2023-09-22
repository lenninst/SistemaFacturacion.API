using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Facturacion.Api.ventas.Modelo
{
    public class ListaCompras
    {
        [Key]
        public int ListaComprasId { get; set; }
        public int cantidad { get; set; }
        public int FacturaId { get; set; }
        public int ProductosId { get; set; }
       

    }
}
