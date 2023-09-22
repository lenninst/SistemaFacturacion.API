using AutoMapper;
using Facturacion.Api.ventas.Persitencia;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Facturacion.Api.ventas.Aplicacion
{
    public class eliminarItemProduco
    {
        public class QuitarProducto : IRequest
        {
            public int ListaComprasId { get; set; }
        }
        public class Manejador : IRequestHandler<QuitarProducto>
        {
            private readonly FacturaContext _context;
            private readonly IMapper _mapper;

            public Manejador (FacturaContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<Unit> Handle(QuitarProducto request, CancellationToken cancellationToken)
            {
                var productoDel = await _context.ListaCompras
                    .FirstOrDefaultAsync(x => x.ListaComprasId == request.ListaComprasId);
                if (productoDel == null)
                {
                    throw new System.Exception("Elemento no encontrado");
                }
               _context.ListaCompras.Remove(productoDel);
                 await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }

}
