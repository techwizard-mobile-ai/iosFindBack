using Cirrious.MvvmCross.Binding.Touch.Views;

namespace FindBack.Touch.Views
{
	using MonoTouch.UIKit;
	using System.Collections.Generic;
	using Cirrious.MvvmCross.Binding.BindingContext;
	using Cirrious.MvvmCross.Touch.Views;
	using FindBack.Core.ViewModels;

	public partial class DetailItemView : MvxViewController
	{
		public DetailItemView () : base ("DetailItemView", null)
		{
		}

		private MvxImageViewLoader imageViewLoader;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			NavigationItem.Title = "Item detail";

			this.imageViewLoader = new MvxImageViewLoader (() => this.ItemImage);

			var set = this.CreateBindingSet<DetailItemView, DetailItemViewModel> ();
			set.Bind (ItemNameLabel).To (item => item.Item.ItemName);
			set.Bind (DescritpionLabel).To (item => item.Item.Description);
			set.Bind (LongitudeLabel).To (item => item.Item.Longitude).WithConversion ("LongitudeCoordinate");
			set.Bind (LatitudeLabel).To (item => item.Item.Latitude).WithConversion ("LatitudeCoordinate");
			set.Bind (this.imageViewLoader).To (vm => vm.Item.ImagePath);
			set.Apply ();

			this.AddBindings (new Dictionary<object, string> () {
				{ DeleteButton, "TouchUpInside DeleteCommand" },
				{ MapButton, "TouchUpInside MapCommand" },
			});

		}
	}
}

