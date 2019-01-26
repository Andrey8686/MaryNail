using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin.Code;
using Admin.Code.Utils;
using Admin.Models;
using _Data.Models;

namespace Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class NailDesignTypeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var search = (string)Session["NailDesignTypeSearch"];

            var model = string.IsNullOrEmpty(search) ? db.NailDesignTypes : db.NailDesignTypes.Where(i => i.Name.Contains(search));

            var newModel = new List<NailDesignTypeModel>();

            foreach (var item in model)
            {
                newModel.Add(new NailDesignTypeModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    IsActive = item.IsActive,
                });
            }

            return PartialView(newModel);
        }

        public ActionResult Search()
        {
            return PartialView(new SearchModel { Text = string.IsNullOrEmpty((string)Session["NailDesignTypeSearch"]) ? string.Empty : (string)Session["NailDesignTypeSearch"] });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(SearchModel request)
        {
            Session["NailDesignTypeSearch"] = request.Text;

            return RedirectToAction("List");
        }

        public ActionResult Create()
        {
            var model = new NailDesignTypeModel();

            Binder.Bind(new NailDesignType(), ref model);
            

            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NailDesignTypeModel request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var model = new NailDesignType
                    {
                        Id = request.Id,
                        Name = request.Name,
                        IsActive = true
                    };
                    
                    db.NailDesignTypes.Add(model);
                    
                    db.SaveChanges();

                    return RedirectToAction("List");
                }
                catch (Exception exc)
                {
                    ModelState.AddModelError("", "Что то пошло не так.");
                }
            }

            return PartialView(request);
        }

        public ActionResult Edit(Guid id)
        {
            var item = db.NailDesignTypes.Find(id);
            if (item == null) return RedirectToAction("List");

            var model = new NailDesignTypeModel();

            Binder.Bind(item, ref model);
            

            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NailDesignTypeModel request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var model = db.NailDesignTypes.Find(request.Id);
                    
                    model.Name = request.Name;

                    db.SaveChanges();

                    return RedirectToAction("List");
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc);
                }
            }

            return PartialView(request);
        }

        public ActionResult Delete(Guid id)
        {
            try
            {
                var item = db.NailDesignTypes.Find(id);
                if (item != null)
                {
                    db.NailDesignTypes.Remove(item);
                    db.SaveChanges();
                }
            }
            catch (Exception exc)
            {
                _logger.Error(exc);
            }
            return RedirectToAction("List");
        }

        public ActionResult ChangeVisibility(Guid id)
        {
            try
            {
                var item = db.NailDesignTypes.Find(id);
                if (item != null)
                {
                    item.IsActive = !item.IsActive;
                    db.SaveChanges();
                }
            }
            catch (Exception exc)
            {
                _logger.Error(exc);
            }
            return RedirectToAction("List");
        }
    }
}