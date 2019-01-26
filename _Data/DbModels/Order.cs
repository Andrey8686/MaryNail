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
    public partial class Order
    {
        public int Id { get; set; }
        public string AspNetUsersId { get; set; }
        public string Comment { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public Order()
        {
            CreatedDate = System.DateTime.Now;
            OrderItems = new List<OrderItem>();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
