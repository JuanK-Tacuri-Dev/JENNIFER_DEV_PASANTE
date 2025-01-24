using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Infraestructura.Models
{
    public class Impuesto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Descripcion { get; set; }
        public double Porcentaje { get; set; }
    }
}

