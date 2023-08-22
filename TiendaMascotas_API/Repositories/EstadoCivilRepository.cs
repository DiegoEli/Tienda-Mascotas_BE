using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TiendaMascotas_API.Data;
using TiendaMascotas_API.DTOs;

namespace TiendaMascotas_API.Repositories
{
    public class EstadoCivilRepository
    {
        private readonly PeluditosDbContext _context;
        private readonly IMapper _mapper;

        public EstadoCivilRepository(PeluditosDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<EstadoCivilDTO>> getEstadoCivil()
        {
            return await _context.EstadoCivils.ProjectTo<EstadoCivilDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
