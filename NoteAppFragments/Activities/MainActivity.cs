using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using NoteAppFragments.Services;

namespace NoteAppFragments.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            var noteService = new NoteService();
            noteService.CreateNewNoteTable();
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            if (Resources.Configuration.Orientation != Android.Content.Res.Orientation.Landscape)
            {
                var newNoteButton = FindViewById<Button>(Resource.Id.buttonNewNote);
                newNoteButton.Click += delegate
                {
                    var editNoteActivity = new Intent(this, typeof(NewNoteActivity));
                    StartActivity(editNoteActivity);
                };
            }
        }
    }
}