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

namespace ReactWithASP.UIServices
{
    public sealed class GateEntryServiceReader
    {
        ///// <summary>
        ///// Charge Service Instance.
        ///// </summary>
        //private static readonly Lazy<GateEntryServiceReader> ChargeServiceInstance = new Lazy<GateEntryServiceReader>(GetGateEntryServiceInstance, System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);

        ///// <summary>
        ///// The base URI.
        ///// </summary>
        //private static Tuple<string, string> baseURI = UrlSettings.GetUrlAppByKey("GatePassReaderBaseURI");

        ///// <summary>
        ///// The master reader client.
        ///// </summary>
        //private readonly DepotHttpClient depotHttpClient = new DepotHttpClient(baseURI.Item1, string.Empty, baseURI.Item2);

        ///// <summary>
        ///// Gets the current.
        ///// </summary>
        ///// <value>
        ///// The current.
        ///// </value>
        //internal static GateEntryServiceReader Current
        //{
        //    get
        //    {
        //        return ChargeServiceInstance.Value;
        //    }
        //}

        ///// <summary>
        ///// Gets the  List of records.
        ///// </summary>
        ///// <param name="advanceSearchRequest">The advanceSearchRequest.</param>
        ///// <param name="page">The page number.</param>
        ///// <param name="pageSize">The page Size.</param>
        ///// <param name="isDescending">The isDescending.</param>
        ///// <param name="member">The member.</param>
        ///// <returns>
        ///// Returns the Result.
        ///// </returns>
        //public async Task<PageResponse<GateEntryInOutResult>> GetList(AdvanceSearchRequest advanceSearchRequest, int page, int pageSize, bool isDescending, string member)
        //{
        //    string path = string.Format(
        //        CultureInfo.InvariantCulture,
        //         "isDropOff={0}&isPickUp={1}&truckNumber={2}&transporter={3}&referenceNumber={4}&from={5}&to={6}&status={7}&pageIndex={8}&pageSize={9}&sortField={10}&sortOrder={11}&depotId={12}&moveType={13}&type={14}&equipmentNumber={15}&truckinOut={16}",
        //         advanceSearchRequest.IsDropOff,
        //         advanceSearchRequest.IsPickUp,
        //         advanceSearchRequest.TruckNumber,
        //         advanceSearchRequest.Transporter,
        //         advanceSearchRequest.ReferenceNumber,
        //         advanceSearchRequest.From,
        //         advanceSearchRequest.To,
        //         advanceSearchRequest.Status,
        //         page,
        //         pageSize,
        //         member,
        //         isDescending,
        //         SessionManager.User.DepotId,
        //         advanceSearchRequest.MoveType,
        //         advanceSearchRequest.Type,
        //         advanceSearchRequest.EquipmentNumber,
        //         advanceSearchRequest.TruckInOut);
        //    var api = new RestClient(this.depotHttpClient);
        //    PageResponse<GateEntryInOutResult> gateEntryInOutResult = await api.GetAsync<PageResponse<GateEntryInOutResult>>("v1/gateEntry/gateEntries?" + path);
        //    return gateEntryInOutResult;
        //}

        ///// <summary>
        ///// Gate Entry.
        ///// </summary>
        ///// <param name="entryType">The entryType.</param>
        ///// <param name="truckId">The truckId.</param>
        ///// <param name="depotId">The depotId.</param>
        ///// <returns>
        ///// Returns the Result.
        ///// </returns>
        //public async Task<GateEntryViewModel> GateEntry(string entryType, int truckId, int depotId)
        //{
        //    GateEntryViewModel gateEntryViewModel = null;
        //    var api = new RestClient(this.depotHttpClient);
        //    gateEntryViewModel = await api.GetAsync<GateEntryViewModel>("v1/gateEntry/gateEntry?truckId=" + truckId + "&entryType=" + entryType + "&depotId=" + depotId);
        //    return gateEntryViewModel;
        //}

