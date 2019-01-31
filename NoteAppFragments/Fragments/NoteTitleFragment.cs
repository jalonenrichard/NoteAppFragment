using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
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
        private string _noteContent;
        bool _showingTwoFragments;

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            ListAdapter =
                new CustomAdapterVertical(Activity,
                    new NoteService()
                        .GetAllNotes()); //new ArrayAdapter<Note>(Activity, Android.Resource.Layout.SimpleListItemActivated1,
            //new NoteService().GetAllNotes().ToArray());

            if (savedInstanceState != null)
            {
                try
                {
                    _noteContent =
                        savedInstanceState.GetString("note_content",
                            new NoteService().GetAllNotes().ElementAt(0).Content);
                }
                catch (Exception e)
                {
                    Log.Error("","no notes found in db");
                }
            }

            var quoteContainer = Activity.FindViewById(Resource.Id.note_content_container);
            _showingTwoFragments = quoteContainer != null &&
                                   quoteContainer.Visibility == ViewStates.Visible;
            if (_showingTwoFragments)
            {
                ListAdapter = new CustomAdapter(Activity, new NoteService().GetAllNotes());
                ListView.ChoiceMode = ChoiceMode.Single;
                ShowNoteContent(_noteContent);
            }
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutString("note_content", _noteContent);
        }

        public override void OnListItemClick(ListView l, View v, int position, long id)
        {
            if (Resources.Configuration.Orientation != Android.Content.Res.Orientation.Landscape)
            {
                Note note = l.GetItemAtPosition(position).Cast<Note>();
                EditNoteActivity.NoteToEdit = note;
                //Log.Info(GetType().Name, $"----- Note Header: {note.Headline}, Note Content: {note.Content}");
                var intent = new Intent(Activity, typeof(EditNoteActivity));
                StartActivity(intent);
            }
            else
            {
                Note noteX = l.GetItemAtPosition(position).Cast<Note>();
                ShowNoteContent(noteX.Content);
            }
        }

        void ShowNoteContent(string noteContent)
        {
            //Note notex = ListView.GetItemAtPosition(id).Cast<Note>();
            if (_showingTwoFragments)
            {
                var noteContentFragment =
                    FragmentManager.FindFragmentById(Resource.Id.note_content_container) as NoteContentFragment;

                if (noteContentFragment == null || noteContentFragment.NoteContent != noteContent)
                {
                    Activity.FindViewById(Resource.Id.note_content_container);
                    var quoteFrag = NoteContentFragment.NewInstance(noteContent);

                    FragmentTransaction ft = FragmentManager.BeginTransaction();
                    ft.Replace(Resource.Id.note_content_container, quoteFrag);
                    ft.AddToBackStack(null);
                    ft.SetTransition(FragmentTransit.FragmentFade);
                    ft.Commit();
                }
            }
            else
            {
                var intent = new Intent(Activity, typeof(NoteFragmentActivity));
                intent.PutExtra("note_content", noteContent);
                StartActivity(intent);
            }
        }
    }
}