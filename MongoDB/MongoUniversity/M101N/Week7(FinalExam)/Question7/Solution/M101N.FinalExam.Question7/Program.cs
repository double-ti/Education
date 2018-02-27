using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace M101N.FinalExam.Question7
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
            Console.WriteLine();
            Console.WriteLine("Press button");
            Console.ReadLine();
        }

        private static async Task MainAsync(string[] args)
        {
            await Question7();
        }

        private static async Task Question7()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("photo-sharing");
            var albums = db.GetCollection<Album>("albums");
            var images = db.GetCollection<Image>("images");

            var imageIdsFromAlbums = await albums
                .Aggregate()
                .Unwind<Album, AlbumUnwind>(x => x.Images)
                .Group(y => y.Image, z => new { Id = z.Key})
                .ToListAsync();

            var imageIdsFromImages = await images
                .Find(_ => true)
                .Project(x => new {x.Id})
                .ToListAsync();

            var idsToDelete = imageIdsFromImages.Except(imageIdsFromAlbums)
                .SelectMany(q => new List<int> {q.Id}).ToList();

            var filter = Builders<Image>.Filter.In("_id", idsToDelete);
            await images.DeleteManyAsync(filter);

            var imgSunriseTagCount = await images
                .Find(q => q.Tags.Contains("sunrises"))
                .CountAsync();

            Console.WriteLine(imgSunriseTagCount);
        }
    }

    public class Album
    {
        public int Id { get; set; }

        [BsonElement("images")]
        public int[] Images { get; set; }
    }

    public class AlbumUnwind
    {
        [BsonElement("images")]
        public int Image { get; set; }
    }

    public class Image
    {
        public int Id { get; set; }

        [BsonElement("height")]
        public int Height { get; set; }

        [BsonElement("width")]
        public int Width { get; set; }

        [BsonElement("tags")]
        public List<string> Tags { get; set; }
    }
}
