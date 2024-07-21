using Microsoft.AspNetCore.Mvc;

namespace ReactWithASP.Controllers
{
    public class GateEntryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
