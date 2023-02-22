using BlazorAtelierCremazieServer.Models;
using BlazorAtelierCremazieServer.ServicesExterne;
using Microsoft.AspNetCore.Components;

namespace BlazorAtelierCremazieServer.Pages.Components
{
    public partial class InstaFlux
    {
        [Inject] public IInstagramApiService Service { get; set; }


        public IEnumerable<InstaPost> Posts { get; set; }
        public int CardHeight { get; set; } = 400;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                Posts = await Service.GetInstaFeedAsync();

                StateHasChanged();
            }
        }
    }
}