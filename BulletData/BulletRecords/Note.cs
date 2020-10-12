using System;

namespace BulletRecords
{
    public class Note : iNote
    {
        public string RecordId { get; set; }
        public NoteType NoteType { get; set; }
        public string NoteBody { get; set; }
        public DateTime? CompleteDate { get; set; }
        public DateTime? DueDate { get; set; }
        public Note(NoteType requestedType = NoteType.Default)
        {
            RecordId = new Guid().ToString();
            NoteType = requestedType;
            NoteBody = "";
        }
    }
}