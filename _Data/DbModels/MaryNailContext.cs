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
    public partial class MaryNailContext : DbContext, IMaryNailContext
    {
        public IDbSet<AspNetRole> AspNetRoles { get; set; }
        public IDbSet<AspNetUser> AspNetUsers { get; set; }
        public IDbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public IDbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public IDbSet<Dummye> Dummyes { get; set; }
        public IDbSet<NailDesign> NailDesigns { get; set; }
        public IDbSet<NailDesignType> NailDesignTypes { get; set; }
        public IDbSet<News> News { get; set; }
        public IDbSet<Order> Orders { get; set; }
        public IDbSet<OrderItem> OrderItems { get; set; }
        public IDbSet<Product> Products { get; set; }
        public IDbSet<ProductPhoto> ProductPhotoes { get; set; }
        public IDbSet<ProductType> ProductTypes { get; set; }
        public IDbSet<Service> Services { get; set; }
        public IDbSet<sysdiagram> sysdiagrams { get; set; }

        static MaryNailContext()
        {
            Database.SetInitializer<MaryNailContext>(null);
        }

        public MaryNailContext()
            : base("Name=DefaultConnection")
        {
            InitializePartial();
        }

        public MaryNailContext(string connectionString) : base(connectionString)
        {
            InitializePartial();
        }

        public MaryNailContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model) : base(connectionString, model)
        {
            InitializePartial();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AspNetRoleMap());
            modelBuilder.Configurations.Add(new AspNetUserMap());
            modelBuilder.Configurations.Add(new AspNetUserClaimMap());
            modelBuilder.Configurations.Add(new AspNetUserLoginMap());
            modelBuilder.Configurations.Add(new DummyeMap());
            modelBuilder.Configurations.Add(new NailDesignMap());
            modelBuilder.Configurations.Add(new NailDesignTypeMap());
            modelBuilder.Configurations.Add(new NewsMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new OrderItemMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new ProductPhotoMap());
            modelBuilder.Configurations.Add(new ProductTypeMap());
            modelBuilder.Configurations.Add(new ServiceMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());

            OnModelCreatingPartial(modelBuilder);
        }

        public static DbModelBuilder CreateModel(DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new AspNetRoleMap(schema));
            modelBuilder.Configurations.Add(new AspNetUserMap(schema));
            modelBuilder.Configurations.Add(new AspNetUserClaimMap(schema));
            modelBuilder.Configurations.Add(new AspNetUserLoginMap(schema));
            modelBuilder.Configurations.Add(new DummyeMap(schema));
            modelBuilder.Configurations.Add(new NailDesignMap(schema));
            modelBuilder.Configurations.Add(new NailDesignTypeMap(schema));
            modelBuilder.Configurations.Add(new NewsMap(schema));
            modelBuilder.Configurations.Add(new OrderMap(schema));
            modelBuilder.Configurations.Add(new OrderItemMap(schema));
            modelBuilder.Configurations.Add(new ProductMap(schema));
            modelBuilder.Configurations.Add(new ProductPhotoMap(schema));
            modelBuilder.Configurations.Add(new ProductTypeMap(schema));
            modelBuilder.Configurations.Add(new ServiceMap(schema));
            modelBuilder.Configurations.Add(new sysdiagramMap(schema));
            return modelBuilder;
        }

        partial void InitializePartial();
        partial void OnModelCreatingPartial(DbModelBuilder modelBuilder);
        
        // Stored Procedures
    }
}
