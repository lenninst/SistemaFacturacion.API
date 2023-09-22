using Facturacion.Api.ventas.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Facturacion.Api.ventas.Persitencia
{
    public class FacturaContext : DbContext
    {
        public FacturaContext(DbContextOptions<FacturaContext> options) : base(options) { }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<ListaCompras> ListaCompras { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Facturas> Facturas { get; set; }

        internal List<Productos> Where(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
