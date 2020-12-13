using Castle.Core.Internal;
using System;
using System.Collections.Generic;

namespace WebApiProdutos.Src.Models
{
    public class Category : Entity
    {
        public override long? Id { get; set; }
        public string Name { get; set; }
        public override long? Code { get; set; }
        public string Description { get; set; }
        public virtual List<Subcategory> Subcategories { get; set; }
        public override DateTime? LastModification { get; set; }
        public override DateTime? RegisterDate { get; set; }
        public override bool? IsActive { get => base.IsActive; set => base.IsActive = value; }

        public override bool Equals(object obj)
        {
            return obj is Category category &&
                   Id == category.Id &&
                   LastModification == category.LastModification &&
                   RegisterDate == category.RegisterDate &&
                   Id == category.Id &&
                   Name == category.Name &&
                   Code == category.Code &&
                   Description == category.Description &&
                   EqualityComparer<List<Subcategory>>.Default.Equals(Subcategories, category.Subcategories) &&
                   LastModification == category.LastModification &&
                   RegisterDate == category.RegisterDate;
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

        public void Update(Category category)
        {
            if (!category.Name.IsNullOrEmpty()) Name = category.Name;
            if (!category.Description.IsNullOrEmpty()) Description = category.Description;
            if (category.IsActive != null) IsActive = category.IsActive;
        }


    }
}