        ///// <summary>
        ///// Gets the more detail.
        ///// </summary>
        ///// <param name="referenceNumber">The reference number.</param>
        ///// <param name="entryType">Type of the entry.</param>
        ///// <param name="entryId">The entry identifier.</param>
        ///// <param name="depotId">The depot identifier.</param>
        ///// <returns>
        ///// Returns the Result.
        ///// </returns>
        //public async Task<AdditionalDetail> GetMoreDetail(string referenceNumber, string entryType, long entryId, int depotId)
        //{
        //    var api = new RestClient(this.depotHttpClient);
        //    AdditionalDetail detail = await api.GetAsync<AdditionalDetail>("v1/gateEntry/moreDetail?referenceNumber=" + referenceNumber + "&entryType=" + entryType + "&entryId=" + entryId + "&depotId=" + depotId);
        //    return detail;
        //}

        ///// <summary>
        ///// Gets the stack detail.
        ///// </summary>
        ///// <param name="entryType">Type of the entry.</param>
        ///// <param name="entryId">The entry identifier.</param>
        ///// <param name="depotId">The depot identifier.</param>
        ///// <returns>
        ///// Returns the Result.
        ///// </returns>
        //public async Task<ViewModel.GateEntry.StackPosition> GetStackDetail(string entryType, long entryId, int depotId)
        //{
        //    var api = new RestClient(this.depotHttpClient);
        //    ViewModel.GateEntry.StackPosition detail = await api.GetAsync<ViewModel.GateEntry.StackPosition>("v1/gateEntry/stackDetail?entryType=" + entryType + "&entryId=" + entryId + "&depotId=" + depotId);
        //    return detail;
        //}
        ///// <summary>
        ///// Gets the container available flag.
        ///// </summary>
        ///// <param name="entryType">Type of the entry.</param>
        ///// <param name="container">The container.</param>
        ///// <param name="depotId">The depot identifier.</param>
        ///// <param name="inputData">The input data.</param>
        ///// <returns>
        ///// Returns the Result.
        ///// </returns>
        //public async Task<Container> GetContainerAvailableFlag(string entryType, string container, int depotId, string inputData)
        //{
        //    var api = new RestClient(this.depotHttpClient);
        //    var containerValue = await api.GetAsync<Container>("v1/gateEntry/getContainerFlag?entryType=" + entryType + "&container=" + container + "&depotId=" + depotId + "&inputData=" + inputData);
        //    return containerValue;
        //}

        ///// <summary>
        ///// Gets the carriers.
        ///// </summary>
        ///// <param name="role">The role value.</param>
        ///// <param name="depotId">The depot identifier.</param>
        ///// <returns>
        ///// Returns the Result.
        ///// </returns>
        //public async Task<List<MasterBase>> GetCarriers(string role, int depotId)
        //{
        //    var api = new RestClient(this.depotHttpClient);
        //    var carriers = await api.GetAsync<List<MasterBase>>("v1/gateEntry/carriers?role=" + role + "&depotId=" + depotId);
        //    return carriers;
        //}

        ///// <summary>
        ///// Gets the stack cells.
        ///// </summary>
        ///// <param name="blockId">The block identifier.</param>
        ///// <param name="depotId">The depot identifier.</param>
        ///// <param name="lineId">The line identifier.</param>
        ///// <param name="sizeType">Type of the size.</param>
        ///// <param name="damaged">The damaged.</param>
        ///// <param name="gradeId">The grade identifier.</param>
        ///// <returns>Returns the Result.</returns>
        //public async Task<BlockCellInformation> GetStackCells(int blockId, int depotId, int lineId, string sizeType, char? damaged, int gradeId)
        //{
        //    BlockCellInformation response;
        //    RestClient api = new RestClient(this.depotHttpClient);
        //    response = await api.GetAsync<BlockCellInformation>("v1/gateins/GetStackCells?depotId=" + depotId + "&blockId=" + blockId + "&lineId=" + lineId + "&sizeType=" + sizeType + "&gradeId=" + gradeId + "&damaged=" + damaged);
        //    return response;
        //}

