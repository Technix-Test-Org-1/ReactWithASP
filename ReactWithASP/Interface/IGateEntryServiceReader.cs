using Microsoft.AspNetCore.Mvc;
using Msc.Framework.Common.Model.Pagination;
using ReactWithASP.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReactWithASP.Interface
{
    public interface IGateEntryServiceReader
    {
        //Task<PageResponse<MasterBase>> GetCarriers(string role, int depotId, string searchText, int? page, int? pageSize);
        Task<PageResponse<MasterBase>> GetCarriers(string role, int depotId);
        Task<PageResponse<GateEntryInOutResult>> GetList(AdvanceSearchRequest request);

    }
}
