using Newtonsoft.Json;

namespace Spotify.Models.SpotifyModels
{
    public class SpotifyFollowers
    {
        [JsonProperty("href")]
        public object Href { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }
}
