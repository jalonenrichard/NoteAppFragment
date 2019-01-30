using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using NoteAppHomeworkRJ.Activities;
using NoteAppHomeworkRJ.Helper;
using NoteAppHomeworkRJ.Model;
using NoteAppHomeworkRJ.Service;

namespace NoteAppHomeworkRJ.Fragments
{
    public class NoteTitleFragment : ListFragment
    {
        int noteId;
        private NoteService _noteService;

        public NoteTitleFragment()
        {
            // Being explicit about the requirement for a default constructor.
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Log.Info("NoteTitleFragment OnActivityCreated", "OnActivityCreated called");
            _noteService = new NoteService();
            base.OnActivityCreated(savedInstanceState);
            //Log.Info("NoteTitleFragment OnActivityCreated", $"All notes count: {_noteService.GetAllNotes().Count()}");
            /*List<string> titlesList = new List<string>();
            foreach (var note in _noteService.GetAllNotes())
            {
                titlesList.Add(note.Headline);
            }*/

            ListAdapter = new ArrayAdapter<Note>(Activity, Android.Resource.Layout.SimpleListItemActivated1,
                _noteService.GetAllNotes().ToArray());
            //Shakespeare.Titles);

            if (savedInstanceState != null)
            {
                noteId = savedInstanceState.GetInt("note_id", _noteService.GetAllNotes().ElementAt(0).Id);
                Log.Info("NoteContent", noteId.ToString());
            }
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutInt("note_id", noteId);
        }

        public override void OnListItemClick(ListView l, View v, int position, long id)
        {
            //todo: vota siit note id ja anna kaasa
            Note note = l.GetItemAtPosition(position).Cast<Note>();
            ShowNoteContent(note);
        }

        void ShowNoteContent(Note note)
        {
            var intent = new Intent(Activity, typeof(NoteFragmentActivity));
            intent.PutExtra("note_id", note.Content);
            StartActivity(intent);
        }
    }
}