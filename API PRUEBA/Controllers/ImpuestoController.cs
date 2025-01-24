using Infraestructura.Models;
using Infraestructura.Persistence;
using Infraestructura.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Threading.Tasks;

namespace APIPRUEBA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImpuestoController : ControllerBase
    {
        private readonly ImpuestoRepository _repository;
        private IConfiguration _configuration;

        public ImpuestoController(IConfiguration configuration)
        {
            _configuration = configuration;

            var connectionString = _configuration.GetSection("MongoDB:ConnectionString").Value;
            var databaseName = _configuration.GetSection("MongoDB:DatabaseName").Value;

            if (string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(databaseName))
            {
                throw new InvalidOperationException("La configuración de MongoDB no está correctamente definida en appsettings.json");
            }

            var context = new MongoDbContext(connectionString, databaseName);
            _repository = new ImpuestoRepository(context);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var impuestos = await _repository.GetAllAsync();
            return Ok(impuestos);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Impuesto impuesto)
        {
            await _repository.CrearAsync(impuesto);
            return CreatedAtAction(nameof(Crear), new { id = impuesto.Id}, impuesto);
        }
    }
}

