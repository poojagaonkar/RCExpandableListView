

This project demonstrates the creation of Multi-Level/N-Level Exapandable ListView for Android
## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

C#/.NET (Xamarin v4.0.3).

Android SDKs -- `you can install these via Tools > Android > Android SDK Manager.`

Minimum Android to target -- `Android 4.4 - API level 19`

### Installing

Add the RCExpandableListView component in your layout file

```
 <NExpandableListView.RCExpandableListView
     android:minWidth="25px"
     android:minHeight="25px"
     android:layout_width="match_parent"
     android:layout_height="match_parent"
     android:id="@+id/lvExpand"
     android:background="#ffffff"/>
```

Create a List in the Parent-Child format using the ```ExpandListModel```

```
 private List<ExpandListModel> CreateList()
        {
            var mList = new List<ExpandListModel>();
            mList.Add(new ExpandListModel { ID = 1, Title = "Level1", Children = null });
            mList.Add(new ExpandListModel { ID = 1, Title = "Level1", Children = new List<ExpandListModel> { new ExpandListModel { ID =2, Title="Level2", Children =null}, new ExpandListModel { ID = 2, Title = "Level2", Children = null } } });
            mList.Add(new ExpandListModel { ID = 1, Title = "Level1", Children = new List<ExpandListModel> { new ExpandListModel { ID = 2, Title = "Level2", Children = new List<ExpandListModel> { new ExpandListModel { ID = 3, Title = "Level3", Children = null }, new ExpandListModel { ID = 3, Title = "Level3", Children = new List<ExpandListModel> { new ExpandListModel { ID = 4, Title = "Level4", Children = null } } } } } } });
            mList.Add(new ExpandListModel { ID = 1, Title = "Level1", Children = null });

            return mList;
        }
```

Pass the List to a CustomAdapter for more control over the look and feel

```
var dummyList = CreateList();
            adapter = new CustomAdapter(this, dummyList);
            lvExpandableList.Adapter = adapter;
            lvExpandableList.ItemClick += LvExpandableList_ItemClick;
```

For Expanding and collapsing of the Menu , add the click event as :-

```

private void LvExpandableList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            lvExpandableList.ExpandRows(dummyList, e.Position, adapter);
        }
 ```


## Built With

* [Xamarin](https://www.xamarin.com/)


## Authors

* **Pooja Gaonkar** 

## License

 [Rapid Circle](http://www.rapidcircle.com/)
