namespace FindBack.Android.Views
{
    using Cirrious.MvvmCross.Droid.Views;

    using global::Android.App;

    [Activity(Label = "My Items", MainLauncher = true)]
    public class ItemsView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            SetContentView(Resource.Layout.ItemsView);
        }
    }
}