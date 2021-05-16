using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using SWGOHPhaseFinder.Models;

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

            var message = new HttpRequestMessage(HttpMethod.Post, "/auth/signin");
            message.Content = new FormUrlEncodedContent(payload);
            var request = await client.SendAsync(message);

            token = JsonSerializer.Deserialize<SigninResponse>(await request.Content.ReadAsStringAsync()).access_token;
        }

    }
}
