using System;
using Spotify.Interfaces;
using System.Threading.Tasks;
using Flurl;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using Spotify.Models;
using Spotify.Models.SpotifyModels;

namespace Spotify.Data
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly SpotifyAPIClient _client;

        public AlbumRepository(SpotifyAPIClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Album>> GetAlbumsAsync(string keywords, DateTime from, DateTime to, string albumName = null, 
                                                             string artist = null, int? limit = null, int? offset = null)
        {
            var client = await _client.GetAuthorizedClientAsync();

            var url = new Url(SpotifyAPIClient.SearchEndpoint);

            StringBuilder query = new StringBuilder();
            query.Append(keywords ?? "");

            if (!string.IsNullOrEmpty(albumName))
            {
                query.Append(" album:" + albumName);
            }

            if (!string.IsNullOrEmpty(artist))
            {
                query.Append(" artist:" + artist);
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
            url.SetQueryParam("type", "album");

            if (limit != null)
            {
                url.SetQueryParam("limit", limit);
            }

            if (offset != null)
            {
                url.SetQueryParam("offset", offset);
            }

            var response = await client.GetStringAsync(url);

            var albumsResponse = JsonConvert.DeserializeObject<SpotifyGetAlbumsResponse>(response);
            return albumsResponse.Albums.Items;
        }
    }
}
