using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace M101DotNet.WebApp.Models
{
    public class User
    {
        public ObjectId Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }
    }
}