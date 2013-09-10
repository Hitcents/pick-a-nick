using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickANick.Core
{
    public class FakeNickServer : INickServer
    {
        private Nick[] _nicks = new[]
        {
			new Nick { Id = 1, ImageName = "coolnic.png" , Name = "Cool Nic" },
			//new Nick { Id = 2, ImageName = "angrynic.png" , Name = "Angry Nic" },
			//new Nick { Id = 3, ImageName = "surprisednic.png" , Name = "Surprised Nic" },
			new Nick { Id = 2, ImageName = "sadnic.png" , Name = "Sad Nic" },
			new Nick { Id = 3, ImageName = "flirtatiousnic.png" , Name = "Flirtatious Nic" },
			//new Nick { Id = 6, ImageName = "concernednic.png" , Name = "Concerned Nic" },
			new Nick { Id = 4, ImageName = "sarcasticnic.png" , Name = "Sarcastic Nic" },
			//new Nick { Id = 8, ImageName = "hystericnic.png" , Name = "Hysteric Nic" },
			new Nick { Id = 5, ImageName = "nicofthenight.png" , Name = "Nic of the Night" },
			//new Nick { Id = 10, ImageName = "insanenic.png" , Name = "Insane Nic" },
			new Nick { Id = 6, ImageName = "happynic.png" , Name = "Happy Nic" },
			//new Nick { Id = 11, ImageName = "supernic.png" , Name = "SuperNic" },
			new Nick { Id = 7, ImageName = "creepynic.png" , Name = "Creepy Nic" },
			new Nick { Id = 8, ImageName = "youthfulnic.png" , Name = "Youthful Nic" },
        };

        private Location[] _locations = new[]
        {
            new Location { Id = 1, Name = "France", ImageName = "parisfrance.jpg" },
            new Location { Id = 2, Name = "Egypt", ImageName = "egypt.jpg" },
			new Location { Id = 3, Name = "Germany", ImageName = "germany.png" },
			new Location { Id = 4, Name = "America", ImageName = "newyorkamerica.jpg" },
			new Location { Id = 5, Name = "England", ImageName = "londonengland.jpg" },
			new Location { Id = 6, Name = "the Internet", ImageName = "theinternet.jpg" },
			new Location { Id = 7, Name = "Bowling Green", ImageName = "bowlinggreenky.jpg" },
        };

		private Item[] _items = new[]
		{
			new Item { Id = 1, Name = "a baseball", ImageName = "baseball.jpg" },
			new Item { Id = 2, Name = "a sandwich", ImageName = "sandwich.png" },
			new Item { Id = 3, Name = "sadness", ImageName = "sadness.jpg" },
			new Item { Id = 4, Name = "only a lousy t-shirt", ImageName = "tshirt.png" },
			new Item { Id = 5, Name = "a fatal exception", ImageName = "error.jpg" },
			new Item { Id = 6, Name = "a newfound outlook on life", ImageName = "life.jpg" },
		};

        public async Task<Nick[]> GetNicks()
        {
            await Task.Delay(2000);

            return _nicks;
        }

        public virtual async Task<Location> GetLocation(string location)
        {
            await Task.Delay(2000);


			char[] arr = location.ToArray ();
			arr = Array.FindAll<char> (arr, (c => (char.IsLetter (c))));
			var location2 = new string(arr).ToLower();
			Location result = null;
			try
			{
            	result = _locations.First(l => l.ImageName.ToLower().Contains(location2));
			}
			catch(InvalidOperationException e)
			{
				Console.WriteLine (e);
			}

			if (result != null)
			{
				return result;
			}
			else
			{
				return _locations [(new Random ()).Next (0, _locations.Count ())];
			}
        }

        public async Task<Item> GetItem(int nick, int location)
        {
            await Task.Delay(2000);

            return _items[(new Random()).Next(0,(int)_items.Count())];
        }
    }
}
