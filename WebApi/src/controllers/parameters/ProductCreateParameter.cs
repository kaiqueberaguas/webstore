﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.src.models;

namespace webApi.src.controllers.parameters
{
    public class ProductCreateParameter
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Information { get; set; }
        public long AvailableQuantity { get; set; }
        public DateTime LimitDate { get; set; }
        public DateTime PurchaseDate { get; set; }
        public SubcategoryParameter Subcategory { get; set; }
        
        public Product ToModel()
        {
            var product = new Product();
            product.Name = Name;
            product.Description = Description;
            product.Information = Information;
            product.AvailableQuantity = AvailableQuantity;
            product.LimitDate = LimitDate;
            product.PurchaseDate = PurchaseDate;
            product.Subcategory = Subcategory.ToModel();
            return product;
        }
    }
}