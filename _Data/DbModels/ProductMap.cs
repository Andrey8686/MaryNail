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
    internal partial class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap(string schema = "dbo")
        {
            ToTable(schema + ".Products");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired();
            Property(x => x.ProductTypeId).HasColumnName("ProductTypeId").IsRequired();
            Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(100);
            Property(x => x.Description).HasColumnName("Description").IsOptional();
            Property(x => x.TimeCost).HasColumnName("TimeCost").IsRequired();
            Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            Property(x => x.IsActive).HasColumnName("IsActive").IsRequired();
            Property(x => x.DummyId).HasColumnName("DummyId").IsOptional();

            HasRequired(a => a.ProductType).WithMany(b => b.Products).HasForeignKey(c => c.ProductTypeId);
            HasOptional(a => a.Dummye).WithMany(b => b.Products).HasForeignKey(c => c.DummyId);
            HasMany(t => t.Services).WithMany(t => t.Products).Map(m => 
            {
                m.ToTable("Produt_Service", schema);
                m.MapLeftKey("ProductId");
                m.MapRightKey("ServiceId");
            });
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
