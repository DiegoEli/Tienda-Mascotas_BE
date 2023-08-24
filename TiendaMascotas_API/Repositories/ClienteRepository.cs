using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<ClienteDTO> getCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            return _mapper.Map<ClienteDTO>(cliente);
        }

        public async Task<bool> validateCedula(string identificacion)
        {
            bool resp = true;
            try
            {
                var cliente = await _context.Clientes.Where(u => u.Identificacion == identificacion).FirstOrDefaultAsync();
                if (cliente == null)
                    resp = false;
            }
            catch
            {
                resp = false;
                throw;
            }
            return resp;
        }

        public async Task<bool> updateCliente(ClienteDTO cliente)
        {
            var transaction = _context.Database.BeginTransaction();
            bool resp = true;
            try
            {
                var clienteEncontrado = await _context.Clientes.Where(c => c.IdCliente == cliente.IdCliente).FirstOrDefaultAsync();
                if (clienteEncontrado == null)
                    throw new TaskCanceledException("El cliente no existe");
                var userEncontrado = await _context.Usuarios.Where(u => u.IdUsuario == cliente.IdUsuario).FirstOrDefaultAsync();

                userEncontrado.Nombre = cliente.Nombre;
                userEncontrado.Email = cliente.Email;
                userEncontrado.Clave = cliente.Clave;
                _context.Usuarios.Update(_mapper.Map<Usuario>(userEncontrado));
                await _context.SaveChangesAsync();

                clienteEncontrado.Nombre = cliente.Nombre;
                clienteEncontrado.Identificacion = cliente.Identificacion;
                clienteEncontrado.Email = cliente.Email;
                clienteEncontrado.Telefono = cliente.Telefono;
                clienteEncontrado.Direccion = cliente.Direccion;
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

