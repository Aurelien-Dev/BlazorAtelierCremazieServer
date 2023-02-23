using BlazorAtelierCremazieServer.Models;

namespace BlazorAtelierCremazieServer.ServicesExterne
{
    public interface IInstagramApiService
    {
        /// <summary>
        /// Get posts from Instagram API
        /// return <see cref="InstaPost"/> information
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        Task<IEnumerable<InstaPost>> GetInstaFeedAsync();
    }
}
