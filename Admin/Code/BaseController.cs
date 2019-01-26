using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;

namespace Admin.Code
{
    public class BaseController : Controller
    {
        protected readonly DataContext db = new DataContext();

        protected static Logger _logger = LogManager.GetCurrentClassLogger();


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}