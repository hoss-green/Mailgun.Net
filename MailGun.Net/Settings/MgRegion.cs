namespace MailGun.Net.Settings
{
    public class MgRegion
    {
        public string ApiUrl { get; set; }
        // ReSharper disable once InconsistentNaming
        public static MgRegion USA = new("https://api.mailgun.net");
        
        // ReSharper disable once InconsistentNaming
        public static MgRegion EU = new("https://api.eu.mailgun.net");
        
        // public const string Europe = "https://api.mailgun.net/";

        private MgRegion(string apiUrl)
        {
            this.ApiUrl = apiUrl;
        }
    }
}