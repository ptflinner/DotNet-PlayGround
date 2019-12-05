using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GatewayService
{
    public class GithubClient
    {
        private HttpClient _client;

        public GithubClient(HttpClient client)
        {
            System.Diagnostics.Debug.WriteLine("Instantiated the client");
            _client=client;
            _client.BaseAddress = new Uri("https://api.github.com/");
            _client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            _client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactoryTesting");
        }

        public async Task<IEnumerable> getGithubRequest(string url)
        {
            HttpRequestMessage request = new HttpRequestMessage();

            var result = await _client.GetAsync("");
            result.EnsureSuccessStatusCode();
            string content = await result.Content.ReadAsStringAsync();
            System.Diagnostics.Debug.WriteLine(content);
            return content;
        }
    }
}
