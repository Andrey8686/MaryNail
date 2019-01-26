using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _Data.Models;

namespace Site.Models
{
    public class DummyModel
    {
        public NailDesign[] NailDesigns { get; set; }

        public DummyModel()
        {
            NailDesigns = new NailDesign[10];
        }
    }


    public class DummyRequestModel
    {
        public Guid Id { get; set; }
        public int? Index { get; set; }
        public int SwapIndex { get; set; }
    }
}