using Facturacion.Api.ventas.Modelo;
using Facturacion.Api.ventas.Persitencia;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Facturacion.Api.ventas.Aplicacion
{
    public class CrearFactura
    {
        public class NuevaFactura : IRequest
        {
            public DateTime FechaEmision { get; set; }
            public int ClientesId { get; set; }
            public List<ListaCompras> ListaCompras { get; set; }


        }
        public class FacturaValidacion : AbstractValidator<NuevaFactura>
        {
            public FacturaValidacion()
            {
                RuleFor(x => x.ClientesId);
                RuleFor(x => x.ListaCompras);
            }
        }
        public class Manejador : IRequestHandler<NuevaFactura>
        {
            private readonly FacturaContext _context;
            public Manejador(FacturaContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(NuevaFactura request, CancellationToken cancellationToken)
            {
                var factura = new Facturas
                {
                    FechaFacturacion = request.FechaEmision,
                    ClientesId = request.ClientesId,
                    FacturaGuid = Convert.ToString(Guid.NewGuid()),
                };

                _context.Facturas.Add(factura);
                await _context.SaveChangesAsync();

                int facturaId = factura.FacturaId;

                foreach (var producto in request.ListaCompras)
                {
                    var facturaProducto = new ListaCompras
                    {
                        cantidad = producto.cantidad,
                        FacturaId = facturaId,
                        ProductosId = producto.ProductosId,

                    };

                    _context.ListaCompras.Add(facturaProducto);
                }

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }


}
