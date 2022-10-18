﻿using FinCtrl.Backend.Core.RestAPI.DAL.Interface;

namespace FinCtrl.Backend.Core.RestAPI.DAL.Models
{
    public class Category : IEntity, ITimeLoggingEntity
    {
        public Category(int categoryId, string categoryName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime LastUpdatedAt { get; private set; }

        public int ID => CategoryId;


    }
}
