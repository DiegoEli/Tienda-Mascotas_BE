using Microsoft.EntityFrameworkCore;
using TiendaMascotas_API.Models;

namespace TiendaMascotas_API.Repositories
{
    public class CategoriaRepository
    {
        private readonly PeluditosDbContext _context;

        public CategoriaRepository(PeluditosDbContext context)
        {
            _context = context;
        }

        public async Task<List<Categoria>> getCategorias()
        {
            return await _context.Categorias.ToListAsync();
        }
    }
}
