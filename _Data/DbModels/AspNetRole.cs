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
    public partial class AspNetRole
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }

        public AspNetRole()
        {
            AspNetUsers = new List<AspNetUser>();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}