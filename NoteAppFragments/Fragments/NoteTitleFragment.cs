using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using NoteAppFragments.Activities;
using NoteAppFragments.Helpers;
using NoteAppFragments.Models;
using NoteAppFragments.Services;

namespace NoteAppFragments.Fragments
{
    public class NoteTitleFragment : ListFragment
    {
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            ListAdapter = new ArrayAdapter<Note>(Activity, Android.Resource.Layout.SimpleListItemActivated1,
                new NoteService().GetAllNotes().ToArray());
        }

        public override void OnListItemClick(ListView l, View v, int position, long id)
        {
            Note note = l.GetItemAtPosition(position).Cast<Note>();
            ShowNoteContent(note);
        }

        void ShowNoteContent(Note note)
        {
            var intent = new Intent(Activity, typeof(NoteFragmentActivity));
            intent.PutExtra("note_content", note.Content);
            StartActivity(intent);
        }
    }
}