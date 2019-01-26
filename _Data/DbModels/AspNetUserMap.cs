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
    internal partial class AspNetUserMap : EntityTypeConfiguration<AspNetUser>
    {
        public AspNetUserMap(string schema = "dbo")
        {
            ToTable(schema + ".AspNetUsers");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasMaxLength(128).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Email).HasColumnName("Email").IsOptional().HasMaxLength(256);
            Property(x => x.EmailConfirmed).HasColumnName("EmailConfirmed").IsRequired();
            Property(x => x.PasswordHash).HasColumnName("PasswordHash").IsOptional();
            Property(x => x.SecurityStamp).HasColumnName("SecurityStamp").IsOptional();
            Property(x => x.PhoneNumber).HasColumnName("PhoneNumber").IsOptional();
            Property(x => x.PhoneNumberConfirmed).HasColumnName("PhoneNumberConfirmed").IsRequired();
            Property(x => x.TwoFactorEnabled).HasColumnName("TwoFactorEnabled").IsRequired();
            Property(x => x.LockoutEndDateUtc).HasColumnName("LockoutEndDateUtc").IsOptional();
            Property(x => x.LockoutEnabled).HasColumnName("LockoutEnabled").IsRequired();
            Property(x => x.AccessFailedCount).HasColumnName("AccessFailedCount").IsRequired();
            Property(x => x.UserName).HasColumnName("UserName").IsRequired().HasMaxLength(256);
            Property(x => x.Name).HasColumnName("Name").IsOptional().HasMaxLength(30);
            Property(x => x.LastName).HasColumnName("LastName").IsOptional().HasMaxLength(30);
            Property(x => x.Patronymic).HasColumnName("Patronymic").IsOptional().HasMaxLength(30);
            Property(x => x.DateOfBirth).HasColumnName("DateOfBirth").IsOptional();
            Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            Property(x => x.AgreeToReceiveEmailMessages).HasColumnName("AgreeToReceiveEmailMessages").IsRequired();
            Property(x => x.AgreeToReceiveSmsMessages).HasColumnName("AgreeToReceiveSmsMessages").IsRequired();
            Property(x => x.AgreeToTheProcessingOfPersonalData).HasColumnName("AgreeToTheProcessingOfPersonalData").IsRequired();
            Property(x => x.AgreeWithTheRules).HasColumnName("AgreeWithTheRules").IsRequired();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
