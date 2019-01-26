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
    public partial class NailDesignType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int OrderBy { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<NailDesign> NailDesigns { get; set; }

        public NailDesignType()
        {
            Id = System.Guid.NewGuid();
            OrderBy = 0;
            IsActive = true;
            NailDesigns = new List<NailDesign>();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
