using NUnit.Framework;
using BulletRecords;

namespace Tests
{
    public class Tests
    {
        iNote note;
        [SetUp]
        public void Setup()
        {
            note = new Note();
        }

        [Test]
        [Category("Unit")]
        public void NoteDefaultsTest()
        {
            Assert.IsNotNull(note.RecordId);
            Assert.IsInstanceOf(typeof(System.Guid), note.RecordId);
            Assert.IsInstanceOf(typeof(NoteType), note.NoteType);
            Assert.AreEqual(NoteType.Default, note.NoteType);
            Assert.IsNull(note.DueDate);
            Assert.IsNull(note.CompleteDate);
            Assert.IsNotNull(note.NoteBody);
        }
    }
}