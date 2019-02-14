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
    internal partial class OrderItemMap : EntityTypeConfiguration<OrderItem>
    {
        public OrderItemMap(string schema = "dbo")
        {
            ToTable(schema + ".OrderItems");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.OrderId).HasColumnName("OrderId").IsRequired();
            Property(x => x.ServiceId).HasColumnName("ServiceId").IsRequired();
            Property(x => x.ProductId).HasColumnName("ProductId").IsOptional();
            Property(x => x.DummyId).HasColumnName("DummyId").IsOptional();

            HasRequired(a => a.Order).WithMany(b => b.OrderItems).HasForeignKey(c => c.OrderId);
            HasRequired(a => a.Service).WithMany(b => b.OrderItems).HasForeignKey(c => c.ServiceId);
            HasOptional(a => a.Product).WithMany(b => b.OrderItems).HasForeignKey(c => c.ProductId);
            HasOptional(a => a.Dummye).WithMany(b => b.OrderItems).HasForeignKey(c => c.DummyId);
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
