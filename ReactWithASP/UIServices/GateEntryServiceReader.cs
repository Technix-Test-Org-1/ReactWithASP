using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Configuration;
using ReactWithASP.Interface;
using Msc.Framework.Common.Model.Pagination;
using Newtonsoft.Json;
using ReactWithASP.ViewModels;
using Microsoft.Identity.Client;
using Msc.Framework.Common.Model.Utility;
using System.Linq;
using Azure;

namespace ReactWithASP.UIServices
{
    public sealed class GateEntryServiceReader : IGateEntryServiceReader
    {
        public IConfiguration configuration { get; }
        private readonly MasterServiceConfig serviceConfig;
        /// <summary>
        /// The scope list.
        /// </summary>
        private readonly string[] scope;

        /// <summary>
        /// The rest token before expire in seconds.
        /// </summary>
        private readonly int restTokenBeforeExpireInSeconds;


        private readonly HttpClient httpClient;

        private readonly TokenConfig tokenConfig;
        public GateEntryServiceReader(IConfiguration configuration, IOptions<MasterServiceConfig> serviceConfig, IOptions<TokenConfig> tokenConfig)
        {
            this.configuration = configuration;
            this.tokenConfig = tokenConfig.Value;
            this.serviceConfig = serviceConfig.Value;
            depotHttpClient.BaseAddress = new Uri(this.serviceConfig.baseAddress);
            httpClient = depotHttpClient;
        }

        //public RegisterationReadService(HttpClient httpClient, IOptions<RegistrationReadServiceConfig> serviceConfig, IOptions<TokenConfig> tokenConfig)
        //{
        //    this.serviceConfig = serviceConfig.Value;
        //    this.tokenConfig = tokenConfig.Value;
        //    httpClient.BaseAddress = new Uri(this.serviceConfig.baseAddress);
        //    this.httpClient = httpClient;
        //    this.scope = new string[] { Convert.ToString(this.serviceConfig.Scope, CultureInfo.CurrentCulture) };
        //    this.restTokenBeforeExpireInSeconds = SimpleConvert.ConvertInt32(this.tokenConfig.BeforeExpireSeconds);
        //    //this.SetToken();
        //}

        private async Task SetToken()
        {
            this.IsSecuredUrl(new Uri(this.serviceConfig.baseAddress));
            AuthenticationResult authentication = await this.GetReNewToken();
            if (!string.IsNullOrEmpty(authentication.AccessToken))
            {

                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authentication.AccessToken);
            }
        }

