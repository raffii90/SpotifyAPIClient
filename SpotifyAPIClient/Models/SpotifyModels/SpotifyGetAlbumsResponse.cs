using Newtonsoft.Json;

namespace Spotify.Models.SpotifyModels
{
    public class SpotifyGetAlbumsResponse
    {
        [JsonProperty("albums")]
        public SpotifyAlbumsCatalog Albums { get; set; }
    }
}
