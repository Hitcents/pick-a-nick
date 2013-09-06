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
            new Nick { Id = 1, ImageName = "Cool Nic" },
            new Nick { Id = 2, ImageName = "Angry Nic" },
            new Nick { Id = 3, ImageName = "Surprised Nic" },
            new Nick { Id = 4, ImageName = "Sad Nic" },
			new Nick { Id = 5, ImageName = "Flirtatious Nic" },
			new Nick { Id = 6, ImageName = "Concerned Nic" },
			new Nick { Id = 7, ImageName = "Sarcastic Nic" },
			new Nick { Id = 8, ImageName = "Hysteric Nic" },
			new Nick { Id = 9, ImageName = "Insane Nic" },
			new Nick { Id = 10, ImageName = "Happy Nic" },
			new Nick { Id = 11, ImageName = "Creepy Nic" },
			new Nick { Id = 11, ImageName = "Youthful Nic" },
        };
        private Location[] _locations = new[]
        {
            new Location { Id = 1, Name = "France", ImageName = "wootFrance" },
            new Location { Id = 2, Name = "Egypt", ImageName = "egypt1" },
            new Location { Id = 3, Name = "Germany", ImageName = "germany222" },
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
