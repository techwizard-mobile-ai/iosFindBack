using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace FindBack.Touch.Views
{
    using System.Collections.Generic;

    using Cirrious.MvvmCross.Binding.BindingContext;
    using Cirrious.MvvmCross.Touch.Views;

    using FindBack.Core.ViewModels;

    public partial class AddItemView : MvxViewController
	{
		public AddItemView () : base ("AddItemView", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

            NavigationItem.Title = "Add item";

            var set = this.CreateBindingSet<AddItemView, AddItemViewModel>();
            set.Bind(ItemNameText.Text).To(item => item.ItemName);
            set.Bind(DescriptionText.Text).To(item => item.Description);
            set.Apply();

            //this.CreateBinding(TakePictureButton).To((AddItemViewModel item) => item.SaveCommand).Apply();
            this.AddBindings(new Dictionary<object, string>()
            {
                { TakePictureButton, "Clicked SaveCommand" },
            });

		}
	}
}

