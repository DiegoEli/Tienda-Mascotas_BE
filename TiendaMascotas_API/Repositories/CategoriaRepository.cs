using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TiendaMascotas_API.Data;
using TiendaMascotas_API.DTOs;
using TiendaMascotas_API.Models;

namespace TiendaMascotas_API.Repositories
{
    public class CategoriaRepository
    {
        private readonly PeluditosDbContext _context;
        private readonly IMapper _mapper;

        public CategoriaRepository(PeluditosDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CategoriaDTO>> getCategorias()
        {
            return await _context.Categorias.ProjectTo<CategoriaDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
