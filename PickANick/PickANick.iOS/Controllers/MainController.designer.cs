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
	[Register ("MainController")]
	partial class MainController
	{
		[Outlet]
		MonoTouch.UIKit.UITableView _nickTable { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_nickTable != null) {
				_nickTable.Dispose ();
				_nickTable = null;
			}
		}
	}
}
