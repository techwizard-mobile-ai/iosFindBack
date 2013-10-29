// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace FindBack.Touch
{
	[Register ("AddItemView")]
	partial class AddItemView
	{
		[Outlet]
		MonoTouch.UIKit.UITextView DescriptionText { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView ItemImage { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField ItemNameText { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel PositionLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton TakePictureButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (ItemNameText != null) {
				ItemNameText.Dispose ();
				ItemNameText = null;
			}

			if (DescriptionText != null) {
				DescriptionText.Dispose ();
				DescriptionText = null;
			}

			if (ItemImage != null) {
				ItemImage.Dispose ();
				ItemImage = null;
			}

			if (TakePictureButton != null) {
				TakePictureButton.Dispose ();
				TakePictureButton = null;
			}

			if (PositionLabel != null) {
				PositionLabel.Dispose ();
				PositionLabel = null;
			}
		}
	}
}
