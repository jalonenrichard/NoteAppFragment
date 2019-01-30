using NoteAppFragments.Models;

namespace NoteAppFragments.Helpers
{
    public static class NoteChecker
    {
        public static bool NoteIsEmpty(Note note)
        {
            return note.Headline.Trim() == string.Empty && note.Content.Trim() == string.Empty;
        }
    }
}