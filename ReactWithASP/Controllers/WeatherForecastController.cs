using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReactWithASP.Interface;
using ReactWithASP.UIServices;

namespace ReactWithASP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IGateEntryServiceReader serviceInterface;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            IGateEntryServiceReader gateEntry;
            _logger = logger;
            //this.serviceInterface = gateEntry;
        }

        //public WeatherForecastController(IGateEntryServiceReader serviceInterface)
        //{
        //    this.serviceInterface = serviceInterface;
        //}

        //private readonly GateEntryServiceReader masterServiceClient;

        //public WeatherForecastController(GateEntryServiceReader masterServiceClient)
        //{
        //    this.masterServiceClient = masterServiceClient;
        //}
        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var rng = new Random();
            string resultMsg;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api-tst.identity.msc.com/tst/ovd/GatePassRead/api/");
                //HTTP GET
                var responseTask = client.GetAsync($"v1/gateEntry/carriers?role=T&depotId=22844");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    resultMsg = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        //public async Task<IEnumerable<WeatherForecast>> Get2(string role, int depotId)
        //{
        //    var rng = new Random();
        //    string resultMsg;
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://api-tst.identity.msc.com/tst/ovd/GatePassRead/api/");
        //        //HTTP GET
        //        var responseTask = client.GetAsync($"v1/gateEntry/carriers?role={role}&depotId={depotId}");
        //        responseTask.Wait();

        //        var result = responseTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var readTask = result.Content.ReadAsStringAsync();
        //            readTask.Wait();

        //            resultMsg = readTask.Result;
        //        }
        //        else //web api sent error response 
        //        {
        //            //log response status here..
        //            ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
        //        }
        //    }
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        //[HttpGet]
        //public async Task<object> GetCarriers(string role, int depotId)
        //{
        //    var carriers = await serviceInterface.GetCarriers(role, depotId);
        //    return carriers;
        //}
    }
}
