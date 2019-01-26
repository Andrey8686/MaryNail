// ReSharper disable RedundantUsingDirective
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier
// TargetFrameworkVersion = 4.61

using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity.ModelConfiguration;
//using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.DatabaseGeneratedOption;

namespace _Data.Models
{
    public partial class Product
    {
        public Guid Id { get; set; }
        public Guid ProductTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TimeCost { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public Guid? DummyId { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<ProductPhoto> ProductPhotoes { get; set; }
        public virtual ICollection<Service> Services { get; set; }

        public virtual Dummye Dummye { get; set; }
        public virtual ProductType ProductType { get; set; }

        public Product()
        {
            Id = System.Guid.NewGuid();
            TimeCost = 0;
            CreatedDate = System.DateTime.Now;
            IsActive = true;
            OrderItems = new List<OrderItem>();
            ProductPhotoes = new List<ProductPhoto>();
            Services = new List<Service>();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
