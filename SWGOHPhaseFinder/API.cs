using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using SWGOHPhaseFinder.Models;
using System.Net.Http.Headers;

namespace SWGOHPhaseFinder
{
    public class API
    {
        private string token;
        private HttpClient client;

        public API()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("https://api.swgoh.help")
            };
        }

        public async Task Login()
        {
            var username = ConfigurationManager.AppSettings.Get("username");
            var password = ConfigurationManager.AppSettings.Get("password");

            //var payload = $"username={username}&password={password}&grant_type=password&client_id=abc&client_secret=123";
            var payload = new Dictionary<string?, string?>() {
                { "username", username },
                { "password", password },
                { "grant_type", "password" },
                { "client_id", "abc" },
                { "client_secret", "123" }};

            using var request = new HttpRequestMessage(HttpMethod.Post, "/auth/signin");
            request.Content = new FormUrlEncodedContent(payload);
            using var response = await client.SendAsync(request);

            var stringResponse = await response.Content.ReadAsStringAsync();

            token = JsonSerializer.Deserialize<SigninResponse>(stringResponse).Access_Token;
        }
        
        private HttpRequestMessage SetupMessage()
        {
            var request = new HttpRequestMessage();
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token); //new AuthenticationHeaderValue($"\"Bearer\" + {token}");
            request.Headers.Add("content-type", "application/json");

            return request;
        }

        public async Task GetPlayerInfo(int[] players)
        {

            var request = new HttpRequestMessage();
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token); //new AuthenticationHeaderValue($"\"Bearer\" + {token}");
            request.Headers.Add("content-type", "application/json");

        }


    }
}
