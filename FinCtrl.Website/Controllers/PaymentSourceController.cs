using FinCtrl.Backend.Core.RestAPI.DAL.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace FinCtrl.Website.Controllers
{
    public class PaymentSourceController : Controller
    {
        PaymentSourceRepository _paymentSourceRepository;

        public PaymentSourceController(PaymentSourceRepository paymentSourceRepository)
        {
            _paymentSourceRepository = paymentSourceRepository;
        }

        [Route("payment-source")]
        public IActionResult Index()
        {
            var list = _paymentSourceRepository.GetAll();

            return View(list);
        }
    }
}
