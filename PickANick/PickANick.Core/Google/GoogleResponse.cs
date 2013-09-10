using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PickANick.Core.Google
{
    [DataContract]
    public class GoogleResponse
    {
        [DataMember(Name = "items")]
        public SearchResult[] Items { get; set; }
    }
}
