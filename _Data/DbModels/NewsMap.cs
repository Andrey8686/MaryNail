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
    internal partial class NewsMap : EntityTypeConfiguration<News>
    {
        public NewsMap(string schema = "dbo")
        {
            ToTable(schema + ".News");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired();
            Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(300);
            Property(x => x.Description).HasColumnName("Description").IsRequired().HasMaxLength(1000);
            Property(x => x.FullText).HasColumnName("FullText").IsRequired().IsUnicode(false).HasMaxLength(2147483647);
            Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            Property(x => x.IsActive).HasColumnName("IsActive").IsRequired();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
