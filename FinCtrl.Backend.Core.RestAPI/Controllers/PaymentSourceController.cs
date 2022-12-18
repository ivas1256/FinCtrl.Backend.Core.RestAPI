using AutoMapper;
using FinCtrl.Backend.Core.RestAPI.Controllers.BaseControllers;
using FinCtrl.Backend.Core.RestAPI.DAL.DTO.ModelDTO;
using FinCtrl.Backend.Core.RestAPI.DAL.Implementation;
using FinCtrl.Backend.Core.RestAPI.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinCtrl.Backend.Core.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentSourceController : CRUDController<PaymentSource, PaymentSourceDTO, PaymentSourceRepository>
    {
        public PaymentSourceController(PaymentSourceRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }        

        [HttpGet("set_category/{id}")]
        public void SetCategory(int id, int categoryId)
        {
            _repository.SetCategory(id, categoryId);
        }
    }
}
