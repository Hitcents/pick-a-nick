// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace PickANick.iOS
{
	[Register ("ResultController")]
	partial class ResultController
	{
		[Outlet]
		MonoTouch.UIKit.UIImageView _imageLocation { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView _imageNic { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView _imageThing { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton _restartButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel _resultText { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_imageThing != null) {
				_imageThing.Dispose ();
				_imageThing = null;
			}

			if (_imageNic != null) {
				_imageNic.Dispose ();
				_imageNic = null;
			}

			if (_imageLocation != null) {
				_imageLocation.Dispose ();
				_imageLocation = null;
			}

			if (_restartButton != null) {
				_restartButton.Dispose ();
				_restartButton = null;
			}

			if (_resultText != null) {
				_resultText.Dispose ();
				_resultText = null;
			}
		}
	}
}