        ///// <summary>
        ///// Get Print List Of Values.
        ///// </summary>
        ///// <param name="truckId">The truckId.</param>
        ///// <param name="depotId">The depotId.</param>
        ///// <returns>
        ///// Returns the Result.
        ///// </returns>
        //public async Task<List<MasterBase>> GetPrintListOfValues(int truckId, int depotId)
        //{
        //    var api = new RestClient(this.depotHttpClient);
        //    var values = await api.GetAsync<List<MasterBase>>("v1/gateEntry/getPrintListOfValues?truckId=" + truckId + "&depotId=" + depotId);
        //    return values;
        //}

        ///// <summary>
        ///// Gets the reference list of values.
        ///// </summary>
        ///// <param name="depotId">The depot identifier.</param>
        ///// <param name="type">The type value.</param>
        ///// <returns>Returns the Result.</returns>
        //public async Task<List<InOutReference>> GetReferenceListOfValues(int depotId, string type, string searchText)
        //{
        //    var api = new RestClient(this.depotHttpClient);
        //    var data = await api.GetAsync<GeneralCodeBase>("v1/gateEntry/referenceListOfValues?depotId=" + depotId + "&type=" + type + "&searchText=" + searchText);
        //    var references = string.IsNullOrEmpty(data.Code) ? new List<InOutReference>() : JsonConvert.DeserializeObject<List<InOutReference>>(data.Code);
        //    var referenceDetails = string.IsNullOrEmpty(data.Description) ? new List<InOutReferenceBase>() : JsonConvert.DeserializeObject<List<InOutReferenceBase>>(data.Description);
        //    foreach (var item in references)
        //    {
        //        item.Equipments = referenceDetails.Where(x => x.ReferenceNumber == item.ReferenceNumber).ToList();
        //        item.HasEquipments = item.Equipments.Count > 0;
        //    }

        //    return references;
        //}

        ///// <summary>
        ///// Gets the edi detail.
        ///// </summary>
        ///// <param name="depotId">The depot identifier.</param>
        ///// <param name="type">The type value.</param>
        ///// <param name="reference">The reference.</param>
        ///// <param name="containers">The containers.</param>
        ///// <param name="referenceType">Type of the reference.</param>
        ///// <returns>Returns the Result.</returns>
        //public async Task<List<ReferenceBase>> GetEdiDetail(int depotId, string type, string reference, string containers, string referenceType)
        //{
        //    var api = new RestClient(this.depotHttpClient);
        //    var references = await api.GetAsync<List<ReferenceBase>>("v1/gateEntry/ediDetail?depotId=" + depotId + "&entryType=" + type + "&referenceNumber=" + reference + "&containers=" + containers + "&referenceType=" + referenceType);
        //    return references;
        //}

        ///// <summary>
        ///// Gets the references.
        ///// </summary>
        ///// <param name="type">The type value.</param>
        ///// <param name="depotId">The depot identifier.</param>
        ///// <param name="searchText">The search text.</param>
        ///// <param name="page">The page number.</param>
        ///// <param name="pageSize">Size of the page.</param>
        ///// <returns>
        ///// Returns the Result.
        ///// </returns>
        //public async Task<PageResponse<ReferenceBase>> GetReferences(string type, int depotId, string searchText, int page, int pageSize)
        //{
        //    var api = new RestClient(this.depotHttpClient);
        //    var references = await api.GetAsync<PageResponse<ReferenceBase>>("v1/gateEntry/getReferences?depotId=" + depotId + "&type=" + type + "&searchText=" + searchText + "&page=" + page + "&pageSize=" + pageSize);
        //    return references;
        //}

        ///// <summary>
        ///// Gets the attachment file.
        ///// </summary>
        ///// <param name="entryType">Type of the entry.</param>
        ///// <param name="id">The identifier.</param>
        ///// <param name="depotId">The depot identifier.</param>
        ///// <returns>
        ///// Returns the Result.
        ///// </returns>
        //public async Task<FileAttachment> GetAttachmentFile(string entryType, int id, int depotId)
        //{
        //    var api = new RestClient(this.depotHttpClient);
        //    FileAttachment attachment = await api.GetAsync<FileAttachment>("v1/gateEntry/fileContent?entryType=" + entryType + "&entryId=" + id + "&depotId=" + depotId);
        //    return attachment;
        //}

