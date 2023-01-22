namespace BlazorAtelierCremazieServer.Pages.Components
{
    public partial class MeContacter
    {
        public ContactForm contact { get; set; } = new();
        public bool success { get; set; }

        private void OnValidSubmit()
        {
            success = true;
            StateHasChanged();
        }
    }

    public class ContactForm
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Telephone { get; set; }
        public string? Message { get; set; }
    }
}