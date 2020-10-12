using NUnit.Framework;
using BulletRecords;
using BulletAPI.Models;
using BulletAPI.Services;
using System.Collections;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class IntegrationTests
    {
        IBulletToDoDatabase settings;
        BulletService service;
        private List<BulletNote> _notes;

        [SetUp]
        public void Setup()
        {
            settings = new BulletToDoDatabase
            {
                BulletCollectionName = "BulletData",
                ConnectionString = "mongodb://BulletJournal:superficiallyLongStringToPadComplexity@localhost:27020/?authSource=admin&authMechanism=SCRAM-SHA-256&readPreference=primary&ssl=false",
                DatabaseName = "BulletDB"
            };

            service = new BulletService(settings);

            _notes = new List<BulletNote>();
        }

        [Test]
        [Category("Integration")]
        public void CreateTest()
        {

            var note = new BulletNote(NoteType.TEST);
            note.NoteBody = "Testing note body";
            _notes.Add(note);

            service.Create(note);

            var noteComp = service.Get().First(nt => nt.RecordId == note.RecordId);
            Assert.NotNull(noteComp);
        }

        [Test]
        [Category("Integration")]
        public void getNoteTest()
        {
            var note = new BulletNote(NoteType.TEST);
            _notes.Add(note);

            service.Create(note);

            var noteComp = service.Get().First(nt => nt.RecordId == note.RecordId);
            Assert.IsTrue(note.RecordId == noteComp.RecordId);
        }

        [Test]
        [Category("Integration")]
        public void deleteNoteTest()
        {
            var note = new BulletNote(NoteType.TEST);
            _notes.Add(note);
            service.Create(note);

            Assert.IsTrue(service.Get().Any(nt => nt.RecordId == note.RecordId));
        }

        [Test]
        [Category("Integration")]
        public void updateNoteTest()
        {

            var note = new BulletNote(NoteType.TEST);
            note.NoteBody = "Test Note";
            _notes.Add(note);
            var newBodyText = "New Text";
            var getId = note.RecordId;

            service.Create(note);
            note.NoteBody = newBodyText;

            service.Update(getId, note);
            var comparisonNote = service.Get(getId);

            Assert.NotNull(comparisonNote);
            Assert.AreEqual(comparisonNote.NoteBody, newBodyText);
        }

        [TearDown]
        public void TearDown()
        {
            foreach (var note in service.Get().Where(nt => nt.NoteType == NoteType.TEST))
            {
                service.Remove(note);
            }

            foreach (var note in _notes)
            {
                service.Remove(note);
            }
        }
    }
}