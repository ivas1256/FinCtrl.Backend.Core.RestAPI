using Microsoft.AspNetCore.Mvc;

namespace FinCtrl.Website.Controllers
{
    public class PaymentSourceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
