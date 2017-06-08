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
using NExpandableListView.Model;

namespace NExpandableListView
{
    public class RCExpandableListView : ListView
    {
        private bool previousExpanded;

        public RCExpandableListView(Context context) : base(context)
        {
            AppHelper.clinicalDocsList = new HashSet<ExpandListModel>();

        }

        public RCExpandableListView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public RCExpandableListView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
        }


        public void ExpandRows(List<ExpandListModel> expandList, int position, BaseAdapter adapter)
        {
            var newCellId = expandList.ElementAt(position);
            //if (!string.IsNullOrEmpty(newCellId.Field) && !string.IsNullOrEmpty(newCellId.Value)))
            //{
            //    AppHelper.clinicalDocsList.Add(newCellId);
            //}
            if (newCellId != null && newCellId.Children != null && newCellId.Children.Count > 0)
            {

                bool isAlreadyInserted = false;

                foreach (var mdata in newCellId.Children)
                {
                    var mIndex = expandList.IndexOf(mdata);
                    if (mIndex > 0)
                    {
                        isAlreadyInserted = true;
                    }
                }

                if (isAlreadyInserted)
                {
                    MinimizeRows(newCellId.Children, expandList, adapter);
                }
                else
                {
                    var count = expandList.IndexOf(newCellId) + 1;
                    var indexPaths = new List<int>();
                    foreach (var data in newCellId.Children)
                    {

                        expandList.Insert(count++, data);
                    }
                    adapter.NotifyDataSetChanged();
                }
            }

        }


        private void MinimizeRows(List<ExpandListModel> children, List<ExpandListModel> expandList, BaseAdapter adapter)
        {
            foreach (var data in children)
            {
                var indexToRemove = expandList.IndexOf(data);
                var arrInner = data.Children;
                if (arrInner != null && arrInner.Count > 0)
                {
                    MinimizeRows(arrInner, expandList, adapter);
                }
                if (expandList.IndexOf(data) > -1)
                {
                    expandList.Remove(data);
                }
            }
            adapter.NotifyDataSetChanged();
        }

    }

    public static class AppHelper
    {
        internal static HashSet<ExpandListModel> clinicalDocsList;
    }
}
