using Newtonsoft.Json;

namespace Spotify.Models.SpotifyModels
{
    public class SpotifyGetTracksResponse
    {
        [JsonProperty("tracks")]
        public SpotifyTracksCatalog Tracks { get; set; }
    }
}
