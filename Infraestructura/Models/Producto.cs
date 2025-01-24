using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Infraestructura.Models
{

    public class Producto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty; // Inicializa con un valor predeterminado

        public string Nombre { get; set; } = string.Empty; // Inicializa con un valor predeterminado

        [BsonRepresentation(BsonType.ObjectId)]
        public string ProveedorId { get; set; } = string.Empty;

        [BsonRepresentation(BsonType.ObjectId)]
        public string ImpuestoId { get; set; } = string.Empty;
    }
}

