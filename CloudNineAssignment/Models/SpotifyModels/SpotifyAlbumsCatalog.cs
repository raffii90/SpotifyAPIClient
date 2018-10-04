using System.Collections.Generic;
using Newtonsoft.Json;

namespace CloudNineAssignment.Models.SpotifyModels
{
    public class SpotifyAlbumsCatalog
    {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("items")]
        public IList<SpotifyAlbum> Items { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("previous")]
        public object Previous { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }
}
