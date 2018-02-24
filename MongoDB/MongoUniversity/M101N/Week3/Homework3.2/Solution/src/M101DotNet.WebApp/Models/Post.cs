using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace M101DotNet.WebApp.Models
{
    public class Post
    {
        // XXX WORK HERE
        // add in the appropriate properties for a post
        // The homework instructions contain the schema.

        public ObjectId Id { get; set; }

        [BsonElement("Author")]
        public string Author { get; set; }

        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("Content")]
        public string Content { get; set; }

        [BsonElement("Tags")]
        public string[] Tags { get; set; }

        [BsonElement("CreatedAtUtc")]
        public DateTime CreatedAtUtc { get; set; }

        [BsonElement("Comments")]
        public List<Comment> Comments { get; set; }
    }
}