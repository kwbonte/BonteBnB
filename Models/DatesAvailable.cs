using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DatesAvailableApi.Models
{
    public class DatesAvailable
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Person")]
        public string PersonInfo {get; set;}

        [BsonElement("Date")]
        [BsonRepresentation(BsonType.DateTime, AllowTruncation=false)]
        public DateTime Date { get; set; }
    }
}



// datetime day
// string id
// string person