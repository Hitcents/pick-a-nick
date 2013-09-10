using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace PickANick.Core.Google
{
    public class CustomSearchService : FakeNickServer
    {
        public string Key { get; set; }

        public string CX { get; set; }

        public CustomSearchService()
        {
            Key = string.Empty;
            CX = string.Empty;
        }

        public async Task<string> Search(string query)
        {
            var httpClient = new HttpClient();
			string url = "https://www.googleapis.com/customsearch/v1?q=" + query + "&searchType=image&key=" + Key + "&cx=" + CX;
			Console.WriteLine ("Before get url");
			var result = httpClient.GetStringAsync(url).Result;
			return result;
        }

        public override async Task<Location> GetLocation(string location)
        {
			Console.WriteLine ("Before Search");
			string json = await Search(location);
			Console.WriteLine ("After get url");

            var response = JsonConvert.DeserializeObject<GoogleResponse>(json);
            var result = response.Items[0];

            return new Location
            {
                Name = result.Title,
                ImageName = result.Link,
            };
        }
    }
}
