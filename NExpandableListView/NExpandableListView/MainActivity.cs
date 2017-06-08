using Android.App;
using Android.Widget;
using Android.OS;
using System;
using NExpandableListView.Model;
using System.Collections.Generic;
using Android.Views;
using Java.Lang;
using System.Linq;

namespace NExpandableListView
{
    [Activity(Label = "NExpandableListView", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private CustomAdapter adapter;
        private List<ExpandListModel> dummyList;
        private RCExpandableListView lvExpandableList;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            lvExpandableList = FindViewById<RCExpandableListView>(Resource.Id.lvExpand);

            dummyList = CreateList();
            adapter = new CustomAdapter(this, dummyList);
            lvExpandableList.Adapter = adapter;
            lvExpandableList.ItemClick += LvExpandableList_ItemClick;
        }

        private List<ExpandListModel> CreateList()
        {
            var mList = new List<ExpandListModel>();
            mList.Add(new ExpandListModel { ID = 1, Title = "Level1", Children = null });
            mList.Add(new ExpandListModel { ID = 1, Title = "Level1", Children = new List<ExpandListModel> { new ExpandListModel { ID =2, Title="Level2", Children =null}, new ExpandListModel { ID = 2, Title = "Level2", Children = null } } });
            mList.Add(new ExpandListModel { ID = 1, Title = "Level1", Children = new List<ExpandListModel> { new ExpandListModel { ID = 2, Title = "Level2", Children = new List<ExpandListModel> { new ExpandListModel { ID = 3, Title = "Level3", Children = null }, new ExpandListModel { ID = 3, Title = "Level3", Children = null } } } } });
            mList.Add(new ExpandListModel { ID = 1, Title = "Level1", Children = null });

            return mList;
        }

        private void LvExpandableList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            lvExpandableList.ExpandRows(dummyList, e.Position, adapter);
        }

        private class CustomAdapter : BaseAdapter
        {
            private List<ExpandListModel> dummyList;
            private MainActivity mainActivity;

            public CustomAdapter(MainActivity mainActivity, List<ExpandListModel> dummyList)
            {
                this.mainActivity = mainActivity;
                this.dummyList = dummyList;
            }

            public override int Count
            {
                get
                {
                    return dummyList.Count;
                }
            }

            public override Java.Lang.Object GetItem(int position)
            {
                return position;
            }

            public override long GetItemId(int position)
            {
                return position;
            }

            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                var textLabel = new TextView(mainActivity);
                textLabel.Text = dummyList.ElementAt(position).Title;
                
                switch(dummyList.ElementAt(position).ID)
                {
                    case 1:
                        textLabel.SetBackgroundResource(Android.Resource.Color.HoloBlueLight);
                        textLabel.TextSize = 15;
                        break;
                    case 2:
                        textLabel.SetBackgroundResource(Android.Resource.Color.HoloGreenLight);
                        textLabel.TextSize = 30;
                        break;
                    case 3:
                        textLabel.SetBackgroundResource(Android.Resource.Color.HoloOrangeLight);
                        textLabel.TextSize = 50;
                        break;
                } 
                return textLabel;
            }
        }
    }
}

