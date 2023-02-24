using BlazorAtelierCremazieServer.Commmon.CustomException;
using BlazorAtelierCremazieServer.Pages.Sections;
using Newtonsoft.Json;
using System.Text;

namespace BlazorAtelierCremazieServer.ServicesExterne
{
    public class EmailJsService : ServiceExterneBase, IEmailJsService
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="client">HttpClient</param>
        public EmailJsService(HttpClient client, EnvironementSingleton environement) : base(client, environement) { }

        /// <summary>
        /// Send email with EmailJS
        /// Use specific template
        /// </summary>
        /// <param name="contact">Information of contact and message</param>
        /// <returns>True if mail is sending</returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<bool> SendEmailJs(Contact contact)
        {
            try
            {
                var payload = new
                {
                    service_id = EnvironementService.GetEnvironmentVariable(EnvironementSingleton.VarEmailJsServiceId),
                    template_id = EnvironementService.GetEnvironmentVariable(EnvironementSingleton.VarEmailJsTemplateId),
                    user_id = EnvironementService.GetEnvironmentVariable(EnvironementSingleton.VarEmailJsUserId),
                    accessToken = EnvironementService.GetEnvironmentVariable(EnvironementSingleton.VarEmailJsAccessToken),
                    template_params = new
                    {
                        nom_prenom = contact.Name,
                        email = contact.Email,
                        telephone = contact.Telephone,
                        message = contact.Message
                    }
                };

                var stringPayload = JsonConvert.SerializeObject(payload);
                StringContent content = new StringContent(stringPayload, Encoding.UTF8, "application/json");

                var result = await SendRequest(HttpMethod.Post, $"https://api.emailjs.com/api/v1.0/email/send", content);

                if (string.IsNullOrWhiteSpace(result)) return false;

                if (result == "OK") return true;
                else return false;
            }
            catch (ApiCallException)
            {
                return false;
            }
            catch (Exception)
            {
                throw new ApplicationException();
            }
        }
    }
}