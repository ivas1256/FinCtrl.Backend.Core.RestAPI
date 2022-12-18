using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FinCtrl.Backend.Core.RestAPI.DAL.Models;
using FinCtrl.Backend.Core.RestAPI.Controllers.BaseControllers;
using FinCtrl.Backend.Core.RestAPI.DAL.Implementation;
using FinCtrl.Backend.Core.RestAPI.DAL.DTO.ModelDTO;
using AutoMapper;

namespace FinCtrl.Backend.Core.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : CRUDController<Category, CategoryDTO, CategoryRepository>
    {
        public CategoriesController(CategoryRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }


        [HttpGet("plain-list")]
        public List<CategoryDTO> GetPlainList()
        {
            return _repository.GetPlainList();
        }
    }
}
