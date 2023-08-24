using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TiendaMascotas_API.Data;
using TiendaMascotas_API.DTOs;
using TiendaMascotas_API.Models;

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

        public async Task<bool> updateCliente(ClienteDTO cliente)
        {
            var transaction = _context.Database.BeginTransaction();
            bool resp = true;
            try
            {
                var clienteEncontrado = await _context.Clientes.Where(c => 
                c.IdCliente == cliente.IdCliente).FirstOrDefaultAsync();
                if (clienteEncontrado == null)
                    throw new TaskCanceledException("El cliente no existe");
                var userEncontrado = await _context.Usuarios.Where(u => 
                u.IdUsuario == cliente.IdUsuario).FirstOrDefaultAsync();
                clienteEncontrado.Nombre = cliente.Nombre;
                //Falta

                _context.Usuarios.Update(_mapper.Map<Usuario>(userEncontrado));
                await _context.SaveChangesAsync();

                _context.Clientes.Update(_mapper.Map<Cliente>(clienteEncontrado));
                await _context.SaveChangesAsync();

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                resp = false;
                throw;
            }
            return resp;
        }
    }
}

