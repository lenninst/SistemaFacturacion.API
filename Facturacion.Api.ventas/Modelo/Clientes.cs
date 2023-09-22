using System.Collections.Generic;

namespace Facturacion.Api.ventas.Modelo
{
    public class Clientes
    {
        public int ClientesId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public ICollection<ListaCompras> ListaCompras { get; set; }
        public string ClientesGuid { set; get; }

    }
}
