using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Spotify.Interfaces;
using Spotify.Models;
using Spotify.Models.SpotifyModels;
using Flurl;
using Newtonsoft.Json;

namespace Spotify.Data
{
	public class ArtistRepository : IArtistRepository
    {
        private readonly SpotifyAPIClient _client;

        public ArtistRepository(SpotifyAPIClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Artist>> GetArtistsAsync(string name, DateTime from, DateTime to, string genre = null,
                                                               int? limit = null, int? offset = null)
        {
            var client = await _client.GetAuthorizedClientAsync();

            var url = new Url(SpotifyAPIClient.SearchEndpoint);

            StringBuilder query = new StringBuilder();
            query.Append(name ?? "");

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
            url.SetQueryParam("type", "artist");

            if (limit != null)
            {
                url.SetQueryParam("limit", limit);
            }

            if (offset != null)
            {
                url.SetQueryParam("offset", offset);
            }

            var response = await client.GetStringAsync(url);

            var artistsResponse = JsonConvert.DeserializeObject<SpotifyGetArtistsResponse>(response);
            return artistsResponse.Artists.Items;
        }
    }
}
