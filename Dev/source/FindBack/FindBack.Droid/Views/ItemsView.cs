namespace FindBack.Droid.Views
{
    using Cirrious.MvvmCross.Droid.Views;

    using FindBack.Droid;

    using global::Android.App;

    [Activity(Label = "My Items")]
    public class ItemsView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            SetContentView(Resource.Layout.ItemsView);
        }
    }
}