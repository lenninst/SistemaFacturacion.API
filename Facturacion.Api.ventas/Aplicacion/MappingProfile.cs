using AutoMapper;
using Facturacion.Api.ventas.Modelo;

namespace Facturacion.Api.ventas.Aplicacion
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ListaCompras, ListaComprasDto>();
            CreateMap<Productos, ProductosDto>();
        }
    }
}
