using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.Design.Widget;

namespace xamarinhydrate
{
    [Activity(
        Label = "xamarin-hydrate",
        MainLauncher = true,
        Icon = "@drawable/icon",
        Theme = "@style/Theme.AppCompat.Light.DarkActionBar")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

			var progressText = FindViewById<TextView>(Resource.Id.progressText);

            // Floating Action Button
            var actionButton = FindViewById<FloatingActionButton>(Resource.Id.ActionButton);
            actionButton.Click += (sender, e) => 
				Toast.MakeText(this, "Action tapped!", ToastLength.Short).Show();

            // Inflate the list sticky header layout
            var inflater = (LayoutInflater)this.GetSystemService(Context.LayoutInflaterService);
			var stickyView = FindViewById<TextView>(Resource.Id.stickyView);
            var stickyHeaderView = inflater.Inflate(Resource.Layout.ListStickyHeader, null);
            var spacer = stickyHeaderView.FindViewById<Space>(Resource.Id.stickyViewPlaceholder);

            // Get the expandable list view from the layout resource
            var expListView = FindViewById<ExpandableListView>(Resource.Id.historyExpListView);

            // Add the header to the list view
            expListView.AddHeaderView(stickyHeaderView);

            // Handle list view scroll events
            expListView.Scroll += (sender, e) =>
            {
                    if (expListView.FirstVisiblePosition == 0)
                    {
                        var firstChild = expListView.GetChildAt(0);
                        var topY = 0;
                        if (firstChild != null)  
                        {
                            topY = firstChild.Top;
                        }

                        var spacerTopY = spacer.Top;
						stickyView.SetY(Math.Max(0, spacerTopY + topY));

						// Set the progress text to scroll half the amount of the listview
						progressText.SetY(topY * 0.5f);
                    }
            };

            // Populate the list with sample data
            expListView.SetAdapter(new ExpandableDataAdapter(this, Data.SampleData()));

        }
    }
}


