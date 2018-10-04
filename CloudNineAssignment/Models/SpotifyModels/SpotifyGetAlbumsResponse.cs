using Newtonsoft.Json;

namespace CloudNineAssignment.Models.SpotifyModels
{
    public class SpotifyGetAlbumsResponse
    {
        [JsonProperty("albums")]
        public SpotifyAlbumsCatalog Albums { get; set; }
    }
}
