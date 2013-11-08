// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace FindBack.Touch.Views
{
	[Register ("DetailItemView")]
	partial class DetailItemView
	{
		[Outlet]
		MonoTouch.UIKit.UIButton DeleteButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel DescritpionLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView ItemImage { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel ItemNameLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel LatitudeLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel LongitudeLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton MapButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (DeleteButton != null) {
				DeleteButton.Dispose ();
				DeleteButton = null;
			}

			if (DescritpionLabel != null) {
				DescritpionLabel.Dispose ();
				DescritpionLabel = null;
			}

			if (ItemImage != null) {
				ItemImage.Dispose ();
				ItemImage = null;
			}

			if (ItemNameLabel != null) {
				ItemNameLabel.Dispose ();
				ItemNameLabel = null;
			}

			if (LatitudeLabel != null) {
				LatitudeLabel.Dispose ();
				LatitudeLabel = null;
			}

			if (LongitudeLabel != null) {
				LongitudeLabel.Dispose ();
				LongitudeLabel = null;
			}

			if (MapButton != null) {
				MapButton.Dispose ();
				MapButton = null;
			}
		}
	}
}
