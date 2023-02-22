using BlazorAtelierCremazieServer.Commmon.CustomException;
using BlazorAtelierCremazieServer.Models;
using Newtonsoft.Json;

namespace BlazorAtelierCremazieServer.ServicesExterne
{
    public class InstagramApiService : ServiceExterneBase, IInstagramApiService
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="client">HttpClient</param>
        public InstagramApiService(HttpClient client, EnvironementSingleton environement) : base(client, environement) { }


        /// <summary>
        /// Get posts from Instagram API
        /// return <see cref="InstaPost"/> information
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<IEnumerable<InstaPost>> GetInstaFeedAsync()
        {
            try
            {
                var result = await SendRequest(HttpMethod.Get, $"https://graph.instagram.com/me/media?fields=id,caption,thumbnail_url,media_url,media_type,permalink&access_token={EnvironementService.GetInstaToken()}");

                if (string.IsNullOrWhiteSpace(result)) return Enumerable.Empty<InstaPost>();

                var Feed = JsonConvert.DeserializeObject<InstaFeed>(result);

                if (Feed == null || Feed.Data == null) return Enumerable.Empty<InstaPost>();

                return Feed.Data;
            }
            catch (ApiCallException)
            {
                return Enumerable.Empty<InstaPost>();
            }
            catch (Exception)
            {
                throw new ApplicationException();
            }
        }
    }
}