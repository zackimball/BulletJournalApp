using System;
using System.Net;
using BulletRecords;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BulletAPI.Models
{
    public class BulletNote : BulletRecords.iNote
    {
        [BsonId]
        public string RecordId { get; set; }
        public NoteType NoteType { get; set; }
        public string NoteBody { get; set; }
        public DateTime? CompleteDate { get; set; }
        public DateTime? DueDate { get; set; }
        public BulletNote(BulletRecords.NoteType requestedType = BulletRecords.NoteType.Default)
        {
            RecordId = Guid.NewGuid().ToString();
            NoteType = requestedType;
            NoteBody = "";
            var client = new MongoDB.Driver.MongoClient();
        }
    }
}