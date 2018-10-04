using System.Collections.Generic;
using Newtonsoft.Json;

namespace CloudNineAssignment.Models.SpotifyModels
{
    public class SpotifyArtist : Artist
    {
        [JsonProperty("external_urls")]
        public SpotifyExternalUrls ExternalUrls { get; set; }

        [JsonProperty("followers")]
        public SpotifyFollowers Followers { get; set; }

        [JsonProperty("genres")]
        public override IList<string> Genres { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("images")]
        public IList<SpotifyImage> Images { get; set; }

        [JsonProperty("name")]
        public override string Name { get; set; }

        [JsonProperty("popularity")]
        public override int Popularity { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
}
