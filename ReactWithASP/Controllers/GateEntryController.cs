using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Msc.Framework.Common.Model.Pagination;
using Newtonsoft.Json;
using ReactWithASP.Interface;
using ReactWithASP.UIServices;
using ReactWithASP.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReactWithASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class GateEntryController : Controller
    {
        private readonly IGateEntryServiceReader serviceInterface;

        public GateEntryController(IGateEntryServiceReader serviceInterface)
        {
            this.serviceInterface = serviceInterface;
        }
        
        private readonly GateEntryServiceReader masterServiceClient;

       
        [HttpGet("GetCarriers")]
        public async Task<JsonResult> GetCarriers(string role, int depotId)
        {
            var carriers = await serviceInterface.GetCarriers(role, depotId);
            return this.Json(new { Data = carriers });
        }
        [HttpGet("GetList")]
        public async Task<JsonResult> GetList([FromQuery]AdvanceSearchRequest request)
        {
            var data = await serviceInterface.GetList(request);
            return this.Json(new { Data = JsonConvert.SerializeObject(data.Items), Total = Convert.ToInt32(data.TotalCount) });
        }
        [HttpGet("GetEquipmentListOfValues")]
        public async Task<JsonResult> GetEquipmentListOfValues(string type, string searchText, int page, int pageSize, int depotId = 0)
        {
            var equipments = await serviceInterface.GetEquipmentListOfValues(type, searchText, page, pageSize, depotId);
            return this.Json(new { Data = JsonConvert.SerializeObject(equipments.Items), Total = Convert.ToInt32(equipments.TotalCount) });
        }
    }
}
