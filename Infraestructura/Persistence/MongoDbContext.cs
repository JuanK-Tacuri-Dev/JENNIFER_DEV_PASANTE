using MongoDB.Driver;

namespace Infraestructura.Persistence
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(string connectionString, string databaseName)
        {
            // Crear el cliente y conectarse a MongoDB
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        // Método para obtener una colección de la base de datos
        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}


