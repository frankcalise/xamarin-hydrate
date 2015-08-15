using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace xamarinhydrate
{
    public class DataAdapter : BaseAdapter<Data>
    {
        private readonly Activity _context;

        public DataAdapter(Activity newContext, List<Data> newData) : base()
        {
            _context = newContext;
            DataList = newData;
        }

        public List<Data> DataList { get; set; }

        public override int Count
        {
            get
            {
                return DataList.Count;
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var newView = convertView ?? _context.LayoutInflater.Inflate(Resource.Layout.ListChildItem, null);

            newView.FindViewById<TextView>(Resource.Id.DataAmount).Text = DataList[position].Id;
            newView.FindViewById<TextView>(Resource.Id.DataTime).Text = DataList[position].Value;

            return newView;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Data this[int index]
        {
            get
            {
                return DataList[index];
            }
        }
    }
}

