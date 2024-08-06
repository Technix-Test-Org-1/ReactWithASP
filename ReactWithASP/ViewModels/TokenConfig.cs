namespace ReactWithASP.ViewModels
{
    public class TokenConfig
    {
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string Tenant { get; set; }
        public string Thumbprint { get; set; }
        public string AADInstance { get; set; }
        public string BeforeExpireSeconds { get; set; }
    }
}
