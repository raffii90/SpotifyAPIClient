using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace CloudNineAssignment.Models.SpotifyModels
{
    public class SpotifyAlbum : Album
    {
        [JsonProperty("album_type")]
        public override string Type { get; set; }

        [JsonProperty("artists")]
        public IList<SpotifyPlainArtist> SpotifyArtists { get; set; }

        private IList<string> _artists;
        [JsonIgnore]
        public override IList<string> Artists
        {
            get
            {
                _artists = SpotifyArtists.Select(x => x.Name).ToList();
                return _artists;
            }
            set { _artists = value; }
        }

        [JsonProperty("available_markets")]
        public IList<string> AvailableMarkets { get; set; }

        [JsonProperty("external_urls")]
        public SpotifyExternalUrls ExternalUrls { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("images")]
        public IList<SpotifyImage> Images { get; set; }

        [JsonProperty("name")]
        public override string Name { get; set; }

        [JsonProperty("release_date")]
        public override DateTime ReleaseDate { get; set; }

        [JsonProperty("release_date_precision")]
        public string ReleaseDatePrecision { get; set; }

        [JsonProperty("total_tracks")]
        public override int NumberOfTracks { get; set; }

        [JsonProperty("type")]
        public string SpotifyType { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
}
