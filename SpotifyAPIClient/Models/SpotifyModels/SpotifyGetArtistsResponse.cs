using Newtonsoft.Json;

namespace Spotify.Models.SpotifyModels
{
    public class SpotifyGetArtistsResponse
    {
        [JsonProperty("artists")]
        public SpotifyArtistsCatalog Artists { get; set; }
    }
}
