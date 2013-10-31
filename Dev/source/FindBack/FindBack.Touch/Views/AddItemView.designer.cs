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
	[Register ("AddItemView")]
	partial class AddItemView
	{
		[Outlet]
		MonoTouch.UIKit.UITextView DescriptionText { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView ItemImage { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField ItemText { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel PositionLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton SaveButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton TakePictureButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (DescriptionText != null) {
				DescriptionText.Dispose ();
				DescriptionText = null;
			}

			if (ItemImage != null) {
				ItemImage.Dispose ();
				ItemImage = null;
			}

			if (ItemText != null) {
				ItemText.Dispose ();
				ItemText = null;
			}

			if (PositionLabel != null) {
				PositionLabel.Dispose ();
				PositionLabel = null;
			}

			if (TakePictureButton != null) {
				TakePictureButton.Dispose ();
				TakePictureButton = null;
			}

			if (SaveButton != null) {
				SaveButton.Dispose ();
				SaveButton = null;
			}
		}
	}
}
