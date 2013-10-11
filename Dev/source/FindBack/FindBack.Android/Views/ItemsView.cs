namespace FindBack.Android.Views
{
    using Cirrious.MvvmCross.Droid.Views;

    using FindBack.Core.ViewModels;

    using global::Android.App;

    [Activity(Label = "My Items", MainLauncher = true)]
    public class ItemsView : MvxActivity
    {
        public new ItemsViewModel ViewModel
        {
            get { return (ItemsViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            SetContentView(Resource.Layout.ItemsView);
        }
    }
}