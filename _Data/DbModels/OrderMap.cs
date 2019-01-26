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
    internal partial class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap(string schema = "dbo")
        {
            ToTable(schema + ".Orders");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.AspNetUsersId).HasColumnName("AspNetUsersId").IsRequired().HasMaxLength(128);
            Property(x => x.Comment).HasColumnName("Comment").IsOptional();
            Property(x => x.StartTime).HasColumnName("StartTime").IsRequired();
            Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsRequired();

            HasRequired(a => a.AspNetUser).WithMany(b => b.Orders).HasForeignKey(c => c.AspNetUsersId);
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
