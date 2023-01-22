using BlazorAtelierCremazieServer.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace BlazorAtelierCremazieServer.Pages.Components
{
    public partial class InstaFlux
    {
        public HttpClient client = new HttpClient();

        public Media[] Medias { get; set; } = new Media[0];

        public int CardHeight { get; set; } = 400;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                string accessToken = "EAAIis4GF33EBAFF1BRLqfPtNG1sB3BMzyHoTBXCaTljUlgimHXvQnhlHvco61ovjic4w3ZC3UFK1O43asesborBvZAO4oyGi6YT2uQr7cwbtakZABQtPPCIJ5sFshibMrDrZBy6gSEK9eWHFpFYYcVioVkSUU5a4YAq81PZBuHfnkpk2wtx9SG5bCuoArPZBttSggVrPpcXGZBin4ZA8yw1vvwhcBCpZCxNVEbZBH12YGUvQZDZD";

                var r1 = await SendRequest(HttpMethod.Get, $"https://graph.facebook.com/v15.0/17841447633232343?fields=media{{id,caption,thumbnail_url,media_type,media_url,permalink}}&access_token={accessToken}", new StringContent(String.Empty));

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
