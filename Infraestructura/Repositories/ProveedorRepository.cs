using Infraestructura.Models;
using Infraestructura.Persistence;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infraestructura.Repositories
{
    public class ProveedorRepository
    {
        private readonly IMongoCollection<Proveedor> _collection;

        public ProveedorRepository(MongoDbContext context)
        {
            if (context == null) // Validar si el contexto es nulo

            {
                throw new ArgumentNullException(nameof(context), "El contexto de MongoDb no puede ser nulo."); 
            }
                _collection = context.GetCollection<Proveedor>("Proveedores");
        }

        public async Task<List<Proveedor>> GetAllAsync()
        {
            return await _collection.Find(p => true).ToListAsync();
        }

        public async Task CrearAsync(Proveedor proveedor)
        {
            await _collection.InsertOneAsync(proveedor);
        }
    }
}

