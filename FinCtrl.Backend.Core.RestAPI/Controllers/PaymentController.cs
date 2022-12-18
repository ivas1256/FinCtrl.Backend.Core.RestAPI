using FinCtrl.Backend.Core.RestAPI.Controllers.BaseControllers;
using FinCtrl.Backend.Core.RestAPI.DAL.Models;
using FinCtrl.Backend.Core.RestAPI.DAL.Implementation;
using Microsoft.AspNetCore.Mvc;
using FinCtrl.Backend.Core.RestAPI.DAL.DTO.ModelDTO;
using AutoMapper;

namespace FinCtrl.Backend.Core.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : CRUDController<Payment, PaymentDTO, PaymentRepository>
    {
        public PaymentController(PaymentRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
        
        [HttpGet("total-count")]
        public ActionResult<int> TotalCount()
        {
            return _repository.TotalCount();
        }
    }
}
