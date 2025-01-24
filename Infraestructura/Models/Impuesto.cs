using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Infraestructura.Models
{

    public class Impuesto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public double Porcentaje { get; set; }
    }
}