        private void IsSecuredUrl(Uri baseUrl)
        {
            if (baseUrl.Scheme == "https")
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }
        }

        private async Task<AuthenticationResult> GetReNewToken()
        {
            string scopeValue = Convert.ToString(this.serviceConfig.Scope, CultureInfo.InvariantCulture);
            return await this.GetToken(scopeValue);
        }

        private async Task<AuthenticationResult> GetToken(string scope)
        {
            AuthenticationResult authenticationResult = this.CreateConfidentialClientApp().AcquireTokenForClient(new[] { scope }).ExecuteAsync().Result;
            return await Task.FromResult(authenticationResult);
        }

        private IConfidentialClientApplication CreateConfidentialClientApp()
        {
            string aadInstance = this.tokenConfig.AADInstance;
            string tenant = this.tokenConfig.Tenant;
            string authority = string.Format(CultureInfo.InvariantCulture, aadInstance, tenant);
            string thumbprint = this.tokenConfig.Thumbprint;
            string clientId = this.tokenConfig.ClientId;
            IConfidentialClientApplication app = ConfidentialClientApplicationBuilder.Create(clientId).WithAuthority(authority).WithCertificate(this.GetClientCertificate(thumbprint)).Build();
            return app;
        }

        private X509Certificate2 GetClientCertificate(string thumbprint)
        {
            X509Certificate2 cert = null;
            using (X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine))
            {
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection signingCert = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, false);
                cert = signingCert.OfType<X509Certificate2>().OrderByDescending(c => c.NotBefore).FirstOrDefault();
            }

            if (cert == null)
            {
                using (X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser))
                {
                    store.Open(OpenFlags.ReadOnly);
                    X509Certificate2Collection signingCert = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, false);
                    cert = signingCert.OfType<X509Certificate2>().OrderByDescending(c => c.NotBefore).FirstOrDefault();
                }
            }

            if (cert == null)
            {
                string path = string.Empty;
                return new X509Certificate2(System.IO.File.ReadAllBytes(path));
            }

            return cert;
        }

       
        /// <summary>
        /// Charge Service Instance.
        /// </summary>
        //private static readonly Lazy<GateEntryServiceReader> ChargeServiceInstance = new Lazy<GateEntryServiceReader>(GetGateEntryServiceInstance, System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);

        /// <summary>
        /// The base URI.
        /// </summary>
        private static Tuple<string, string> baseURI;

        /// <summary>
        /// The master reader client.
        /// </summary>
        private readonly HttpClient depotHttpClient = new HttpClient();

        /// <summary>
        /// Gets the current.
        /// </summary>
        /// <value>
        /// The current.
        /// </value>
        //internal static GateEntryServiceReader Current
        //{
        //    get
        //    {
        //        return ChargeServiceInstance.Value;
        //    }
        //}

        /// <summary>
        /// Gets the  List of records.
        /// </summary>
        /// <param name="advanceSearchRequest">The advanceSearchRequest.</param>
        /// <param name="page">The page number.</param>
        /// <param name="pageSize">The page Size.</param>
        /// <param name="isDescending">The isDescending.</param>
        /// <param name="member">The member.</param>
        /// <returns>
        /// Returns the Result.
        /// </returns>
        public async Task<PageResponse<GateEntryInOutResult>> GetList(AdvanceSearchRequest request)
        {
            await this.SetToken();
            string path = string.Format(
                CultureInfo.InvariantCulture,
                 "isDropOff={0}&isPickUp={1}&truckNumber={2}&transporter={3}&referenceNumber={4}&from={5}&to={6}&status={7}&pageIndex={8}&pageSize={9}&sortField={10}&sortOrder={11}&depotId={12}&moveType={13}&type={14}&equipmentNumber={15}&truckinOut={16}",
                 request.IsDropOff,
                 request.IsPickUp,
                 request.TruckNumber,
                 request.Transporter,
                 request.ReferenceNumber,
                 request.From,
                 request.To,
                 request.Status,
                 request.PageIndex,
                 request.PageSize,
                 null,
                 true,
                 request.DepotId,
                 request.MoveType,
                 request.Type,
                 request.EquipmentNumber,
                 request.TruckInOut);
            var gateEntryInOutResult = await this.httpClient.GetAsync("v1/gateEntry/gateEntries?" + path);
            var data = await gateEntryInOutResult.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PageResponse<GateEntryInOutResult>>(data);
        }



        /// <summary>
        /// Gets the carriers.
        /// </summary>
        /// <param name="role">The role value.</param>
        /// <param name="depotId">The depot identifier.</param>
        /// <returns>
        /// Returns the Result.
        /// </returns>
        public async Task<PageResponse<MasterBase>> GetCarriers(string role, int depotId)
        {
            await this.SetToken();
            var response = await this.httpClient.GetAsync($"v1/gateEntry/carriers?role={role}&depotId={depotId}&searchText=&page=&pageSize=");
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PageResponse<MasterBase>>(data);
        }
        public async Task<PageResponse<MasterBase>> GetEquipmentListOfValues(string type, string searchText, int page, int pageSize, int depotId)
        {
            await this.SetToken();
            var containers = await this.httpClient.GetAsync("v1/gateEntry/getEquipmentListOfValues?type=" + type + "&searchText=" + searchText + "&depotId=" + depotId + "&page=" + page + "&pageSize=" + pageSize);
            var data = await containers.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PageResponse<MasterBase>>(data);
        }
        /// <summary>
        /// Declare Dispose.
        /// </summary>
        public void Dispose()
        {
            this.depotHttpClient?.Dispose();
        }
    }
}
