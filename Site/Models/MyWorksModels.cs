using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Site.Code;

namespace Site.Models
{
    public class MyWorksModel
    {
        public Guid Id { get; set; }
        public Guid ProductTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TimeCost { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public Guid? DummyId { get; set; }
    }
    
}