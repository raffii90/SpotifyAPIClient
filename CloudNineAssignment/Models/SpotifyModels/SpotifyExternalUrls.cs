using Newtonsoft.Json;

namespace CloudNineAssignment.Models.SpotifyModels
{
    public class SpotifyExternalUrls
    {
        [JsonProperty("spotify")]
        public string Spotify { get; set; }
    }
}
