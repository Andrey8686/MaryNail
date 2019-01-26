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
    internal partial class NailDesignMap : EntityTypeConfiguration<NailDesign>
    {
        public NailDesignMap(string schema = "dbo")
        {
            ToTable(schema + ".NailDesigns");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired();
            Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
            Property(x => x.TimeOut).HasColumnName("TimeOut").IsRequired();
            Property(x => x.Price).HasColumnName("Price").IsRequired();
            Property(x => x.OrderBy).HasColumnName("OrderBy").IsRequired();
            Property(x => x.IsActive).HasColumnName("IsActive").IsRequired();
            HasMany(t => t.NailDesignTypes).WithMany(t => t.NailDesigns).Map(m => 
            {
                m.ToTable("NailDesignType_NailDesign", schema);
                m.MapLeftKey("NailDesignId");
                m.MapRightKey("NailDesignTypeId");
            });
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
