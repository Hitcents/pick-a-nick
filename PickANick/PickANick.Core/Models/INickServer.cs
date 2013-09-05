using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickANick.Core
{
    public interface INickServer
    {
        Task<Nick[]> GetNicks();

        Task<Location> GetLocation(string location);

        Task<Item> GetItem(int nick, int location);
    }
}
