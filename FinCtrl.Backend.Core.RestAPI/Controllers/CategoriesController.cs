﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FinCtrl.Backend.Core.RestAPI.DAL.Models;
using FinCtrl.Backend.Core.RestAPI.Controllers.BaseControllers;
using FinCtrl.Backend.Core.RestAPI.DAL.Implementation;

namespace FinCtrl.Backend.Core.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : CRUDController<Category, CategoryRepository>
    {
        public CategoriesController(CategoryRepository repository) : base(repository)
        {
        }
    }
}
