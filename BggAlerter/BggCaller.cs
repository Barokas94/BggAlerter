using System.Net.Http;
using System.Threading.Tasks;

namespace BggAlerter
{
    public class BggCaller
    {
        private readonly HttpClient _httpClient;
        private const string EndPoint = "https://boardgamegeek.com/browse/boardgame?sort=rank&rankobjecttype=subtype&rankobjectid=1";

        public BggCaller()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetBggResponse()
        {
            var response = await _httpClient.GetAsync(EndPoint);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"HTTP response code was {response.StatusCode}");
            }

            var stringResponse = await response.Content.ReadAsStringAsync();

            return stringResponse;
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
