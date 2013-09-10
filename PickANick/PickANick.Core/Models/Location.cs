using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickANick.Core
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }
		public bool Local { get; set; }
    }
}
