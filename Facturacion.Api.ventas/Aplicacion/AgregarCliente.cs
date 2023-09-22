using Facturacion.Api.ventas.Modelo;
using Facturacion.Api.ventas.Persitencia;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Facturacion.Api.ventas.Aplicacion
{
    public class AgregarCliente
    {
        public class NuevoCliente : IRequest
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Telefono { get; set; }
            public string Direccion { get; set; }


        }
        public class ClienteValidacion : AbstractValidator<NuevoCliente>
        {
            public ClienteValidacion()
            {
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Apellido).NotEmpty();
                RuleFor(x => x.Telefono).NotEmpty();
                RuleFor(x => x.Direccion).NotEmpty();
            }
        }
        public class Manejador : IRequestHandler<NuevoCliente>
        {
            private readonly FacturaContext _context;

            public Manejador(FacturaContext context)
            {
                _context = context;

            }

            public async Task<Unit> Handle(NuevoCliente request, CancellationToken cancellationToken)
            {
                var nuevoCliente = new Clientes
                {
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    Telefono = request.Telefono,
                    Direccion = request.Direccion,
                    ClientesGuid = Convert.ToString(Guid.NewGuid())
                };
                _context.Clientes.Add(nuevoCliente);
                var value = await _context.SaveChangesAsync();
                if (value > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo agregar un cliente");
            }
        }
    }
}
