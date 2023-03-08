using System.Text.Json;
using System.Diagnostics;
using Emo.Models;

namespace Emo.Services
{
    public class RestService : IRestService
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;
        public List<Emote> Emotes { get; private set; }

        public RestService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<Emote>> FetchAllEmotesAsync()
        {
            Emotes = new List<Emote>();

            try
            {
                HttpResponseMessage response = await _client.GetAsync("https://api.betterttv.net/3/emotes/shared/search?query=feels&offset=0&limit=50");
                if ( response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Emotes = JsonSerializer.Deserialize<List<Emote>>(content, _serializerOptions);
                }
            } catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Emotes;

        }
    }
}
