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
    public interface IMaryNailContext : IDisposable
    {
        IDbSet<AspNetRole> AspNetRoles { get; set; }
        IDbSet<AspNetUser> AspNetUsers { get; set; }
        IDbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        IDbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        IDbSet<Dummye> Dummyes { get; set; }
        IDbSet<NailDesign> NailDesigns { get; set; }
        IDbSet<NailDesignType> NailDesignTypes { get; set; }
        IDbSet<News> News { get; set; }
        IDbSet<Order> Orders { get; set; }
        IDbSet<OrderItem> OrderItems { get; set; }
        IDbSet<Product> Products { get; set; }
        IDbSet<ProductType> ProductTypes { get; set; }
        IDbSet<Service> Services { get; set; }
        IDbSet<sysdiagram> sysdiagrams { get; set; }

        int SaveChanges();
        
        // Stored Procedures
    }

}
