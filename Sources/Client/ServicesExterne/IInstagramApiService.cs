using BlazorAtelierCremazieServer.Models;

namespace BlazorAtelierCremazieServer.ServicesExterne
{
    public interface IInstagramApiService
    {
        Task<IEnumerable<InstaPost>> GetInstaFeedAsync();
    }
}
