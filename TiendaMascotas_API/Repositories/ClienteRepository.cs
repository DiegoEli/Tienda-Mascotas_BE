using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TiendaMascotas_API.Data;
using TiendaMascotas_API.DTOs;

namespace TiendaMascotas_API.Repositories
{
    public class ClienteRepository
    {
        private readonly PeluditosDbContext _context;
        private readonly IMapper _mapper;

        public ClienteRepository(PeluditosDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ClienteDTO>> getClientes()
        {
            return await _context.Clientes.ProjectTo<ClienteDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }

    }


}

