using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Infraestructura.Models
{
    public class Producto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Nombre { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string ProveedorId { get; set; } // Relación con Proveedor

        [BsonRepresentation(BsonType.ObjectId)]
        public string ImpuestoId { get; set; } // Relación con Impuesto
    }
}