        ///// <summary>
        ///// Gets the container list of values.
        ///// </summary>
        ///// <param name="sizeType">Type of the size.</param>
        ///// <param name="searchText">The search text.</param>
        ///// <param name="isoCodeId">The iso code identifier.</param>
        ///// <param name="page">The page.</param>
        ///// <param name="pageSize">Size of the page.</param>
        ///// <param name="referenceNumber">The reference number.</param>
        ///// <param name="carrierId">The carrier identifier.</param>
        ///// <returns></returns>
        //public async Task<PageResponse<ContainerDetail>> GetContainerListOfValues(string sizeType, string searchText, int isoCodeId, int page, int pageSize, string referenceNumber, int carrierId)
        //{
        //    string path = string.Format(
        //       CultureInfo.InvariantCulture,
        //        "sizeType={0}&searchText={1}&isoCodeId={2}&pageIndex={3}&pageSize={4}&referenceNumber={5}&depotId={6}&sortOrder={7}&sortField={8}&carrierId={9}",
        //        sizeType,
        //        searchText,
        //        isoCodeId,
        //        page,
        //        pageSize,
        //        referenceNumber,
        //        SessionManager.User.DepotId,
        //        false,
        //        null,
        //        carrierId);
        //    var api = new RestClient(this.depotHttpClient);
        //    var containers = await api.GetAsync<PageResponse<ContainerDetail>>("v1/gateEntry/getContainerListOfValues?" + path);
        //    return containers;
        //}

        ///// <summary>
        ///// Gets the reference numbers.
        ///// </summary>
        ///// <param name="type">The type.</param>
        ///// <param name="searchText">The search text.</param>
        ///// <param name="page">The page.</param>
        ///// <param name="pageSize">Size of the page.</param>
        ///// <param name="depotId">The depot identifier.</param>
        ///// <returns>
        ///// Returns the Result.
        ///// </returns>
        //public async Task<PageResponse<MasterBase>> GetReferenceNumbers(string type, string searchText, int page, int pageSize, int depotId)
        //{
        //    var api = new RestClient(this.depotHttpClient);
        //    var References = await api.GetAsync<PageResponse<MasterBase>>("v1/gateEntry/getReferenceNumbers?type=" + type + "&searchText=" + searchText + "&depotId=" + depotId + "&page=" + page + "&pageSize=" + pageSize);
        //    return References;
        //}

        ///// <summary>
        ///// Gets the container validation.
        ///// </summary>
        ///// <param name="entryType">Type of the entry.</param>
        ///// <param name="containerNumber">The container number.</param>
        ///// <param name="depotId">The depot identifier.</param>
        ///// <param name="inputData">The input data.</param>
        ///// <returns>Returns the Result.</returns>
        //public async Task<string> GetContainerValidation(string entryType, string containerNumber, int depotId, string referenceNumber = null, string fromScreen = null, string inputData = null)
        //{
        //    var api = new RestClient(this.depotHttpClient);
        //    return await api.GetAsync<string>("v1/gateEntry/getContainerValidation?entryType=" + entryType + "&containerNumber=" + containerNumber + "&depotId=" + depotId + "&referenceNumber=" + referenceNumber + "&fromScreen=" + fromScreen + "&inputData=" + inputData);
        //}

        ///// <summary>
        ///// Gets the yards.
        ///// </summary>
        ///// <param name="depotId">The depot identifier.</param>
        ///// <param name="reefermode">The reefer mode identifier.</param>
        ///// <returns>Returns the Result.</returns>
        //public async Task<SearchResponse<TransactionBase>> GetYards(int depotId, string reefermode = null)
        //{
        //    RestClient api = new RestClient(this.depotHttpClient);
        //    var response = await api.GetAsync<SearchResponse<TransactionBase>>("v1/gateEntry/getYards?depotId=" + depotId + "&reefermode=" + reefermode);
        //    return response;
        //}

