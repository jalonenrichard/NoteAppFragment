using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using NoteAppFragments.Helpers;
using NoteAppFragments.Models;
using NoteAppFragments.Services;

namespace NoteAppFragments.Activities
{
    [Activity(Label = "New Note", Theme = "@style/AppTheme")]
    internal class NewNoteActivity : Activity
    {
        private EditText _content;
        private EditText _header;
        private Button _saveButton;
        private NoteService _noteService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.noteadd_layout);

            _header = FindViewById<EditText>(Resource.Id.editTextNoteHeaderAdd);
            _content = FindViewById<EditText>(Resource.Id.editTextNoteContentAdd);
            _saveButton = FindViewById<Button>(Resource.Id.buttonNoteSave);
            _noteService = new NoteService();

            _saveButton.Click += delegate { AddNewNote(); };
        }

        private void AddNewNote()
        {
            var note = new Note {Headline = _header.Text, Content = _content.Text, CreatedDateTime = DateTime.Now};
            if (NoteChecker.NoteIsEmpty(note))
                RunOnUiThread(() =>
                    Toast.MakeText(this, "Header and Content are both empty", ToastLength.Short).Show());
            else
            {
                _noteService.SaveNote(note);
                SwitchToMainActivity();
            }
        }

        private void SwitchToMainActivity()
        {
            var mainActivity = new Intent(this, typeof(MainActivity));
            StartActivity(mainActivity);
        }
    }
}