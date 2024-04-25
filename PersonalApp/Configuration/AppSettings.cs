namespace PersonalApp.Configuration
{
    public class AppSettings : IAppSettings
    {
        private readonly IConfiguration _configuration;

        public AppSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public Configuration GetConfiguration()
        {
            Configuration configuration = new Configuration();
            //configuration.GofinanceApiUrl = _configuration["AppSettings:GofinanceApiUrl"];
            //configuration.UploadPathUrl = _configuration["AppSettings:UploadsPath"];
            //configuration.GofinanceApiUrl = _configuration["AppSettings:GofinanceApiUrl"];
            //configuration.Currency = _configuration["AppSettings:Currency"];
            //configuration.CustomerPortalLink = _configuration["AppSettings:CustomerPortalLink"];
            //configuration.CustomerSaleTeamActivateLink = _configuration["AppSettings:CustomerSaleTeamActivateLink"];
            //configuration.CurrentCountryCode = _configuration["AppSettings:CurrentCountryCode"];
            //configuration.TwilioAccountSid = _configuration["AppSettings:TwilioAccountSid"];
            //configuration.TwilioAuthToken = _configuration["AppSettings:TwilioAuthToken"];
            //configuration.CardsTarget = _configuration["AppSettings:CardsTarget"];
            //configuration.CallsTarget = _configuration["AppSettings:CallsTarget"];
            //configuration.GofinanceCorporateLink = _configuration["AppSettings:GofinanceCorporateLink"];
            return configuration;
        }
    }
}
