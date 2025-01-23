using Microsoft.AspNetCore.Mvc;

namespace APIPRUEBA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        // Lista almacenar usuarios
        private static List<Usuario> Usuarios = new List<Usuario>();

        // GET: api/usuarios
        [HttpGet]
        public IActionResult GetUsuarios()
        {
            return Ok(Usuarios); 
        }

        // POST: api/usuarios
        [HttpPost]
        public IActionResult CrearUsuario([FromBody] Usuario nuevoUsuario)
        {
            if (nuevoUsuario == null || string.IsNullOrEmpty(nuevoUsuario.Nombre))
            {
                return BadRequest("El nombre del usuario es obligatorio.");
            }

            // Agregar usuario a la lista
            Usuarios.Add(nuevoUsuario);

            return CreatedAtAction(nameof(GetUsuarios), new { id = nuevoUsuario.Id }, nuevoUsuario);
        }
    }

    // Clase Usuario
    public class Usuario
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Email { get; set; }
    }
}

