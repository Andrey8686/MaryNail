using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Site.Code;
using Site.Models;
using _Data.Models;

namespace Site.Controllers
{
    public class DummyController : BaseController
    {
        



        public ActionResult Index()
        {
            var model = GetDummy();

            var typeList = db.NailDesignTypes.ToList();
            ViewBag.DesignTypes = typeList;
            ViewBag.Design = typeList[0].NailDesigns.ToList();
            
            return View(model);
        }

        [HttpPost]
        public ActionResult DesignList(Guid id)
        {
            ViewBag.Design = db.NailDesignTypes.Find(id).NailDesigns.ToList();
            
            return View();
        }
        
        [HttpPost]
        public ActionResult AddNail(DummyRequestModel request)
        {
            var model = GetDummy();

            if (request.Index == null)
            {
                for (var i = 0; i < model.NailDesigns.Length; i++)
                {
                    if (model.NailDesigns[i] == null)
                    {
                        model.NailDesigns[i] = db.NailDesigns.Find(request.Id);
                        break;
                    }
                }
            }
            else
            { 
                model.NailDesigns[request.Index ?? 0] = db.NailDesigns.Find(request.Id);
            }
            
            SetDummy(model);
            return PartialView("Nails", model);
        }

        [HttpPost]
        public ActionResult RemoveNail(DummyRequestModel request)
        {
            var model = GetDummy();
            model.NailDesigns[request.Index ?? 0] = null;
            SetDummy(model);

            return PartialView("Nails", model);
        }

        [HttpPost]
        public ActionResult ChangeNail(DummyRequestModel request)
        {
            var model = GetDummy();

            var cItem = model.NailDesigns[request.SwapIndex];
            model.NailDesigns[request.SwapIndex] = model.NailDesigns[request.Index ?? 0];
            model.NailDesigns[request.Index ?? 0] = cItem;

            SetDummy(model);

            return PartialView("Nails", model);
        }

        [HttpPost]
        public ActionResult Reset()
        {
            var model = new DummyModel();

            SetDummy(model);

            return PartialView("Nails", model);
        }



        private DummyModel GetDummy()
        {
            var model = new DummyModel();
            if (Session["Dummy"] != null)
            {
                model = (DummyModel)Session["Dummy"];
            }
            return model;
        }

        private void SetDummy(DummyModel model)
        {
            Session["Dummy"] = model;
        }

        //private DummyModel GetDummy()
        //{
        //    var model = new DummyModel();
        //    if (!string.IsNullOrEmpty(HttpContext.Response.Cookies["Dummy"]?.Value))
        //    {
        //        model = JsonConvert.DeserializeObject<DummyModel>(HttpContext.Response.Cookies["Dummy"].Value);
        //    }
        //    return model;
        //}

        //private void SetDummy(DummyModel model)
        //{
        //    if (HttpContext.Response.Cookies["Dummy"] != null)
        //    {
        //        HttpContext.Response.Cookies["Dummy"].Value = JsonConvert.SerializeObject(model, Formatting.None, new JsonSerializerSettings
        //        {
        //            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        //        });
        //    }
        //}
    }
}