using BlazorAtelierCremazieServer.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace BlazorAtelierCremazieServer.Pages.Components
{
    public partial class InstaFlux
    {
        public HttpClient client = new HttpClient();

        public Media[] Medias { get; set; } = new Media[0];

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                string accessToken = "EAAIis4GF33EBAHM9dMWN6yFLYp1kMUB8M4FRj3ZA9cCSsAv6b41L0dnvyB0YkdsZBOjwk9JsUf2WpVjU999VFKyw1yswEBXKVosjBievpIkcBEfFdmwDVvWzEr9dZAqtkXwVx9JNnLrXX3fVS1hQrF0uCdZBdWv8N3NwiTZB36nZC91GFJfYM0xIpd0YccFGkJWFfkukOpJYIUZBYHCHfMpPNNCZBgLCGG8ZD";

                var r1 = await SendRequest(HttpMethod.Get, $"https://graph.facebook.com/v15.0/17841447633232343?fields=media{{id,caption,media_type,media_url,permalink}}&access_token={accessToken}", new StringContent(String.Empty));

                var objectInsta = JsonConvert.DeserializeObject<Rootobject>(r1);
                Medias = objectInsta.media.data;

                StateHasChanged();
            }
        }

        public async Task<string> SendRequest(HttpMethod method, string uri, StringContent content)
        {
            string result = string.Empty;

            var requestNewIp = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri(uri),
                Headers =
                {
                    { "authorization", "Apikey 8F44nIGdXu7H6zojDwOlkGqM" }
                },
                Content = content
            };
            using (var response = await client.SendAsync(requestNewIp))
            {
                //response.EnsureSuccessStatusCode();
                result = await response.Content.ReadAsStringAsync();
            }

            return result;
        }
    }
}