        ///// <summary>
        ///// Gets the equipment list of values.
        ///// </summary>
        ///// <param name="type">The type value.</param>
        ///// <param name="searchText">The search text.</param>
        ///// <param name="depotId">The depot identifier.</param>
        ///// <param name="page">The page value.</param>
        ///// <param name="pageSize">Size of the page.</param>
        ///// <returns>Returns the result.</returns>
        //public async Task<PageResponse<MasterBase>> GetEquipmentListOfValues(string type, string searchText, int page, int pageSize, int depotId)
        //{
        //    var api = new RestClient(this.depotHttpClient);
        //    var containers = await api.GetAsync<PageResponse<MasterBase>>("v1/gateEntry/getEquipmentListOfValues?type=" + type + "&searchText=" + searchText + "&depotId=" + depotId + "&page=" + page + "&pageSize=" + pageSize);
        //    return containers;
        //}

        ///// <summary>
        ///// Gets the container detail.
        ///// </summary>
        ///// <param name="truckId">The truck identifier.</param>
        ///// <param name="depotId">The depot identifier.</param>
        ///// <returns>Returns the result.</returns>
        //public async Task<List<DropOffPickUpResult>> GetContainerDetail(int truckId, int depotId)
        //{
        //    var api = new RestClient(this.depotHttpClient);
        //    var containers = await api.GetAsync<List<DropOffPickUpResult>>("v1/gateEntry/getContainerDetail?truckId=" + truckId + "&depotId=" + depotId);
        //    return containers;
        //}

        ///// <summary>
        ///// Gets the invoice details.
        ///// </summary>
        ///// <param name="gateEntryId">The gate entry identifier.</param>
        ///// <param name="invoiceCurrencyId">The invoice currency identifier.</param>
        ///// <param name="depotId">The depot identifier.</param>
        ///// <param name="transporterId">The transporter identifier.</param>
        ///// <param name="isCustomer">if set to <c>true</c> [is customer].</param>
        ///// <returns>Returns the result.</returns>
        //public async Task<MasterBase> GetInvoiceDetails(long gateEntryId, int invoiceCurrencyId, int depotId, int? transporterId, bool isCustomer)
        //{
        //    var api = new RestClient(this.depotHttpClient);
        //    var invoiceDetail = await api.GetAsync<MasterBase>("v1/gateEntry/getInvoiceValidation?depotId=" + depotId + "&gateEntryId=" + gateEntryId + "&invoiceCurrencyId=" + invoiceCurrencyId + "&transporterId=" + transporterId + "&isCustomer=" + isCustomer);
        //    if (string.IsNullOrEmpty(invoiceDetail.Code))
        //    {
        //        var invoiceDetails = new List<GateEntryCustomerInvoice>();

