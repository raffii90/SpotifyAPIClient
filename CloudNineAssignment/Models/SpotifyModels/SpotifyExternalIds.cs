using Newtonsoft.Json;

namespace CloudNineAssignment.Models.SpotifyModels
{
    public class SpotifyExternalIds
    {
        [JsonProperty("isrc")]
        public string Isrc { get; set; }
    }
}
