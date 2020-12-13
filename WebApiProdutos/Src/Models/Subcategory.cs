using Castle.Core.Internal;
using System;
using System.Collections.Generic;

namespace WebApiProdutos.Src.Models
{
    public class Subcategory : Entity
    {
        public override long? Id { get; set; }
        public string Name { get; set; }
        public override long? Code { get; set; }
        public string Description { get; set; }
        public virtual Category Category { get; set; }
        public virtual long? CategoryId { get; set; }
        public virtual List<Product> Products { get; set; }
        public override DateTime? LastModification { get; set; }
        public override DateTime? RegisterDate { get; set; }
        public override bool? IsActive { get => base.IsActive; set => base.IsActive = value; }

        public override bool Equals(object obj)
        {
            return obj is Subcategory subcategory &&
                   Id == subcategory.Id &&
                   LastModification == subcategory.LastModification &&
                   RegisterDate == subcategory.RegisterDate &&
                   Id == subcategory.Id &&
                   Name == subcategory.Name &&
                   Code == subcategory.Code &&
                   Description == subcategory.Description &&
                   EqualityComparer<Category>.Default.Equals(Category, subcategory.Category) &&
                   CategoryId == subcategory.CategoryId &&
                   EqualityComparer<List<Product>>.Default.Equals(Products, subcategory.Products) &&
                   LastModification == subcategory.LastModification &&
                   RegisterDate == subcategory.RegisterDate;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Name);
            hash.Add(DateTime.Now);
            return hash.ToHashCode();
        }
        public override void PrepareCreateRecord()
        {
            base.PrepareCreateRecord();
            Code = GetHashCode();
            if (Code < 0) Code *= -1;
        }

        public void Update(Subcategory subcategory)
        {
            if (!subcategory.Name.IsNullOrEmpty()) Name = subcategory.Name;
            if (!subcategory.Description.IsNullOrEmpty()) Description = subcategory.Description;
            if (subcategory.Category != null && subcategory.Category.Code != null)
            {
                Category = subcategory.Category;
                CategoryId = subcategory.Category.Id;
            }
        }


    }
}
