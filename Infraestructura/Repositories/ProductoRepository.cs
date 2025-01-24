using Infraestructura.Models;
using Infraestructura.Persistence;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infraestructura.Repositories
{
    public class ProductoRepository
    {
        private readonly IMongoCollection<Producto> _productos;

        public ProductoRepository(MongoDbContext context)
        {
            _productos = context.GetCollection<Producto>("Productos");
        }

        public async Task<List<Producto>> GetAllAsync(int page, int pageSize)
        {
            return await _productos.Find(p => true)
                .Skip((page - 1) * pageSize)
                .Limit(pageSize)
                .ToListAsync();
        }

        public async Task<Producto> GetByIdAsync(string id)
        {
            return await _productos.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task CrearAsync(Producto producto)
        {
            await _productos.InsertOneAsync(producto);
        }

        public async Task ActualizarAsync(string id, Producto productoActualizado)
        {
            await _productos.ReplaceOneAsync(p => p.Id == id, productoActualizado);
        }
    }
}

