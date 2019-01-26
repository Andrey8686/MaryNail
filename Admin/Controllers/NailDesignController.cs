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
    public class NailDesignController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var search = (string)Session["NailDesignSearch"];

            var model = string.IsNullOrEmpty(search) ? db.NailDesigns : db.NailDesigns.Where(i => i.Name.Contains(search));

            var newModel = new List<NailDesignModel>();

            foreach (var item in model)
            {
                newModel.Add(new NailDesignModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    TimeOut = TimeUtils.TimeFromUt(item.TimeOut),
                    Price = item.Price,
                    IsActive = item.IsActive,
                });
            }

            return PartialView(newModel);
        }

        public ActionResult Search()
        {
            return PartialView(new SearchModel { Text = string.IsNullOrEmpty((string)Session["NailDesignSearch"]) ? string.Empty : (string)Session["NailDesignSearch"] });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(SearchModel request)
        {
            Session["NailDesignSearch"] = request.Text;

            return RedirectToAction("List");
        }

        public ActionResult Create()
        {
            var model = new NailDesignModel();

            Binder.Bind(new NailDesign(), ref model);

            model.TimeOut = "00:00";

            InitFilds();

            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NailDesignRequestModel request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var model = new NailDesign
                    {
                        Id = request.Id,
                        Name = request.Name,
                        TimeOut = TimeUtils.TimeToUt(request.TimeOut),
                        Price = request.Price,
                        IsActive = true
                    };

                    if (request.NailDesignTypesGuids != null)
                    {
                        var ndt = db.NailDesignTypes.Where(i => request.NailDesignTypesGuids.Contains(i.Id)).ToList();

                        for (var i = ndt.Count - 1; i >= 0; i--)
                        {
                            model.NailDesignTypes.Add(ndt[i]);
                        }
                    }
                    
                    db.NailDesigns.Add(model);
                    
                    db.SaveChanges();

                    return RedirectToAction("List");
                }
                catch (Exception exc)
                {
                    ModelState.AddModelError("", "Что то пошло не так.");
                }
            }

            InitFilds();

            return PartialView(request);
        }

        public ActionResult Edit(Guid id)
        {
            var item = db.NailDesigns.Find(id);
            if (item == null) return RedirectToAction("List");

            var model = new NailDesignModel();

            Binder.Bind(item, ref model);

            model.TimeOut = TimeUtils.TimeFromUt(item.TimeOut);

            InitFilds();

            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NailDesignRequestModel request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var model = db.NailDesigns.Find(request.Id);
                    
                    model.Name = request.Name;
                    model.TimeOut = TimeUtils.TimeToUt(request.TimeOut);
                    model.Price = request.Price;

                    var ndt = db.NailDesignTypes.Where(i => request.NailDesignTypesGuids.Contains(i.Id)).ToList();
                    model.NailDesignTypes.Clear();
                    for (var i = ndt.Count - 1; i >= 0; i--)
                    {
                        model.NailDesignTypes.Add(ndt[i]);
                    }

                    db.SaveChanges();

                    return RedirectToAction("List");
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc);
                }
            }

            InitFilds();

            return PartialView(request);
        }

        public ActionResult Delete(Guid id)
        {
            try
            {
                var item = db.NailDesigns.Find(id);
                if (item != null)
                {
                    db.NailDesigns.Remove(item);
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
                var item = db.NailDesigns.Find(id);
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

        private void InitFilds()
        {
            ViewBag.NailDesignTypes = db.NailDesignTypes.Where(i => i.IsActive).ToList();
        }
    }
}