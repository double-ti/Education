using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;

namespace M101N.Homework3._1
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
            await Homework3_1();
        }

        private static async Task Homework3_1()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("school");
            var students = db.GetCollection<Student>("students");

            using (var cursor = await students.Find(new BsonDocument()).ToCursorAsync())
            {
                while (await cursor.MoveNextAsync())
                {
                    foreach (var student in cursor.Current)
                    {
                        var lowestHomeworkScore = student.Scores.Where(q => q.Type == "homework").Min(q => q.ScoreValue);
                        await students.FindOneAndUpdateAsync(
                            s => s.Id == student.Id,
                            Builders<Student>.Update.PullFilter(a => a.Scores, e => e.ScoreValue == lowestHomeworkScore));
                    }
                }
            }
        }
    }

    public class Student
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public int Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("scores")]
        public List<Score> Scores { get; set; }
    }

    public class Score
    {
        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("score")]
        public double ScoreValue { get; set; }
    }
}
