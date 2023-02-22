namespace BlazorAtelierCremazieServer
{
    public class EnvironementSingleton
    {

        public string WebRootPath { get; set; } = default!;
        public string ContentRootPath { get; set; } = default!;

        public bool IsInDev()
        {
            string environement = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (string.IsNullOrEmpty(environement) || environement == "Development")
                return true;

            return false;
        }


        public string GetInstaToken()
        {
            return Environment.GetEnvironmentVariable("InstagramApiToken", EnvironmentVariableTarget.Machine);
        }
    }
}