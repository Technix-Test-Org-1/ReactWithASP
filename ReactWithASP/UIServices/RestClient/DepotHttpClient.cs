using Microsoft.Identity.Client;
using System.Globalization;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ReactWithASP.UIServices.RestClient
{
    public class DepotHttpClient : HttpClient
    {
        // static IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        //IOptions<MasterServiceConfig> config = Options.Create(configuration.GetSection("ida").Get<MasterServiceConfig>());
        ///// <summary>
        ///// The application identifier.
        ///// </summary>
        //public readonly string Scope;

        ///// <summary>
        ///// The instance.
        ///// </summary>
        //private static string aadInstance = ConfigurationManager.AppSettings["ida:AADInstance"];

        ///// <summary>
        ///// The tenant.
        ///// </summary>
        //private static string tenant = ConfigurationManager.AppSettings["ida:Tenant"];

        ///// <summary>
        ///// The authority.
        ///// </summary>
        //private static string authority = string.Format(CultureInfo.InvariantCulture, aadInstance, tenant);

        ///// <summary>
        ///// The client identifier.
        ///// </summary>
        //private static string clientId = ConfigurationManager.AppSettings["ida:ClientId"];

        ///// <summary>
        ///// The client certificate thumbprint .
        ///// </summary>
        //private static string thumbprint = ConfigurationManager.AppSettings["ida:Thumbprint"];

        ///// <summary>
        ///// Initializes a new instance of the <see cref="DepotHttpClient" /> class.
        ///// </summary>
        ///// <param name="isAXWayInvoke">The isAXWayInvoke.</param>
        ///// <param name="scope">The  scope .</param>
        //public DepotHttpClient(bool isAXWayInvoke, string scope)
        //{
        //    this.DefaultRequestHeaders.Accept.Clear();
        //    this.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    if (isAXWayInvoke && scope != string.Empty)
        //    {
        //        string token = string.Empty;
        //        Task.Run(async () => { token = await this.GetToken(scope); }).Wait();

        //        this.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        //    }

        //    this.Scope = scope;
        //}

        ///// <summary>
        ///// Initializes a new instance of the <see cref="DepotHttpClient" /> class.
        ///// </summary>
        ///// <param name="basePath">The base Path.</param>
        ///// <param name="userId">The user identifier.</param>
        //public DepotHttpClient(string basePath, string userId)
        //{
        //    this.BaseAddress = new Uri(basePath);
        //    this.DefaultRequestHeaders.Accept.Clear();
        //    this.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    this.DefaultRequestHeaders.Add("UserId", userId);
        //}

        ///// <summary>
        ///// Initializes a new instance of the <see cref="DepotHttpClient" /> class.
        ///// </summary>
        ///// <param name="basePath">The base Path.</param>
        ///// <param name="userId">The user identifier.</param>
        ///// <param name="scope">The  scope .</param>
        //public DepotHttpClient(string basePath, string userId, string scope)
        //{
        //    this.BaseAddress = new Uri(basePath);
        //    this.DefaultRequestHeaders.Accept.Clear();
        //    this.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    this.DefaultRequestHeaders.Add("UserId", userId);
        //    this.Scope = scope;
        //}

        ///// <summary>
        ///// Initializes a new instance of the <see cref="DepotHttpClient" /> class.
        ///// </summary>
        ///// <param name="basePath">The base Path.</param>
        ///// <param name="userId">The user identifier.</param>
        ///// <param name="scope">The  scope .</param>
        ///// <param name="timeoutMinutes">The time out minutes.</param>
        //public DepotHttpClient(string basePath, string userId, string scope, int timeoutMinutes)
        //{
        //    this.BaseAddress = new Uri(basePath);
        //    this.DefaultRequestHeaders.Accept.Clear();
        //    this.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    this.DefaultRequestHeaders.Add("UserId", userId);
        //    this.Timeout = new TimeSpan(0, timeoutMinutes, 0);
        //    this.Scope = scope;
        //}

        ///// <summary>
        ///// Gets or sets the instance.
        ///// </summary>
        ///// <value>
        ///// The Current Token.
        ///// </value>
        //public AxwayToken CurrentAxwayToken { get; set; }

        ///// <summary>
        ///// Initializes a new instance of the <see cref="thumbprint"/> class.
        ///// </summary>
        ///// <param name="thumbprint">The  thumbprint .</param> 
        ///// <returns>Returns the result.</returns>
        //private X509Certificate2 GetClientCertificate(string thumbprint)
        //{
        //    X509Certificate2 cert = null;
        //    using (X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine))
        //    {
        //        store.Open(OpenFlags.ReadOnly);
        //        X509Certificate2Collection signingCert = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, false);
        //        cert = signingCert.OfType<X509Certificate2>().OrderByDescending(c => c.NotBefore).FirstOrDefault();
        //    }

        //    if (cert == null)
        //    {
        //        using (X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser))
        //        {
        //            store.Open(OpenFlags.ReadOnly);
        //            X509Certificate2Collection signingCert = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, false);
        //            cert = signingCert.OfType<X509Certificate2>().OrderByDescending(c => c.NotBefore).FirstOrDefault();
        //        }
        //    }

        //    if (cert == null)
        //    {
        //        string path = ConfigurationManager.AppSettings["CertificatePath"];
        //        return new X509Certificate2(File.ReadAllBytes(path));
        //    }

        //    return cert;
        //}

        ///// <summary>
        ///// Get Token .
        ///// </summary>
        ///// <returns>Returns the result.</returns> 
        //private IConfidentialClientApplication CreateConfidentialClientApp()
        //{
        //    IConfidentialClientApplication app = ConfidentialClientApplicationBuilder.Create(clientId).WithAuthority(authority).WithCertificate(this.GetClientCertificate(thumbprint)).Build();
        //    ////WithClientSecret("v87e8zt.V46m.6dTNL3xKI-IrEQj1-ni.2").
        //    ////MSALAppSessionTokenCache tokenCache = new MSALAppSessionTokenCache(app.AppTokenCache, clientId, HttpContext.Current);
        //    return app;
        //}

        ///// <summary>
        ///// Get Token .
        ///// </summary>
        ///// <param name="scope">The  scope .</param>
        ///// <returns>Returns the result.</returns> 
        //private async Task<string> GetToken(string scope)
        //{
        //    var token = await this.CreateConfidentialClientApp().AcquireTokenForClient(new[] { scope }).ExecuteAsync();
        //    return token.AccessToken;
        //}
    }
}
