using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TiendaMascotas_API.Data;
using TiendaMascotas_API.DTOs;

namespace TiendaMascotas_API.Repositories
{
    public class UsuarioRepository
    {
        private readonly PeluditosDbContext _context;
        private readonly IMapper _mapper;

        public UsuarioRepository(PeluditosDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UsuarioDTO>> getUsuarios()
        {
            return await _context.Usuarios.ProjectTo<UsuarioDTO>(
                _mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
