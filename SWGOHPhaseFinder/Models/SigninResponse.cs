using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SWGOHPhaseFinder.Models
{
    public class SigninResponse
    {
        [JsonPropertyName("token_type")]
        public string Token_Type { get; set; }
        [JsonPropertyName("access_token")]
        public string Access_Token { get; set; }
        [JsonPropertyName("expires_in")]
        public int Expires_In { get; set; }
    }
}
