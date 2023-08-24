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

        public async Task<UsuarioDTO> register(UsuarioDTO user, ClienteDTO cliente)
        {
            var transaction = _context.Database.BeginTransaction();

            try
            {
                //Agregar Usuario
                user.Clave = encriptar(user.Clave!);
                _context.Usuarios.Add(_mapper.Map<Usuario>(user));
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
            return user;
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
