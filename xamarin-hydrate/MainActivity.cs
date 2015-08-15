using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace xamarinhydrate
{
    [Activity(Label = "xamarin-hydrate", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get the expandable list view from the layout resource
            // and attach the adapter to it
            var expListView = FindViewById<ExpandableListView>(Resource.Id.historyExpListView);
            expListView.SetAdapter(new ExpandableDataAdapter(this, Data.SampleData()));
        }
    }
}


