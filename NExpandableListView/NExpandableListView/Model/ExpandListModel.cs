using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace NExpandableListView.Model
{
    public class ExpandListModel
    {

        public string Title { get; set; }

        public int ID
        {
            get;
            set;
        }
        public int ParentID
        {
            get;
            set;
        }
        public List<ExpandListModel> Children { get; set; }
    }
}