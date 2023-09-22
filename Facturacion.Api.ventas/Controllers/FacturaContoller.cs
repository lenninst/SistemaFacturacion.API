using Facturacion.Api.ventas.Aplicacion;
using Facturacion.Api.ventas.Modelo;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Facturacion.Api.ventas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaContoller : ControllerBase
    {
        private readonly IMediator _mediator;
        public FacturaContoller(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("CrearCliente")]
        public async Task<ActionResult<Unit>> CrearCliente(AgregarCliente.NuevoCliente data)
        {
            return await _mediator.Send(data);
        }

        [HttpPost("CrearProducto")]
        public async Task<ActionResult<Unit>> CrearProducto(AgregarProductos.NuevoProducto data)
        {
            return await _mediator.Send(data);
        }

        [HttpPost("Factura")]
        public async Task<ActionResult<Unit>> CrearListaCompras(CrearFactura.NuevaFactura data)
        {
            return await _mediator.Send(data);
        }
        [HttpGet("{facturaid}")]
        public async Task<ActionResult<ListaComprasDto>> ConsultarListado(int id)
        {
            return await _mediator.Send(new mostrarProdAgregado.ConsultarListado { FacturaId = id });
        }
        [HttpDelete ("{listaComprasId}")]
        public async Task<IActionResult> EliminarItemProducto (int listaComprasId)
        {
            var eliminar = new eliminarItemProduco.QuitarProducto
            {
                ListaComprasId = listaComprasId
            };
            await _mediator.Send(eliminar);
            return NoContent();
        }

       
    }

}

