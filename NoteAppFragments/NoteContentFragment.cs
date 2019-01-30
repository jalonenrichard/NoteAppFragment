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
using NoteAppHomeworkRJ.Model;
using NoteAppHomeworkRJ.Service;

namespace NoteAppHomeworkRJ.Fragments
{
    public class NoteContentFragment : Fragment
    {
        private NoteService _noteService;
        public string NoteContent => Arguments.GetString("note_id");

        public static NoteContentFragment NewInstance(string content)
        {
            var bundle = new Bundle();
            bundle.PutString("note_id", content);
            return new NoteContentFragment {Arguments = bundle};
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            if (container == null)
            {
                return null;
            }

            _noteService = new NoteService();
            var textView = new TextView(Activity);
            var padding =
                Convert.ToInt32(TypedValue.ApplyDimension(ComplexUnitType.Dip, 4, Activity.Resources.DisplayMetrics));
            textView.SetPadding(padding, padding, padding, padding);
            textView.TextSize = 24;
            textView.Text = NoteContent; //Shakespeare.Dialogue[PlayId];

            var scroller = new ScrollView(Activity);
            scroller.AddView(textView);

            return scroller;
        }
    }
}