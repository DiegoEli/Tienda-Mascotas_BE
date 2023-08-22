using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TiendaMascotas_API.Data;
using TiendaMascotas_API.DTOs;

namespace TiendaMascotas_API.Repositories
{
    public class TipoPagoRepository
    {
        private readonly PeluditosDbContext _context;
        private readonly IMapper _mapper;

        public TipoPagoRepository(PeluditosDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TipoPagoDTO>> getTipoPago()
        {
            return await _context.TipoPagos.ProjectTo<TipoPagoDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
