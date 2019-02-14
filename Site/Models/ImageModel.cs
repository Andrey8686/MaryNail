using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.Models
{
    public class ImageModel
    {
        public Guid Id { get; set; }
        public string AppDataDir { get; set; }
        public string Prefix { get; set; }
        public string Mark { get; set; }
        public int MarkPercent { get; set; }
    }
}