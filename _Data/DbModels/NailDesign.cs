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
    public partial class NailDesign
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int TimeOut { get; set; }
        public int Price { get; set; }
        public int OrderBy { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Dummye> Dummyes_h10Id { get; set; }
        public virtual ICollection<Dummye> Dummyes_h1Id { get; set; }
        public virtual ICollection<Dummye> Dummyes_h2Id { get; set; }
        public virtual ICollection<Dummye> Dummyes_h3Id { get; set; }
        public virtual ICollection<Dummye> Dummyes_h4Id { get; set; }
        public virtual ICollection<Dummye> Dummyes_h5Id { get; set; }
        public virtual ICollection<Dummye> Dummyes_h6Id { get; set; }
        public virtual ICollection<Dummye> Dummyes_h7Id { get; set; }
        public virtual ICollection<Dummye> Dummyes_h8Id { get; set; }
        public virtual ICollection<Dummye> Dummyes_h9Id { get; set; }
        public virtual ICollection<NailDesignType> NailDesignTypes { get; set; }

        public NailDesign()
        {
            Id = System.Guid.NewGuid();
            TimeOut = 0;
            Price = 0;
            OrderBy = 0;
            IsActive = true;
            Dummyes_h10Id = new List<Dummye>();
            Dummyes_h1Id = new List<Dummye>();
            Dummyes_h2Id = new List<Dummye>();
            Dummyes_h3Id = new List<Dummye>();
            Dummyes_h4Id = new List<Dummye>();
            Dummyes_h5Id = new List<Dummye>();
            Dummyes_h6Id = new List<Dummye>();
            Dummyes_h7Id = new List<Dummye>();
            Dummyes_h8Id = new List<Dummye>();
            Dummyes_h9Id = new List<Dummye>();
            NailDesignTypes = new List<NailDesignType>();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