        //        if (!string.IsNullOrEmpty(invoiceDetail.Description))
        //        {
        //            var list = JsonConvert.DeserializeObject<List<GateEntryInvoiceDetail>>(invoiceDetail.Description);
        //            var obj1 = list.ToLookup(l => l.Customer?.Id).Select(s => new GateEntryCustomerInvoice
        //            {
        //                ChargeDetails = s.Select(c => new GateEntryInvoiceDetail
        //                {
        //                    InvoiceType = c.InvoiceType,
        //                    GateInId = c.GateInId,
        //                    RepairEstimationId = c.RepairEstimationId,
        //                    GateOutId = c.GateOutId,
        //                    JobCardItemId = c.JobCardItemId,
        //                    CleaningId = c.CleaningId,
        //                    ContainerWeighingId = c.ContainerWeighingId,
        //                    TariffId = c.TariffId,
        //                    ContainerNumber = c.ContainerNumber,
        //                    SizeType = c.SizeType,
        //                    ServiceDate = c.ServiceDate,
        //                    Charge = c.Charge != null ? c.Charge : new ChargeBaseViewModel(),
        //                    PrintNameInLocalLanguage = c.PrintNameInLocalLanguage,
        //                    PrintName = c.PrintName,
        //                    ActivityReferenceNo = c.ActivityReferenceNo,
        //                    TariffCurrency = c.TariffCurrency != null ? c.TariffCurrency : new TransactionBase(),
        //                    DocumentReferenceNumber = c.DocumentReferenceNumber,
        //                    TariffAmount = c.TariffAmount,
        //                    InvoiceExRate = c.InvoiceExRate,
        //                    InvoiceAmount = c.InvoiceAmount,
        //                    TaxAmount = c.TaxAmount,
        //                    LocalExRate = c.LocalExRate,
        //                    LocalCurrency = c.LocalCurrency,
        //                    LocalAmount = c.LocalAmount,
        //                    ServiceType = c.ServiceType,
        //                    BusinessType = c.BusinessType,
        //                    RepairType = c.RepairType,
        //                    Customer = c.Customer,
        //                    CreditDays = c.CreditDays,
        //                    TaxId = c.TaxId,
        //                    TaxCode = c.TaxCode,
        //                    TaxPercentage = c.TaxPercentage,
        //                    MoveGroup = c.MoveGroup,
        //                    RowStatus = RecordRowStatus.Added,
        //                    Quantity = 1,
        //                    TotalAmount = CalculateTotalAmount(c.LocalAmount, c.TaxAmount),
        //                }).ToList(),
        //                Customer = s.FirstOrDefault()?.Customer,
        //                CreditDays = s.FirstOrDefault()?.CreditDays,
        //                LocalExchangeRate = s.FirstOrDefault()?.LocalExRate,
        //                TotalInvoiceAmount = 0,
        //            }).ToList();
        //            foreach (var item in obj1)
        //            {
        //                item.TotalInvoiceAmount = item.ChargeDetails.Sum(s => s.TotalAmount);
        //            }
        //            invoiceDetails = obj1;
        //        }
        //        if (!string.IsNullOrEmpty(invoiceDetail.Name))
        //        {
        //            var customerList = JsonConvert.DeserializeObject<List<GateEntryCustomerInvoice>>(invoiceDetail.Name);
        //            foreach (var item in customerList)
        //            {
        //                var flag = invoiceDetails.Exists(f => f.Customer?.Id == item.Customer?.Id);
        //                if (!flag)
        //                {
        //                    item.ChargeDetails = new List<GateEntryInvoiceDetail>();
        //                    invoiceDetails.Add(item);
        //                }
        //            }
        //        }
        //        invoiceDetail.Description = JsonConvert.SerializeObject(invoiceDetails);
        //    }
        //    return invoiceDetail;
        //}

        ///// <summary>
        ///// Gets the invoice container.
        ///// </summary>
        ///// <param name="truckId">The truck identifier.</param>
        ///// <param name="customerId">The customer identifier.</param>
        ///// <param name="depotId">The depot identifier.</param>
        ///// <returns>Returns the result.</returns>
        //public async Task<List<MasterBase>> GetInvoiceContainer(long truckId, int? customerId, int depotId)
        //{
        //    var api = new RestClient(this.depotHttpClient);
        //    return await api.GetAsync<List<MasterBase>>("v1/gateEntry/getInvoiceContainer?depotId=" + depotId + "&truckId=" + truckId + "&customerId=" + customerId);
        //}

        ///// <summary>
        ///// Declare Dispose.
        ///// </summary>
        //public void Dispose()
        //{
        //    this.depotHttpClient?.Dispose();
        //}

        ///// <summary>
        ///// Get Gate Entry Service Instance.
        ///// </summary>
        ///// <returns>
        ///// Returns the Result.
        ///// </returns>
        //private static GateEntryServiceReader GetGateEntryServiceInstance()
        //{
        //    return new GateEntryServiceReader();
        //}

        ///// <summary>
        ///// Calculates the total amount.
        ///// </summary>
        ///// <param name="localAmount">The local amount.</param>
        ///// <param name="taxLocalAmount">The tax local amount.</param>
        ///// <returns>Returns the Result.</returns>
        //private static decimal? CalculateTotalAmount(string localAmount, decimal? taxLocalAmount)
        //{
        //    if (!string.IsNullOrEmpty(localAmount))
        //    {
        //        var taxlocal = taxLocalAmount != null ? taxLocalAmount : 0;
        //        return SimpleConvert.ToDecimal(localAmount) + taxlocal;
        //    }
        //    else
        //    {
        //        return default(decimal);
        //    }
        //}
    }
}
