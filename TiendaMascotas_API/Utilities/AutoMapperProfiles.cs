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
            CreateMap<TipoPago, TipoPagoDTO>().ReverseMap();
        }
    }
}
