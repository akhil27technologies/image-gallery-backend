using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Gallery_Backend.Models
{
    public class Image
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId MongoId { get; set; }

        public string Id { get; set; }


        public string Title { get; set; }


        public string Description { get; set; }


        public string ImagePath { get; set; }

    }
}
