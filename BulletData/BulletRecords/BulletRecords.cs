using System;

namespace BulletRecords
{
    public interface iNote
    {
        string RecordId { get; set; }
        NoteType NoteType { get; set; }
        string NoteBody { get; set; }
        DateTime? CompleteDate { get; set; }
        DateTime? DueDate { get; set; }
    }

    public interface iPage
    {

    }
    public interface iThread
    {

    }

    public interface iBook
    {

    }
    public enum NoteType
    {
        Note, ScheduledNote, ToDo, Delegated, Done, Default, TEST
    }
}