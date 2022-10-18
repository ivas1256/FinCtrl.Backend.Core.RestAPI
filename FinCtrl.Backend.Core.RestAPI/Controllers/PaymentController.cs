using FinCtrl.Backend.Core.RestAPI.Controllers.BaseControllers;
using FinCtrl.Backend.Core.RestAPI.DAL.Models;
using FinCtrl.Backend.Core.RestAPI.DAL.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace FinCtrl.Backend.Core.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : CRUDController<Payment, PaymentRepository>
    {
        public PaymentController(PaymentRepository repository) : base(repository)
        {
        }
    }
}
