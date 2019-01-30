using System.IO;
using NoteAppFragments.Models;
using NoteAppFragments.Repositories;
using SQLite;
using Environment = System.Environment;

namespace NoteAppFragments.Services
{
    class NoteService
    {
        private readonly NoteDao _noteDao;

        public NoteService()
        {
            _noteDao = new NoteDao(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "noteDatabaseFragment.db3"));
            _noteDao.ConnectToDatabase();
        }

        internal void CreateNewNoteTable()
        {
            _noteDao.CreateNewNoteTable();
        }

        public TableQuery<Note> GetAllNotes()
        {
            return _noteDao.GetAllNotesFromDatabase();
        }

        public void SaveNote(Note note)
        {
            _noteDao.SaveNoteToDatabase(note);
        }

        public void RemoveNote(Note note)
        {
            _noteDao.RemoveNoteFromDatabase(note);
        }

        public void EditNote(Note note)
        {
            _noteDao.UpdateNoteInDatabase(note);
        }
    }
}