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
    public partial class ProductType
    {
        public Guid Id { get; set; }
        public Guid? ProductTypeId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int OrderBy { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ProductType> ProductTypes { get; set; }

        public virtual ProductType ProductType_ProductTypeId { get; set; }

        public ProductType()
        {
            Id = System.Guid.NewGuid();
            IsActive = true;
            OrderBy = 0;
            Products = new List<Product>();
            ProductTypes = new List<ProductType>();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
