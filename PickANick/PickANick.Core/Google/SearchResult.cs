using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PickANick.Core.Google
{
    [DataContract]
    public class SearchResult
    {
        [DataMember(Name = "link")]
        public string Link { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }
    }
}
