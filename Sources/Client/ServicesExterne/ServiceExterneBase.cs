namespace BlazorAtelierCremazieServer.ServicesExterne
{
    public class ServiceExterneBase
    {
        public EnvironementSingleton EnvironementService { get; set; }
        private HttpClient httpClient;

        public ServiceExterneBase(HttpClient client, EnvironementSingleton environement)
        {
            httpClient = client;
            EnvironementService = environement;
        }

        public async Task<string> SendRequest(HttpMethod method, string uri)
        {
            return await SendRequest(method, uri, new StringContent(string.Empty));
        }

        public async Task<string> SendRequest(HttpMethod method, string uri, StringContent content)
        {
            string result = string.Empty;

            var requestNewIp = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri(uri),
                Content = content
            };
            using (var response = await httpClient.SendAsync(requestNewIp))
            {
                //response.EnsureSuccessStatusCode();
                result = await response.Content.ReadAsStringAsync();
            }

            return result;
        }
    }
}
