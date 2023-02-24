using BlazorAtelierCremazieServer.ServicesExterne;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorAtelierCremazieServer.Pages.Sections
{
    public partial class MeContacter
    {
        [Inject] public IEmailJsService EmailJsService { get; set; }
        [Inject] public ISnackbar Snackbar { get; set; }

        public Contact contact { get; set; } = new();
        
        public async Task SumbitFormContact()
        {
            bool mailSending = await EmailJsService.SendEmailJs(contact);

            Snackbar.Clear();
            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomCenter;
            Snackbar.Configuration.SnackbarVariant = Variant.Text;


            if (mailSending)
            {
                Snackbar.Add("L'email a bien été envoyé.", Severity.Success);
                contact = new Contact();
            }
            else Snackbar.Add("Erreur dans l'envoie du mail. Vous pouvez me contacter directement a mon adresse : atelier.cremazie@gmail.com", Severity.Warning);
        }
    }

    public class Contact
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Telephone { get; set; }
        public string? Message { get; set; }
    }
}