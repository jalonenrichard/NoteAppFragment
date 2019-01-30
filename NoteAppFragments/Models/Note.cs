using System;
using SQLite;

namespace NoteAppFragments.Models
{
    public class Note
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("_id")]
        public int Id { get; set; }

        public string Headline { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public override string ToString()
        {
            return Headline;
        }
    }
}