using AutoMapper;
using Facturacion.Api.ventas.Modelo;
using Facturacion.Api.ventas.Persitencia;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Facturacion.Api.ventas.Aplicacion
{
    public class mostrarProdAgregado
    {
        public class ConsultarListado : MediatR.IRequest<ListaComprasDto>
        {
            public int FacturaId { get; set; }
           
        }

        public class Manejador : IRequestHandler<ConsultarListado, ListaComprasDto>
        {
            private readonly FacturaContext _context;
            private readonly IMapper _mapper;
            public Manejador(FacturaContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task <ListaComprasDto> Handle(ConsultarListado request, CancellationToken cancellationToken)
            {
                var factura = await _context.ListaCompras.FirstOrDefaultAsync(
                    x => x.FacturaId == request.FacturaId);

                var facturasMap = _mapper.Map<ListaCompras, ListaComprasDto>(factura);
                           
                var produtosList = await _context.Productos.Where(
                    x => x.ProductosId == facturasMap.ProductosId).ToListAsync();

                var listaProductos = new List<Productos>();

                foreach (var itemProduct in produtosList) {

                    var objproducto = facturasMap.Productos;
                    var producto = new ProductosDto
                    {
                        
                        ProductosName = itemProduct.ProductosName,
                        Precio = itemProduct.Precio,
                    };
                    listaProductos.Add(itemProduct);
                                    
                }
                var listadoProducto = new ListaComprasDto
                {
                    ListaComprasId = facturasMap.ListaComprasId,
                    cantidad = facturasMap.cantidad,
                    

                };

              if (listaProductos == null)
                {
                    throw new Exception("No se encontro la factura");
                }       
                return listadoProducto;

            }
        }
    }
}