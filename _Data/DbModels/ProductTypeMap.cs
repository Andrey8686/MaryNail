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
    internal partial class ProductTypeMap : EntityTypeConfiguration<ProductType>
    {
        public ProductTypeMap(string schema = "dbo")
        {
            ToTable(schema + ".ProductTypes");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired();
            Property(x => x.ProductTypeId).HasColumnName("ProductTypeId").IsOptional();
            Property(x => x.Name).HasColumnName("Name").IsOptional().HasMaxLength(100);
            Property(x => x.IsActive).HasColumnName("IsActive").IsRequired();
            Property(x => x.OrderBy).HasColumnName("OrderBy").IsRequired();

            HasOptional(a => a.ProductType_ProductTypeId).WithMany(b => b.ProductTypes).HasForeignKey(c => c.ProductTypeId);
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
