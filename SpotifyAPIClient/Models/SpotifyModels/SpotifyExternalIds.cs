using Newtonsoft.Json;

namespace Spotify.Models.SpotifyModels
{
    public class SpotifyExternalIds
    {
        [JsonProperty("isrc")]
        public string Isrc { get; set; }
    }
}
