using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _Data.Models;

namespace Site.Models
{
    public class BookingModels
    {
        public Guid ServiceId { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? DummyId { get; set; }
        
        public Service Service { get; set; }
        public Product Product { get; set; }
        public Dummye Dummy { get; set; }
    }



    

}