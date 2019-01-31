using System;
using Android.App;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace NoteAppFragments.Fragments
{
    public class NoteContentFragment : Fragment
    {
        public string NoteContent => Arguments.GetString("note_content");

        public static NoteContentFragment NewInstance(string content)
        {
            var bundle = new Bundle();
            bundle.PutString("note_content", content);
            return new NoteContentFragment {Arguments = bundle};
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            if (container == null)
            {
                return null;
            }

            var textView = new TextView(Activity);
            var padding =
                Convert.ToInt32(TypedValue.ApplyDimension(ComplexUnitType.Dip, 4, Activity.Resources.DisplayMetrics));
            textView.SetPadding(25, 25, padding, padding);
            textView.TextSize = 20;
            textView.Text = NoteContent;

            var scroller = new ScrollView(Activity);
            scroller.AddView(textView);

            return scroller;
        }
    }
}