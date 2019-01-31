using System.Collections.Generic;
using System.IO;
using System.Linq;
using NoteAppFragments.Models;
using NoteAppFragments.Repositories;
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

        public List<Note> GetAllNotes()
        {
            List<Note> allNotes = _noteDao.GetAllNotesFromDatabase().ToList();
            List<Note> sortedList = allNotes.OrderByDescending(o => o.CreatedDateTime).ToList();
            return sortedList;
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