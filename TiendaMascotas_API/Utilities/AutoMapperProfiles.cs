using AutoMapper;
using TiendaMascotas_API.DTOs;
using TiendaMascotas_API.Models;

namespace TiendaMascotas_API.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<EstadoCivil, EstadoCivilDTO>().ReverseMap();
            CreateMap<Producto, ProductoDTO>()
                .ForMember(destino => destino.NombreCategoria,
                opt => opt.MapFrom(origen => origen.IdCategoriaNavigation.Nombre));
            CreateMap<Rol, RolDTO>().ReverseMap();
            CreateMap<TipoPago, TipoPagoDTO>().ReverseMap();

            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(destino => destino.NombreRol,
                opt => opt.MapFrom(origen => origen.IdRolNavigation.Nombre));
            CreateMap<UsuarioDTO, Usuario>()
                .ForMember(destino => destino.IdRolNavigation, opt => opt.Ignore());

            CreateMap<Cliente, ClienteDTO>()
                .ForMember(destino => destino.NombreEstadoCivil,
                opt => opt.MapFrom(origen => origen.IdEstadoCivilNavigation.Nombre))
                .ForMember(destino => destino.Password,
                opt => opt.MapFrom(origen => origen.IdUsuarioNavigation.Clave));
            CreateMap<ClienteDTO, Cliente>()
                .ForMember(destino => destino.IdEstadoCivilNavigation, opt => opt.Ignore())
                .ForMember(destino => destino.IdUsuarioNavigation, opt => opt.Ignore());
        }
    }
}
