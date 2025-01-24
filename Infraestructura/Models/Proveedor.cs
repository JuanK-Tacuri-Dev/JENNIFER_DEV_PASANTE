using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Infraestructura.Models
{

    public class Proveedor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public string Nombre { get; set; } = string.Empty;
    }
}

