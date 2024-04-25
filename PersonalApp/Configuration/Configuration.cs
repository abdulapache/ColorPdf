namespace PersonalApp.Configuration
{
    public class Configuration
    {
        public string GofinanceApiUrl { get; set; }
        public string UploadPathUrl { get; set; }
        public string Currency { get; set; }
        public string CustomerPortalLink { get; set; }
        public string CustomerSaleTeamActivateLink { get; set; }
        public string? CurrentCountryCode { get; set; }
        public string? TwilioAccountSid { get; set; }
        public string? TwilioAuthToken { get; set; }
        public string? CardsTarget { get; set; }
        public string? CallsTarget { get; set; }
        public string? GofinanceCorporateLink { get; set; }
    }
}
