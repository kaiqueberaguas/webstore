﻿using System;
using webApi.src.models;

namespace WebApi.src.presenters
{
    public class ProductPresenter
    {
        public string Name { get; }
        public long ProductCode { get; }
        public string Description { get; }
        public string Information { get; }
        public decimal Amount { get; set; }
        public long AvailableQuantity { get; }
        public DateTime LimitDate { get; }
        public bool IsActive { get; set; }

        public ProductPresenter(Product product)
        {
            Name = product.Name;
            ProductCode = product.Code.GetValueOrDefault();
            Description = product.Description;
            Amount = Amount;
            Information = product.Information;
            IsActive = product.IsActive.GetValueOrDefault();
            AvailableQuantity = product.AvailableQuantity.Value;
            LimitDate = product.LimitDate;
        }
    }
}