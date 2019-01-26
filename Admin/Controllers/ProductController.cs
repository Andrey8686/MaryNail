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
    public class ProductController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var search = (string)Session["ProductSearch"];

            var model = string.IsNullOrEmpty(search) ? db.Products : db.Products.Where(i => i.Name.Contains(search));

            var newModel = new List<ProductModel>();

            foreach (var item in model)
            {
                newModel.Add(new ProductModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    TimeCost = TimeUtils.TimeFromUt(item.TimeCost),
                    IsActive = item.IsActive,
                });
            }

            return PartialView(newModel);
        }

        public ActionResult Search()
        {
            return PartialView(new SearchModel { Text = string.IsNullOrEmpty((string)Session["ProductSearch"]) ? string.Empty : (string)Session["ProductSearch"] });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(SearchModel request)
        {
            Session["ProductSearch"] = request.Text;

            return RedirectToAction("List");
        }

        public ActionResult Create()
        {
            var model = new ProductModel();

            Binder.Bind(new Product(), ref model);

            model.TimeCost = "00:00";

            InitFilds();

            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductRequestModel request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var model = new Product
                    {
                        Id = request.Id,
                        ProductTypeId = request.ProductTypeId,
                        Name = request.Name,
                        Description = request.Description,
                        TimeCost = TimeUtils.TimeToUt(request.TimeCost),
                        IsActive = true
                    };

                    var services = db.Services.Where(i => request.ServicesGuids.Contains(i.Id)).ToList();
                    
                    for (var i = services.Count - 1; i >= 0; i--)
                    {
                        model.Services.Add(services[i]);
                    }

                    db.Products.Add(model);
                    
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
            
            var item = db.Products.Find(id);
            if (item == null) return RedirectToAction("List");


            Session["Dummy"] = new DummyModel
            {
                NailDesigns = new[]
                {
                    item.Dummye?.NailDesign_h1Id,
                    item.Dummye?.NailDesign_h2Id,
                    item.Dummye?.NailDesign_h3Id,
                    item.Dummye?.NailDesign_h4Id,
                    item.Dummye?.NailDesign_h5Id,
                    item.Dummye?.NailDesign_h6Id,
                    item.Dummye?.NailDesign_h7Id,
                    item.Dummye?.NailDesign_h8Id,
                    item.Dummye?.NailDesign_h9Id,
                    item.Dummye?.NailDesign_h10Id
                }
            };


            var model = new ProductModel();

            Binder.Bind(item, ref model);

            model.TimeCost = TimeUtils.TimeFromUt(item.TimeCost);

            InitFilds();

            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductRequestModel request)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    
                    var dummy = (DummyModel)Session["Dummy"];





                    var model = db.Products.Find(request.Id);


                    if (model.Dummye == null)
                    {
                        var newDummy = new Dummye();
                        db.Dummyes.Add(newDummy);
                        model.Dummye = newDummy;
                        model.DummyId = newDummy.Id;
                    }
                    

                    model.Dummye.h1Id = dummy.NailDesigns[0]?.Id;
                    model.Dummye.h2Id = dummy.NailDesigns[1]?.Id;
                    model.Dummye.h3Id = dummy.NailDesigns[2]?.Id;
                    model.Dummye.h4Id = dummy.NailDesigns[3]?.Id;
                    model.Dummye.h5Id = dummy.NailDesigns[4]?.Id;
                    model.Dummye.h6Id = dummy.NailDesigns[5]?.Id;
                    model.Dummye.h7Id = dummy.NailDesigns[6]?.Id;
                    model.Dummye.h8Id = dummy.NailDesigns[7]?.Id;
                    model.Dummye.h9Id = dummy.NailDesigns[8]?.Id;
                    model.Dummye.h10Id = dummy.NailDesigns[9]?.Id;

                    
                    model.ProductTypeId = request.ProductTypeId;
                    model.Name = request.Name;
                    model.Description = request.Description;
                    model.TimeCost = TimeUtils.TimeToUt(request.TimeCost);

                    var services = db.Services.Where(i => request.ServicesGuids.Contains(i.Id)).ToList();
                    model.Services.Clear();
                    for (var i = services.Count - 1; i >= 0; i--)
                    {
                        model.Services.Add(services[i]);
                    }

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
                var item = db.Products.Find(id);
                if (item != null)
                {
                    db.Products.Remove(item);
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
                var item = db.Products.Find(id);
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
            var productTypeList = new List<KeyValuePair<string, string>>();
            
            using (var pt = new ProductTypeController())
            {
                foreach (var item in pt.BuildProductTypeList())
                {
                    productTypeList.Add(new KeyValuePair<string, string>(item.Id.ToString(), item.Name));
                }
            }

            ViewBag.ProductTypes = productTypeList;
            ViewBag.Services = db.Services.Where(i => i.IsActive).ToList();
        }
    }
}