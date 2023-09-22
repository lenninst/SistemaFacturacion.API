using Facturacion.Api.ventas.Modelo;
using System.Collections.Generic;

namespace Facturacion.Api.ventas.Aplicacion
{
    public class ListaComprasDto
    {
        public int ListaComprasId { get; set; }
        public int cantidad { get; set; }
        public int FacturaId { get; set; }
        public int ProductosId { get; set; }
        public Productos Productos { get; set; }
    }
}
