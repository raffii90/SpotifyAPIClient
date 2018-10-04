using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CloudNineAssignment.Models.SpotifyModels;
using Newtonsoft.Json;

namespace CloudNineAssignment.Data
{
    public class SpotifyAPIClient
    {
        private const string ClientID = "996d0037680544c987287a9b0470fdbb";
        private const string ClientSecret = "5a3c92099a324b8f9e45d77e919fec13";

        private const string BaseUrl = "https://api.spotify.com/";
        private const string AuthorizationEndpoint = "https://accounts.spotify.com/api/token";
        public const string SearchEndpoint = "/v1/search";

        private DateTime _accessTokenLifetime;
        private string _accessToken;

        private static SpotifyAPIClient _instance;

        public static SpotifyAPIClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SpotifyAPIClient();
                }

                return _instance;
            }
        }

        private SpotifyAPIClient()
        {

        }

        public async Task<HttpClient> GetAuthorizedClientAsync()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + await GetAccessTokenAsync());
            client.BaseAddress = new Uri(BaseUrl);

            return client;
        }

        private async Task<string> GetAccessTokenAsync()
        {
            if (string.IsNullOrEmpty(_accessToken) || !string.IsNullOrEmpty(_accessToken) && _accessTokenLifetime > DateTime.Now)
            {
                var authorizatonResponse = await GetAuthorizationResponseAsync();
                _accessToken = authorizatonResponse.AccessToken;
                _accessTokenLifetime = DateTime.Now.AddSeconds(authorizatonResponse.ExpiresIn);
            }

            return _accessToken;
        }

        private async Task<SpotifyAuthorizationResponse> GetAuthorizationResponseAsync()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Base64Encode(ClientID + ":" + ClientSecret));

                var content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>(){
                    new KeyValuePair<string, string>("grant_type", "client_credentials")
                });

                HttpResponseMessage response = await client.PostAsync(AuthorizationEndpoint, content);
                string jsonString = await response.Content.ReadAsStringAsync();

                SpotifyAuthorizationResponse authorizationResponse = JsonConvert.DeserializeObject<SpotifyAuthorizationResponse>(jsonString);

                return authorizationResponse;
            }
        }

        private string Base64Encode(string text)
        {
            var textBytes = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(textBytes);
        }
    }
}
