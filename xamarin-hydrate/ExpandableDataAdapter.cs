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
    public class ExpandableDataAdapter : BaseExpandableListAdapter
    {
        private readonly Activity _context;

        public ExpandableDataAdapter(Activity newContext, List<Data> newList) : base()
        {
            _context = newContext;
            DataList = newList;
        }

        protected List<Data> DataList { get; set; }

        #region implemented abstract members of BaseExpandableListAdapter

        public override Java.Lang.Object GetChild(int groupPosition, int childPosition)
        {
            throw new NotImplementedException();
        }

        public override long GetChildId(int groupPosition, int childPosition)
        {
            return childPosition;
        }

        public override int GetChildrenCount(int groupPosition)
        {
            var letter = (char)(65 + groupPosition);
            var results = DataList.FindAll((Data obj) => obj.Id[0].Equals(letter));

            return results.Count;
        }

        public override View GetChildView(int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
        {
            var row = convertView ?? _context.LayoutInflater.Inflate(Resource.Layout.ListChildItem, null);

            string newId = "";
            string newValue = "";
            GetChildViewHelper(groupPosition, childPosition, out newId, out newValue);

            row.FindViewById<TextView>(Resource.Id.DataAmount).Text = newId;
            row.FindViewById<TextView>(Resource.Id.DataTime).Text = newValue;

            return row;
        }

        public override Java.Lang.Object GetGroup(int groupPosition)
        {
            throw new NotImplementedException();
        }

        public override long GetGroupId(int groupPosition)
        {
            return groupPosition;
        }

        public override View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
        {
            var header = convertView ?? _context.LayoutInflater.Inflate(Resource.Layout.ListHeaderItem, null);

            header.FindViewById<TextView>(Resource.Id.ItemHeader).Text = ((char)(65 + groupPosition)).ToString();

            return header;
        }

        public override bool IsChildSelectable(int groupPosition, int childPosition)
        {
            return false;
        }

        public override int GroupCount
        {
            get
            {
                return 26;
            }
        }

        public override bool HasStableIds
        {
            get
            {
                return true;
            }
        }

        #endregion

        private void GetChildViewHelper(int groupPosition, int childPosition, out string Id, out string Value)
        {
            var letter = (char)(65 + groupPosition);
            var results = DataList.FindAll((Data obj) => obj.Id[0].Equals(letter));
            Id = results[childPosition].Id;
            Value = results[childPosition].Value;
        }
    }
}

