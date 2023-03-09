using System.Text.Json;
using System.Diagnostics;
using Emo.Models;

namespace Emo.Services
{
    public class RestService
    {
        HttpClient Client;
        JsonSerializerOptions SerializerOptions;
        public RestService()
        {
            Client = new HttpClient();
            SerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<Emote>> FetchAllEmotesAsync()
        {
            var emotes = new List<Emote>();

            try
            {
                HttpResponseMessage Response = await Client.GetAsync("https://api.betterttv.net/3/emotes/shared/search?query=feels&offset=0&limit=50");
                if (Response.IsSuccessStatusCode)
                {
                    string content = await Response.Content.ReadAsStringAsync();
                    emotes = JsonSerializer.Deserialize<List<Emote>>(content, SerializerOptions);
                    foreach (var emote in emotes)
                    {
                        emote.Url = $"https://cdn.betterttv.net/emote/{emote.Id}/3x.{emote.ImageType}";
                    }
                }
            } catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return emotes;
        }
    }
}
