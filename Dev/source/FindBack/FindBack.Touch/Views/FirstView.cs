using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace FindBack.Touch.Views
{
    using Cirrious.MvvmCross.Binding.Touch.Views;

    using FindBack.Core.ViewModels;

    [Register("FirstView")]
    public class FirstView : MvxTableViewController
    {
        public override void ViewDidLoad()
        {
            // View = new UIView(){ BackgroundColor = UIColor.White};
            base.ViewDidLoad();

			// ios7 layout
            //if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
            //   EdgesForExtendedLayout = UIRectEdge.None;


            var source = new MvxStandardTableViewSource(TableView, "ItemName ItemName; ");
            TableView.Source = source;

            var set = this.CreateBindingSet<FirstView, ItemsViewModel>();
            set.Bind(source).To(vm => vm.Items);
            set.Apply();

            TableView.ReloadData();
            //var label = new UILabel(new RectangleF(10, 10, 300, 40));
            //Add(label);
            //var textField = new UITextField(new RectangleF(10, 50, 300, 40));
            //Add(textField);

            //var set = this.CreateBindingSet<ItemsView, Core.ViewModels.ItemsViewModel>();
            //set.Bind(label).To(vm => vm.TotalCount);
            //set.Bind(textField).To(vm => vm.TotalCount);
            //set.Apply();
        }
    }
}