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
    public partial class Dummye
    {
        public Guid Id { get; set; }
        public string AspNetUsersId { get; set; }
        public string Name { get; set; }
        public Guid? h1Id { get; set; }
        public Guid? h2Id { get; set; }
        public Guid? h3Id { get; set; }
        public Guid? h4Id { get; set; }
        public Guid? h5Id { get; set; }
        public Guid? h6Id { get; set; }
        public Guid? h7Id { get; set; }
        public Guid? h8Id { get; set; }
        public Guid? h9Id { get; set; }
        public Guid? h10Id { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
        public virtual NailDesign NailDesign_h10Id { get; set; }
        public virtual NailDesign NailDesign_h1Id { get; set; }
        public virtual NailDesign NailDesign_h2Id { get; set; }
        public virtual NailDesign NailDesign_h3Id { get; set; }
        public virtual NailDesign NailDesign_h4Id { get; set; }
        public virtual NailDesign NailDesign_h5Id { get; set; }
        public virtual NailDesign NailDesign_h6Id { get; set; }
        public virtual NailDesign NailDesign_h7Id { get; set; }
        public virtual NailDesign NailDesign_h8Id { get; set; }
        public virtual NailDesign NailDesign_h9Id { get; set; }

        public Dummye()
        {
            Id = System.Guid.NewGuid();
            Products = new List<Product>();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
