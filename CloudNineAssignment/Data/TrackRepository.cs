using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CloudNineAssignment.Interfaces;
using CloudNineAssignment.Models;
using CloudNineAssignment.Models.SpotifyModels;
using Flurl;
using Newtonsoft.Json;

namespace CloudNineAssignment.Data
{
	public class TrackRepository : ITrackRepository
    {
        private readonly SpotifyAPIClient _client;

        public TrackRepository(SpotifyAPIClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Track>> GetTracksAsync(string keywords, DateTime from, DateTime to, string trackName = null, 
                                                             string albumName = null, string artistName = null, string genre = null,
                                                             int? limit = null, int? offset = null)
        {
            var client = await _client.GetAuthorizedClientAsync();

            var url = new Url(SpotifyAPIClient.SearchEndpoint);

            StringBuilder query = new StringBuilder();
            query.Append(keywords ?? "");

            if (!string.IsNullOrEmpty(trackName))
            {
                query.Append(" track:" + trackName);
            }

            if (!string.IsNullOrEmpty(albumName))
            {
                query.Append(" album:" + albumName);
            }

            if (!string.IsNullOrEmpty(artistName))
            {
                query.Append(" artist:" + artistName);
            }

            if (!string.IsNullOrEmpty(genre))
            {
                query.Append(" genre:" + genre);
            }

            if (to.Year - from.Year > 0)
            {
                query.Append(" year:" + from.Year + "-" + to.Year);
            }
            else
            {
                query.Append(" year:" + DateTime.MinValue.Year + "-" + DateTime.Now.Year);
            }

            url.SetQueryParam("q", query.ToString());
            url.SetQueryParam("type", "track");

            if (limit != null)
            {
                url.SetQueryParam("limit", limit);
            }

            if (offset != null)
            {
                url.SetQueryParam("offset", offset);
            }

            var response = await client.GetStringAsync(url);

            var tracksResponse = JsonConvert.DeserializeObject<SpotifyGetTracksResponse>(response);
            return tracksResponse.Tracks.Items;
        }
    }
}
