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

            return await httpClient.GetStringAsync("https://www.googleapis.com/customsearch/v1?q=" + query + "&searchType=image&key=" + Key + "&cx=" + CX);
        }

        public override async Task<Location> GetLocation(string location)
        {
            string json = await Search(location);

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
