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
    public class ProductTypeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult List()
        {
            var search = (string)Session["Search"];


            if (string.IsNullOrEmpty(search))
            {
                return PartialView(BuildProductTypeList());
            }
            else
            {
                var model = db.ProductTypes.Where(i => i.Name.Contains(search)).Select(i => new ProductTypeModel
                {
                    Id = i.Id,
                    ProductTypeId = i.ProductTypeId,
                    Name = i.Name,
                    IsActive = i.IsActive,
                    OrderBy = i.OrderBy

                }).ToList();

                return PartialView(model);
            }
        }
        
        public ActionResult Search()
        {
            return PartialView(new SearchModel { Text = string.IsNullOrEmpty((string)Session["Search"]) ? string.Empty : (string)Session["Search"] } );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(SearchModel request)
        {
            Session["Search"] = request.Text;

            return RedirectToAction("List");
        }


        
        public ActionResult Create()
        {
            var model = new ProductTypeModel();

            Binder.Bind(new ProductType(), ref model);

            InitFilds();

            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductTypeModel request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var model = new ProductType();

                    
                    Binder.Bind(request, ref model);

                    model.IsActive = true;

                    db.ProductTypes.Add(model);
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
            var item = db.ProductTypes.Find(id);
            if (item == null) return RedirectToAction("List");

            var model = new ProductTypeModel();

            Binder.Bind(item, ref model);

            InitFilds();

            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductTypeModel request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var model = db.ProductTypes.Find(request.Id);

                    Binder.Bind(request, ref model);

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
                var item = db.ProductTypes.Find(id);
                if (item != null)
                {
                    db.ProductTypes.Remove(item);
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
                var item = db.ProductTypes.Find(id);
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

            foreach (var item in BuildProductTypeList())
            {
                productTypeList.Add(new KeyValuePair<string, string>(item.Id.ToString(), item.Name));
            }
            
            ViewBag.ProductTypes = productTypeList;
        }


        private List<ProductType> _productType;

        public List<ProductTypeModel> BuildProductTypeList(Guid? id = null, int level = 0)
        {
            if (_productType == null)
            {
                _productType = db.ProductTypes.ToList();
            }

            var list = new List<ProductTypeModel>();
            if (_productType.Any())
            {
                foreach (var item in _productType.Where(i => i.ProductTypeId == id))
                {
                    var name = string.Concat(Enumerable.Repeat("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;", level)) + item.Name;

                    list.Add(new ProductTypeModel
                    {
                        Id = item.Id,
                        ProductTypeId = item.ProductTypeId,
                        Name = name,
                        IsActive = item.IsActive,
                        OrderBy = item.OrderBy
                    });

                    var child = BuildProductTypeList(item.Id, level + 1);
                    if (child.Any()) list.AddRange(child);
                }
            }
            
            return list;
        }
    }
}