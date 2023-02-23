namespace BlazorAtelierCremazieServer
{
    public class EnvironementSingleton
    {
        public string WebRootPath { get; set; } = default!;
        public string ContentRootPath { get; set; } = default!;


        //Instagram
        public const string VarInstagramApiToken = "InstagramApiToken";
        //EmailJS
        public const string VarEmailJsServiceId = "EmailJsServiceId";
        public const string VarEmailJsTemplateId = "EmailJsTemplateId";
        public const string VarEmailJsUserId = "EmailJsUserId";
        public const string VarEmailJsAccessToken = "EmailJsAccessToken";


        public bool IsInDev()
        {
            string environement = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (string.IsNullOrEmpty(environement) || environement == "Development")
                return true;

            return false;
        }


        public string GetInstaToken()
        {
            return Environment.GetEnvironmentVariable(VarInstagramApiToken, EnvironmentVariableTarget.Machine);
        }

        internal object GetEnvironmentVariable(string variable)
        {
            return Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Machine);
        }
    }
}