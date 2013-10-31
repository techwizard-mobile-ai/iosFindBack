using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace FindBack.Touch.Views
{
	using System.Collections.Generic;
	using Cirrious.MvvmCross.Binding.BindingContext;
	using Cirrious.MvvmCross.Binding.Bindings;
	using Cirrious.MvvmCross.Binding.Touch.Views;
	using Cirrious.MvvmCross.Touch.Views;
	using FindBack.Core.ViewModels;
	using FindBack.Touch.Views;

	[Register ("ItemsView")]
	public partial class ItemsView : MvxTableViewController
	{
		public override void ViewDidLoad ()
		{
			// View = new UIView(){ BackgroundColor = UIColor.White};
			base.ViewDidLoad ();

			// ios7 layout
			//if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
			//   EdgesForExtendedLayout = UIRectEdge.None;

			var s = new UIBarButtonItem () {
				Title = "Add item"
			};

			NavigationItem.SetRightBarButtonItem (s, false);

			NavigationItem.Title = "Find Back";

            var source = new MvxStandardTableViewSource(TableView, "TitleText ItemName;ImageUrl ImagePath");
			TableView.Source = source;

			var set = this.CreateBindingSet<ItemsView, ItemsViewModel> ();
			set.Bind (source).To (vm => vm.Items);
			//set.Bind(s.Clicked).To(vm => vm.AddItemCommand);
			set.Apply ();

			//this.AddBinding(s, new MvxBindingDescription("",));

			this.AddBindings (new Dictionary<object, string> () {
				{ s, "Clicked AddItemCommand" },
            });
    
            
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