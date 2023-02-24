using BlazorAtelierCremazieServer.Pages.Sections;

namespace BlazorAtelierCremazieServer.ServicesExterne
{
    public interface IEmailJsService
    {
        /// <summary>
        /// Send email with EmailJS
        /// Use specific template
        /// </summary>
        /// <param name="contact">Information of contact and message</param>
        /// <returns>True if mail is sending</returns>
        /// <exception cref="ApplicationException"></exception>
        Task<bool> SendEmailJs(Contact contact);
    }
}
