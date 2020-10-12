using BulletAPI.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BulletAPI.Services
{
    public class BulletService
    {
        private readonly IMongoCollection<BulletNote> _notes;
        private MongoClient _client;

        public BulletService(IBulletToDoDatabase settings)
        {
            _client = new MongoClient(settings.ConnectionString);

            var database = _client.GetDatabase(settings.DatabaseName);

            _notes = database.GetCollection<BulletNote>(settings.BulletCollectionName);
        }

        public List<BulletNote> Get() =>
            _notes.Find(note => true).ToList();

        public BulletNote Get(string id) =>
            _notes.Find<BulletNote>(note => note.RecordId == id).FirstOrDefault();

        public BulletNote Create(BulletNote note)
        {
            _notes.InsertOne(note);
            return note;
        }

        public void Update(string id, BulletNote noteIn) =>
            _notes.ReplaceOne(note => note.RecordId == id, noteIn);

        public void Remove(BulletNote noteIn)
        {
            _notes.DeleteOne(note => note.RecordId == noteIn.RecordId);
        }
        public void Remove(string id) =>
            _notes.DeleteOne(note => note.RecordId.ToString() == id);
    }
}