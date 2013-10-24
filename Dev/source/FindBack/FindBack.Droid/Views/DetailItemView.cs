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
        }
    }
}