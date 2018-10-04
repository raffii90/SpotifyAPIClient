using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace CloudNineAssignment.Models.SpotifyModels
{
    public class SpotifyTrack : Track
    {
        [JsonProperty("album")]
        public SpotifyAlbum Album { get; set; }

        private string _albumName;
        [JsonIgnore]
        public override string AlbumName
        {
            get
            {
                _albumName = Album.Name;
                return _albumName;
            }
            set { value = _albumName; }
        }

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
            set { value = _artists; }
        }

        [JsonProperty("available_markets")]
        public IList<string> AvailableMarkets { get; set; }

        [JsonProperty("disc_number")]
        public int DiscNumber { get; set; }

        [JsonProperty("duration_ms")]
        public override int Duration { get; set; }

        [JsonProperty("explicit")]
        public bool Explicit { get; set; }

        [JsonProperty("external_ids")]
        public SpotifyExternalIds ExternalIds { get; set; }

        [JsonProperty("external_urls")]
        public SpotifyExternalUrls ExternalUrls { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("is_local")]
        public bool IsLocal { get; set; }

        [JsonProperty("name")]
        public override string Name { get; set; }

        [JsonProperty("popularity")]
        public override int Popularity { get; set; }

        [JsonProperty("preview_url")]
        public string PreviewUrl { get; set; }

        [JsonProperty("track_number")]
        public int TrackNumber { get; set; }

        [JsonProperty("Type")]
        public string type { get; set; }

        [JsonProperty("Uri")]
        public string uri { get; set; }
    }
}
