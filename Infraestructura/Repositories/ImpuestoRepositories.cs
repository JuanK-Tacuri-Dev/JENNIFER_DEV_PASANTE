using Infraestructura.Models;
using Infraestructura.Persistence;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infraestructura.Repositories
{
    public class ImpuestoRepository
    {
        private readonly IMongoCollection<Impuesto> _impuestos;

        public ImpuestoRepository(MongoDbContext context)
        {
            _impuestos = context.GetCollection<Impuesto>("Impuestos");
        }

        public async Task<List<Impuesto>> GetAllAsync()
        {
            return await _impuestos.Find(p => true).ToListAsync();
        }

        public async Task CrearAsync(Impuesto impuesto)
        {
            await _impuestos.InsertOneAsync(impuesto);
        }
    }
}

