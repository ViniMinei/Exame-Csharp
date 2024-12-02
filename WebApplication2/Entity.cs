using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WebApplication2
{
    public class Entity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;
        public int Age { get; set; }
    }
}
