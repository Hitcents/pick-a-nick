using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using PickANick.Core.ViewModels;
using PickANick.Core;

namespace PickANick.iOS
{
	public partial class MainController : UIViewController
	{
        private readonly NickViewModel _nickViewModel = ServiceContainer.Resolve<NickViewModel>();

		public MainController (IntPtr handle) : base (handle)
		{
            _nickViewModel.IsBusyChanged += (sender, e) => 
            {

            };
		}

        public async override void ViewDidLoad()
        {
			base.ViewDidLoad();
			_nickTable.Source = new TableSource (this);

            await _nickViewModel.GetNicks();

            //TODO: reload table here
			_nickTable.ReloadData ();
        }

        private class TableSource : UITableViewSource
        {
            private readonly NickViewModel _nickViewModel = ServiceContainer.Resolve<NickViewModel>();
			
			private UIViewController _controller;

			public TableSource (UIViewController controller)
			{
				_controller = controller;
			}

            public override int RowsInSection(UITableView tableview, int section)
            {
                return _nickViewModel.Nicks == null ? 0 : _nickViewModel.Nicks.Length;
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var nick = _nickViewModel.Nicks [indexPath.Row];
                
				var cell = tableView.DequeueReusableCell ("nickcell");
				cell.TextLabel.Text = nick.ImageName;
				return cell;
            }

            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
                var nick = _nickViewModel.Nicks [indexPath.Row];
                _nickViewModel.PickedNick = nick;

				_controller.PerformSegue ("LocationController", this);
                //TODO: show the next screen
            }
        }
	}
}
