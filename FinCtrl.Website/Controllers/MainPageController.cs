using Microsoft.AspNetCore.Mvc;

namespace FinCtrl.Website.Controllers
{
    
    public class MainPageController : Controller
    {
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
