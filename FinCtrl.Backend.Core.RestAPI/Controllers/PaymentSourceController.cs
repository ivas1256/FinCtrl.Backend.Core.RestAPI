using FinCtrl.Backend.Core.RestAPI.Controllers.BaseControllers;
using FinCtrl.Backend.Core.RestAPI.DAL.Implementation;
using FinCtrl.Backend.Core.RestAPI.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinCtrl.Backend.Core.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentSourceController : CRUDController<PaymentSource, PaymentSourceRepository>
    {
        public PaymentSourceController(PaymentSourceRepository repository) : base(repository)
        {
        }

        

        [HttpGet("set_category/{id}")]
        public async void SetCategoryAsync(int id, int categoryId)
        {
            repository.SetCategoryAsync(id, categoryId);
        }
    }
}
