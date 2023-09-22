using System;

namespace Facturacion.Api.ventas.Aplicacion
{
    public class ProductosDto
    {
        public Guid? ListaComprasId { get; set; }
        public string ProductosName { get; set; }
        public float Precio { get; set; }

    }
}
