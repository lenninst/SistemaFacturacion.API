using Facturacion.Api.ventas.Modelo;
using Facturacion.Api.ventas.Persitencia;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Facturacion.Api.ventas.Aplicacion
{
    public class AgregarProductos
    {
        public class NuevoProducto : IRequest
        {
            public string ProductosName { get; set; }
            public float Precio { get; set; }

        }
        public class ProductoValidacion : AbstractValidator<NuevoProducto>
        {
            public ProductoValidacion()
            {
                RuleFor(x => x.ProductosName).NotEmpty();
                RuleFor(x => x.Precio).NotEmpty();
            }
        }
        public class Manejador : IRequestHandler<NuevoProducto>
        {
            public readonly FacturaContext _context;
            public Manejador(FacturaContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(NuevoProducto request, CancellationToken cancellationToken)
            {
                var produtos = new Productos
                {
                    ProductosName = request.ProductosName,
                    Precio = request.Precio,
                    ProductosGuid = Convert.ToString(Guid.NewGuid())
                };
                _context.Productos.Add(produtos);
                var value = await _context.SaveChangesAsync();
                if (value > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo agregar el producto");
            }
        }

    }
}
