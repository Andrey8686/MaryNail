using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.Code;
using _Data.Models;

namespace Site.Controllers
{
    public class MyWorksController : BaseController
    {
        public ActionResult Index(string id)
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

            return View(model);
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