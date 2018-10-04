using Newtonsoft.Json;

namespace CloudNineAssignment.Models.SpotifyModels
{
    public class SpotifyGetTracksResponse
    {
        [JsonProperty("tracks")]
        public SpotifyTracksCatalog Tracks { get; set; }
    }
}
