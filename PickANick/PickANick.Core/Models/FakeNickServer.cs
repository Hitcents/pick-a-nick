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
            new Location { Id = 1, Name = "France", ImageName = "wootFrance.jpg" },
            new Location { Id = 2, Name = "Egypt", ImageName = "egypt1.jpg" },
            new Location { Id = 3, Name = "Germany", ImageName = "germany222.png" },
        };

        public async Task<Nick[]> GetNicks()
        {
            await Task.Delay(2000);

            return _nicks;
        }

        public async Task<Location> GetLocation(string location)
        {
            await Task.Delay(2000);

            location = location.ToLower();
            return _locations.First(l => l.Name.ToLower().Contains(location));
        }

        public async Task<Item> GetItem(int nick, int location)
        {
            await Task.Delay(2000);

            return new Item { Id = 1, Name = "Baseball", ImageName = "base" };
        }
    }
}
