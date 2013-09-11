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
	[Register ("LocationController")]
	partial class LocationController
	{
		[Outlet]
		MonoTouch.UIKit.UITextField _locationTextBox { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton _submitButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_locationTextBox != null) {
				_locationTextBox.Dispose ();
				_locationTextBox = null;
			}

			if (_submitButton != null) {
				_submitButton.Dispose ();
				_submitButton = null;
			}
		}
	}
}
