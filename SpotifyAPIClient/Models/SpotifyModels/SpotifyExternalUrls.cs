using Newtonsoft.Json;

namespace Spotify.Models.SpotifyModels
{
    public class SpotifyExternalUrls
    {
        [JsonProperty("spotify")]
        public string Spotify { get; set; }
    }
}
