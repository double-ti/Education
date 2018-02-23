using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;

namespace M101N.Homework2._2
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
            await Homework2_2();
        }

        private static async Task Homework2_2()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("students");
            var grades = db.GetCollection<Grade>("grades");

            var list = await grades.Find(q => q.Type == "homework").SortBy(q => q.StudentId).ThenBy(q => q.Score).ToListAsync();

            var idIsChanged = true;
            var prevId = list.First().StudentId;
            foreach (var item in list)
            {
                if (prevId != item.StudentId)
                {
                    prevId = item.StudentId;
                    idIsChanged = true;
                }

                if (!idIsChanged) continue;
                await grades.DeleteOneAsync(q => q.Id == item.Id);
                idIsChanged = false;
            }
        }
    }

    public class Grade
    {
        public ObjectId Id { get; set; }

        [BsonElement("student_id")]
        public int StudentId { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("score")]
        public double Score { get; set; }
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

