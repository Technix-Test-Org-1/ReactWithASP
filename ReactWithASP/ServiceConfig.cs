namespace ReactWithASP
{
    public class ServiceConfig
    {
        public string baseAddress { get; set; }

        public string axwayClientId { get; set; }

        public string axwayClientSecret { get; set; }
        public string axwayGrantType { get; set; }
        public string axwaySecurityUrl { get; set; }

        public string Scope { get; set; }

    }

    public class GatePassServiceConfig : ServiceConfig
    {

    } 
    public class MasterServiceConfig : ServiceConfig
    {

    }
}
