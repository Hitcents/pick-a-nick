using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickANick.Core.ViewModels
{
    public class NickViewModel
    {
        private readonly INickServer _server = ServiceContainer.Resolve<INickServer>();
        private bool _isBusy = false;

        public event EventHandler IsBusyChanged = delegate { };

        public Nick[] Nicks
        {
            get;
            private set;
        }

        public Nick PickedNick
        {
            get;
            set;
        }

        public string LocationSearch
        {
            get;
            set;
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            private set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    IsBusyChanged(this, EventArgs.Empty);
                }
            }
        }

        public Location Location
        {
            get;
            private set;
        }

        public Item Item
        {
            get;
            private set;
        }

		public string GreetingString
		{
			get;
			private set;
		}

		public string ResultString
		{
			get;
			private set;
		}

        public async Task GetNicks()
        {
            IsBusy = true;
            try
            {
                Nicks = await _server.GetNicks();
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task GetLocation()
        {
            if (PickedNick == null)
                throw new Exception("No Nick picked!");
            if (string.IsNullOrEmpty(LocationSearch))
                throw new Exception("No location!");

            IsBusy = true;
            try
            {
                Location = await _server.GetLocation(LocationSearch);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task GetItem()
        {
            if (PickedNick == null)
                throw new Exception("No Nick picked!");
            if (Location == null)
                throw new Exception("No location!");

            IsBusy = true;
            try
            {
                Item = await _server.GetItem(PickedNick.Id, Location.Id);
            }
            finally
            {
                IsBusy = false;
            }
		}

		public void GetStrings()
		{
			if (PickedNick == null)
				throw new Exception("No Nick picked!");
			if (Location == null)
				throw new Exception("No location!");
			if (Item == null)
				throw new Exception("No item!");

			IsBusy = true;

			GreetingString = "Greetings from " + LocationSearch + "!";
			if (Location.Local)
			{
				ResultString = PickedNick.Name + " went to " + Location.Name + " and brought back " + Item.Name +"!";
			}
			else
			{
				ResultString = PickedNick.Name + " went to " + LocationSearch + " and brought back " + Item.Name +"!";
			}
			IsBusy = false;
		}
    }
}
