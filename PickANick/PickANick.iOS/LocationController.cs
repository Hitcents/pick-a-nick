// This file has been autogenerated from a class added in the UI designer.

using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using PickANick.Core.ViewModels;
using PickANick.Core;

namespace PickANick.iOS
{
	public partial class LocationController : UIViewController
	{
		private readonly NickViewModel _nickViewModel = ServiceContainer.Resolve<NickViewModel>();
		public LocationController (IntPtr handle) : base (handle)
		{

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			_submitButton.TouchUpInside += (sender, e) => {
				_nickViewModel.LocationSearch = _locationTextBox.Text;
				PerformSegue ("ResultController", this);
			};
		}
	}
}
