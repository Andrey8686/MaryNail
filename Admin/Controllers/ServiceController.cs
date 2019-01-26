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
    public class ServiceController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult List()
        {
            var search = (string)Session["ServiceSearch"];

            var model = string.IsNullOrEmpty(search) ? db.Services : db.Services.Where(i => i.Name.Contains(search));
            
            var newModel = new List<ServiceModel>();

            foreach (var item in model)
            {
                newModel.Add(new ServiceModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    TimeCost = TimeUtils.TimeFromUt(item.TimeCost),
                    IsActive = item.IsActive,
                    OrderBy = item.OrderBy
                });
            }

            return PartialView(newModel);
        }
        
        public ActionResult Search()
        {
            return PartialView(new SearchModel { Text = string.IsNullOrEmpty((string)Session["ServiceSearch"]) ? string.Empty : (string)Session["ServiceSearch"] } );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(SearchModel request)
        {
            Session["ServiceSearch"] = request.Text;

            return RedirectToAction("List");
        }
        
        public ActionResult Create()
        {
            var model = new ServiceModel();

            Binder.Bind(new Service(), ref model);

            model.TimeCost = "00:00";
            
            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiceModel request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Services.Add(new Service
                    {
                        Id = request.Id,
                        Name = request.Name,
                        TimeCost = TimeUtils.TimeToUt(request.TimeCost),
                        IsActive = true,
                        OrderBy = 0
                    });

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
            var item = db.Services.Find(id);
            if (item == null) return RedirectToAction("List");

            var model = new ServiceModel();

            Binder.Bind(item, ref model);

            model.TimeCost = TimeUtils.TimeFromUt(item.TimeCost);
            
            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ServiceModel request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var model = db.Services.Find(request.Id);

                    model.Name = request.Name;
                    model.TimeCost = TimeUtils.TimeToUt(request.TimeCost);
                    
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
                var item = db.Services.Find(id);
                if (item != null)
                {
                    db.Services.Remove(item);
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
                var item = db.Services.Find(id);
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