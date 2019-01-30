using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NoteAppHomeworkRJ.Fragments;

namespace NoteAppHomeworkRJ.Activities
{
    [Activity(Label = "NoteFragmentActivity")]
    public class NoteFragmentActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var noteId = Intent.Extras.GetString("note_id");

            var detailsFrag = NoteContentFragment.NewInstance(noteId);
            FragmentManager.BeginTransaction()
                .Add(Android.Resource.Id.Content, detailsFrag)
                .Commit();
        }
    }
}