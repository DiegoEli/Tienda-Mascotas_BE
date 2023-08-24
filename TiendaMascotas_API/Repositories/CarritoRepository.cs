using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TiendaMascotas_API.Data;
using TiendaMascotas_API.DTOs;
using TiendaMascotas_API.Models;

namespace TiendaMascotas_API.Repositories
{
    public class CarritoRepository
    {
        private readonly PeluditosDbContext _context;
        private readonly IMapper _mapper;

        public CarritoRepository(PeluditosDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CarritoDTO> getCarrito(ClienteDTO cliente)
        {
            var carrito = await _context.Clientes.Where(c => c.IdCliente == cliente.IdCliente && c.Estado == true).FirstOrDefaultAsync();
            return _mapper.Map<CarritoDTO>(carrito);
        }

        public async Task<CarritoDTO> registerCarrito(Carrito carrito)
        {
            var transaction = _context.Database.BeginTransaction();
            Carrito pedido = new Carrito();
            try
            {
                //Actualizar stock de producto
                foreach (CarritoDt dtc in carrito.CarritoDts)
                {
                    Producto productoEncontrado = _context.Productos.Where(p => p.IdProducto == dtc.IdProducto).First();
                    productoEncontrado.Stock = productoEncontrado.Stock - dtc.Cantidad;
                    _context.Productos.Update(productoEncontrado);
                }
                await _context.SaveChangesAsync();

                await _context.Carritos.AddAsync(carrito);
                await _context.SaveChangesAsync();

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            return _mapper.Map<CarritoDTO>(carrito);
        }
    }
}
