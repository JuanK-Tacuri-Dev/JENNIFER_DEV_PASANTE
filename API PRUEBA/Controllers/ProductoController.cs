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
    public class ProductoController : ControllerBase
    {
        private readonly ProductoRepository _repository;
        private readonly IConfiguration _configuration; // Agregar IConfiguration como un campo privado
        private MongoDbContext context;

        public ProductoController(IConfiguration configuration)
        {
            _configuration = configuration; 

            var connectionString = _configuration.GetSection("MongoDB:ConnectionString").Value;
            var databaseName = _configuration.GetSection("MongoDB:DatabaseName").Value;

            if (string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(databaseName))
            {
                throw new InvalidOperationException("La configuración de MongoDB no está correctamente definida en appsettings.json");
            }

            context = new MongoDbContext(connectionString, databaseName);
            _repository = new ProductoRepository(context);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Producto producto)
        {

            // Reutilizamos el contexto del constructor
            var proveedorRepository = new ProveedorRepository(context);
            var impuestoRepository = new ImpuestoRepository(context);

            // Validar que los IDs de Proveedor e Impuesto existan
            var proveedor = await proveedorRepository.GetAllAsync();
            var impuesto = await impuestoRepository.GetAllAsync();

            if (proveedor == null || impuesto == null)
            {
                return BadRequest("El proveedor o el impuesto especificado no existe.");
            }

            await _repository.CrearAsync(producto);
            return CreatedAtAction(nameof(Crear), new { id = producto.Id }, producto);
        }
    }
}


