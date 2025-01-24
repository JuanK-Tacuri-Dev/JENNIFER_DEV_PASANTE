using Infraestructura.Models;
using Infraestructura.Persistence;
using Infraestructura.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace APIPRUEBA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProveedorController : ControllerBase
    {
        private readonly ProveedorRepository _repository;

        public ProveedorController(IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("MongoDB:ConnectionString").Value;
            var databaseName = configuration.GetSection("MongoDB:DatabaseName").Value;

            var context = new MongoDbContext(connectionString, databaseName);
            _repository = new ProveedorRepository(context);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var proveedores = await _repository.GetAllAsync();
            return Ok(proveedores);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Proveedor proveedor)
        {
            await _repository.CrearAsync(proveedor);
            return CreatedAtAction(nameof(Crear), new {id = proveedor.Id}, proveedor);
        }
    }
}

