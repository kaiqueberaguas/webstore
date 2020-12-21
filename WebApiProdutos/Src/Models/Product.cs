using Castle.Core.Internal;
using System;
using System.Collections.Generic;

namespace WebApiProdutos.Src.Models
{
    public class Product : Entity
    {
        public override long? Id { get; set; }
        public string Name { get; set; }
        public override long? Code { get; set; }
        public string Description { get; set; }
        public string Information { get; set; }
        public virtual Subcategory Subcategory { get; set; }
        public virtual long? SubcategoryId { get; set; }
        public long? AvailableQuantity { get; set; }
        public DateTime LimitDate { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal Amount { get; set; }
        public override DateTime? LastModification { get; set; }
        public override DateTime? RegisterDate { get; set; }
        public override bool? IsActive { get => base.IsActive; set => base.IsActive = value; }

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   Id == product.Id &&
                   LastModification == product.LastModification &&
                   RegisterDate == product.RegisterDate &&
                   Id == product.Id &&
                   Name == product.Name &&
                   Code == product.Code &&
                   Description == product.Description &&
                   Information == product.Information &&
                   EqualityComparer<Subcategory>.Default.Equals(Subcategory, product.Subcategory) &&
                   SubcategoryId == product.SubcategoryId &&
                   AvailableQuantity == product.AvailableQuantity &&
                   LimitDate == product.LimitDate &&
                   PurchaseDate == product.PurchaseDate &&
                   Amount == product.Amount &&
                   LastModification == product.LastModification &&
                   RegisterDate == product.RegisterDate;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Name);
            hash.Add(Amount);
            hash.Add(DateTime.Now);
            return hash.ToHashCode();
        }

        public override void PrepareToCreateRegister()
        {
            base.PrepareToCreateRegister();
            Code = GetHashCode();
            if (Code < 0) Code *= -1;
        }

        public void Update(Product product)
        {
            if (!product.Name.IsNullOrEmpty()) Name = product.Name;
            if (!product.Description.IsNullOrEmpty()) Description = product.Description;
            if (!product.Information.IsNullOrEmpty()) Information = product.Information;
            if (product.Subcategory != null && product.Subcategory.Id != null)
            {
                Subcategory = product.Subcategory;
                SubcategoryId = product.Subcategory.Id;
            }

            if (product.LimitDate != null) LimitDate = product.LimitDate;
            if (product.PurchaseDate != null) PurchaseDate = product.PurchaseDate;
            if (product.AvailableQuantity != null) AvailableQuantity = product.AvailableQuantity;
        }
    }
}
