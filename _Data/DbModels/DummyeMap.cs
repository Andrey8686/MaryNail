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
    internal partial class DummyeMap : EntityTypeConfiguration<Dummye>
    {
        public DummyeMap(string schema = "dbo")
        {
            ToTable(schema + ".Dummyes");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired();
            Property(x => x.AspNetUsersId).HasColumnName("AspNetUsersId").IsOptional().HasMaxLength(128);
            Property(x => x.Name).HasColumnName("Name").IsOptional().HasMaxLength(100);
            Property(x => x.h1Id).HasColumnName("h1Id").IsOptional();
            Property(x => x.h2Id).HasColumnName("h2Id").IsOptional();
            Property(x => x.h3Id).HasColumnName("h3Id").IsOptional();
            Property(x => x.h4Id).HasColumnName("h4Id").IsOptional();
            Property(x => x.h5Id).HasColumnName("h5Id").IsOptional();
            Property(x => x.h6Id).HasColumnName("h6Id").IsOptional();
            Property(x => x.h7Id).HasColumnName("h7Id").IsOptional();
            Property(x => x.h8Id).HasColumnName("h8Id").IsOptional();
            Property(x => x.h9Id).HasColumnName("h9Id").IsOptional();
            Property(x => x.h10Id).HasColumnName("h10Id").IsOptional();

            HasOptional(a => a.AspNetUser).WithMany(b => b.Dummyes).HasForeignKey(c => c.AspNetUsersId);
            HasOptional(a => a.NailDesign_h1Id).WithMany(b => b.Dummyes_h1Id).HasForeignKey(c => c.h1Id);
            HasOptional(a => a.NailDesign_h2Id).WithMany(b => b.Dummyes_h2Id).HasForeignKey(c => c.h2Id);
            HasOptional(a => a.NailDesign_h3Id).WithMany(b => b.Dummyes_h3Id).HasForeignKey(c => c.h3Id);
            HasOptional(a => a.NailDesign_h4Id).WithMany(b => b.Dummyes_h4Id).HasForeignKey(c => c.h4Id);
            HasOptional(a => a.NailDesign_h5Id).WithMany(b => b.Dummyes_h5Id).HasForeignKey(c => c.h5Id);
            HasOptional(a => a.NailDesign_h6Id).WithMany(b => b.Dummyes_h6Id).HasForeignKey(c => c.h6Id);
            HasOptional(a => a.NailDesign_h7Id).WithMany(b => b.Dummyes_h7Id).HasForeignKey(c => c.h7Id);
            HasOptional(a => a.NailDesign_h8Id).WithMany(b => b.Dummyes_h8Id).HasForeignKey(c => c.h8Id);
            HasOptional(a => a.NailDesign_h9Id).WithMany(b => b.Dummyes_h9Id).HasForeignKey(c => c.h9Id);
            HasOptional(a => a.NailDesign_h10Id).WithMany(b => b.Dummyes_h10Id).HasForeignKey(c => c.h10Id);
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
