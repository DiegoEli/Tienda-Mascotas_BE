using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TiendaMascotas_API.Data;
using TiendaMascotas_API.DTOs;

namespace TiendaMascotas_API.Repositories
{
    public class ProductoRepository
    {
        private readonly PeluditosDbContext _context;
        private readonly IMapper _mapper;

        public ProductoRepository(PeluditosDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductoDTO>> getProductos()
        {
            return await _context.Productos.ProjectTo<ProductoDTO>(
                _mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
