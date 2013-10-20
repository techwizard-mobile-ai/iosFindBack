namespace FindBack.Droid.Views
{
    using global::Android.App;

    using Cirrious.MvvmCross.Droid.Views;

    using FindBack.Droid;

    [Activity(Label = "Add new Item")]
    public class AddItemView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            SetContentView(Resource.Layout.AddItemView);
        }
    }
}