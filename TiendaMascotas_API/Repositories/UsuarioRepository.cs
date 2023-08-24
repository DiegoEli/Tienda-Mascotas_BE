using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TiendaMascotas_API.Data;
using TiendaMascotas_API.DTOs;
using TiendaMascotas_API.Models;

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

        public async Task<UsuarioDTO> validateCredentials(string correo, string clave)
        {
            try
            {
                clave = encriptar(clave);
                var usuario = await _context.Usuarios.Where(u =>
                    u.Email == correo &&
                    u.Clave == clave).FirstOrDefaultAsync();
                if (usuario == null)
                    throw new TaskCanceledException("Usuario no registrado");
                return _mapper.Map<UsuarioDTO>(usuario);
            }
            catch
            {
                throw;
            }
        }

        public async Task<ClienteDTO> register(ClienteDTO cliente)
        {
            var transaction = _context.Database.BeginTransaction();
            Usuario user = new Usuario();
            try
            {
                user.Nombre = cliente.Nombre;
                user.Email = cliente.Email;
                user.Clave = encriptar(cliente.Clave!);
                user.IdRol = _context.Rols
                    .Where(r => r.Nombre == "Cliente")
                    .Select(r => r.IdRol).FirstOrDefault();

                //Agregar Usuario
                _context.Usuarios.Add(user);
                await _context.SaveChangesAsync();

                //Agregar Cliente
                cliente.IdUsuario = user.IdUsuario;
                _context.Clientes.Add(_mapper.Map<Cliente>(cliente));
                await _context.SaveChangesAsync();

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            return cliente;
        }

        public async Task<bool> resetPassword(UsuarioDTO user)
        {
            bool resp = true;
            try
            {
                user.Clave = encriptar(user.Clave!);
                var userEncontrado = await _context.Usuarios.Where(u => u.IdUsuario == user.IdUsuario).FirstOrDefaultAsync();
                if (userEncontrado == null)
                    throw new TaskCanceledException("El usuario no existe");
                userEncontrado.Clave = user.Clave;
                _context.Usuarios.Update(userEncontrado);
                await _context.SaveChangesAsync();
            }
            catch
            {
                resp = false;
                throw;
            }
            return resp;
        }

        #region Seguridad de contraseñas
        public string encriptar(string txt)
        {
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(txt);
            string result = Convert.ToBase64String(encryted);
            return result;
        }

        public static string desEncriptar(string txt)
        {
            byte[] decryted = Convert.FromBase64String(txt);
            string result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }
        #endregion
    }
}
