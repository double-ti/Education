using System;
using MongoDB.Bson.Serialization.Attributes;

namespace M101DotNet.WebApp.Models
{
    public class Comment
    {
        // XXX WORK HERE
        // Add in the appropriate properties.
        // The homework instructions have the
        // necessary schema.

        [BsonElement("Author")]
        public string Author { get; set; }

        [BsonElement("Content")]
        public string Content { get; set; }

        [BsonElement("Tags")]
        public DateTime CreatedAtUtc { get; set; }
    }
}