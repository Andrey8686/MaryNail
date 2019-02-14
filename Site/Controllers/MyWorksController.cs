using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.Code;
using Site.Models;
using _Data.Models;

namespace Site.Controllers
{
    public class MyWorksController : BaseController
    {
        public ActionResult List(string id)
        {
            List<Product> model;

            if (Guid.TryParse(id, out var idGuid))
            {
                var typeList = GetChildTypes(idGuid);
                typeList.Add(idGuid);
                
                model = db.Products.Where(i => typeList.Contains(i.ProductTypeId)).ToList();
            }
            else
            {
                model = db.Products.ToList();
            }

            ViewBag.ProductTypes = db.ProductTypes.Where(i => i.IsActive).ToList();

            return View(model);
        }

        public ActionResult Details(Guid id)
        {
            var model = db.Products.Find(id);

            return View(model);
        }



        public ActionResult Image(Guid id)
        {
            var m = new ImageController();
            return m.Mark(new ImageModel { Id = id, AppDataDir = "Product", Mark = Server.MapPath("~/Content/Images/mark.png"), MarkPercent = 50});
        }









        private List<Guid> GetChildTypes(Guid id)
        {
            var list = db.ProductTypes.Where(i => i.ProductTypeId == id).Select(i => i.Id).ToList();
            if (list.Any())
            {
                var cl = new List<Guid>();
                foreach (var i in list)
                {
                    cl.AddRange(GetChildTypes(i));
                }
                list.AddRange(cl);
            }
            return list;
        }

    }
}