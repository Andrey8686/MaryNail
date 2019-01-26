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
    public class NewsController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult List()
        {
            var search = (string)Session["NewSearch"];

            var model = string.IsNullOrEmpty(search) ? db.News : db.News.Where(i => i.Name.Contains(search) && i.IsActive);
            
            var newModel = new List<NewModel>();

            foreach (var item in model)
            {
                newModel.Add(new NewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    FullText = item.FullText,
                    CreatedDate = item.CreatedDate,
                    IsActive = item.IsActive
                });
            }

            return PartialView(newModel);
        }
        
        public ActionResult Search()
        {
            return PartialView(new SearchModel { Text = string.IsNullOrEmpty((string)Session["NewSearch"]) ? string.Empty : (string)Session["NewSearch"] } );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(SearchModel request)
        {
            Session["NewSearch"] = request.Text;

            return RedirectToAction("List");
        }
        
        public ActionResult Create()
        {
            var model = new NewModel();

            Binder.Bind(new News(), ref model);
            
            
            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewModel request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.News.Add(new News
                    {
                        Id = request.Id,
                        Name = request.Name,
                        Description = request.Description,
                        FullText = request.FullText
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
            var item = db.News.Find(id);
            if (item == null) return RedirectToAction("List");

            var model = new NewModel();

            Binder.Bind(item, ref model);
            
            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NewModel request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var model = db.News.Find(request.Id);

                    model.Name = request.Name;
                    model.Description = request.Description;
                    model.FullText = request.FullText;

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
                var item = db.News.Find(id);
                if (item != null)
                {
                    db.News.Remove(item);
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
                var item = db.News.Find(id);
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