using Android.OS;
using Android.Widget;
using FindBack.Core.Services.DataStore;
using FindBack.Core.ViewModels;

namespace FindBack.Droid.Views
{
    using global::Android.App;

    using Cirrious.MvvmCross.Droid.Views;

    using FindBack.Droid;

    [Activity(Label = "Item Details")]
    public class DetailItemView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            SetContentView(Resource.Layout.DetailItemView);
            var mapButton = FindViewById<Button>(Resource.Id.mapCmdButton);
            mapButton.Enabled = ((DetailItemViewModel)ViewModel).Item.LocationKnown;
        }
    }
}