using Newtonsoft.Json;

namespace CloudNineAssignment.Models.SpotifyModels
{
    public class SpotifyGetArtistsResponse
    {
        [JsonProperty("artists")]
        public SpotifyArtistsCatalog Artists { get; set; }
    }
}
