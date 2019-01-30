﻿using Android.App;
using Android.OS;
using NoteAppFragments.Fragments;

namespace NoteAppFragments.Activities
{
    [Activity(Label = "NoteFragmentActivity")]
    class NoteFragmentActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var noteContent = Intent.Extras.GetString("note_content");

            var detailsFrag = NoteContentFragment.NewInstance(noteContent);
            FragmentManager.BeginTransaction()
                .Add(Android.Resource.Id.Content, detailsFrag)
                .Commit();
        }
    }
}