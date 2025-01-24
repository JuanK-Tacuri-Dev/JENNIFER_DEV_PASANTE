using Infraestructura.Models;
using Infraestructura.Persistence;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infraestructura.Repositories
{
    public class ProveedorRepository
    {
        private readonly IMongoCollection<Proveedor> _proveedores;

        public ProveedorRepository(MongoDbContext context)
        {
            _proveedores = context.GetCollection<Proveedor>("Proveedores");
        }

        public async Task<List<Proveedor>> GetAllAsync()
        {
            return await _proveedores.Find(p => true).ToListAsync();
        }

        public async Task CrearAsync(Proveedor proveedor)
        {
            await _proveedores.InsertOneAsync(proveedor);
        }
    }
}

