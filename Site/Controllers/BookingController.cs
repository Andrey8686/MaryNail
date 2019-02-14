using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Site.Code;
using Site.Models;

namespace Site.Controllers
{
    public class BookingController : BaseController
    {
        public ActionResult Index()
        {
            var booking = new List<BookingModels>();

            if (Session["Booking"] != null)
            {
                booking = (List<BookingModels>)Session["Booking"];
                foreach (var b in booking)
                {
                    b.Service = db.Services.Find(b.ServiceId);
                    if (b.ProductId != null)
                    {
                        b.Product = db.Products.Find(b.ProductId);
                    }
                    else if (b.DummyId != null)
                    {
                        b.Dummy = db.Dummyes.Find(b.DummyId);
                    }
                    
                }
            }
            
            return View(booking);
        }

        public ActionResult Service(Guid id)
        {
            return View("AddService", id);
        }

        public ActionResult AddService(Guid id)
        {
            if (db.Services.Any(i => i.Id == id && i.IsActive))
            {
                var booking = (List<BookingModels>)Session["Booking"] ?? new List<BookingModels>();

                if (booking.Any(i => i.ServiceId != id))
                {
                    booking.Add(new BookingModels
                    {
                        ServiceId = id
                    });
                }
            }

            return View();
        }

        public ActionResult Product(Guid id)
        {
            return View("AddProduct", id);
        }

        [HttpPost]
        public ActionResult AddProduct(Guid id)
        {
            try
            {
                var product = db.Products.FirstOrDefault(i => i.Id == id && i.IsActive);

                if (product != null)
                {
                    var booking = (List<BookingModels>)Session["Booking"] ?? new List<BookingModels>();

                    if (booking.Any(i => i.ServiceId == product.ServiceId))
                    {
                        foreach (var t in booking)
                        {
                            if (t.ServiceId != product.ServiceId) continue;

                            t.ServiceId = product.ServiceId;
                            t.ProductId = product.Id;
                            t.DummyId = null;
                        }
                    }
                    else
                    {
                        booking.Add(new BookingModels
                        {
                            ServiceId = product.ServiceId,
                            ProductId = product.Id,
                            DummyId = null
                        });
                    }

                    Session["Booking"] = booking;
                }
            }
            catch (Exception e)
            {
                return Content("что то пошло не так!");
            }
            

            return View(id);
        }

        public ActionResult Dummy(Guid id)
        {
            return View("AddDummy", id);
        }

        [HttpPost]
        public ActionResult AddDummy(Guid id)
        {
            var dummy = db.Dummyes.FirstOrDefault(i => i.Id == id);

            if (dummy != null)
            {
                var booking = (List<BookingModels>)Session["Booking"] ?? new List<BookingModels>();

                if (booking.Any(i => i.ServiceId == dummy.ServiceId))
                {
                    for (var i = 0; i < booking.Count; i++)
                    {
                        if (booking[i].ServiceId == dummy.ServiceId)
                        {
                            booking.Add(new BookingModels
                            {
                                ServiceId = dummy.ServiceId,
                                ProductId = null,
                                DummyId = dummy.Id
                            });
                        }
                    }
                }
                else
                {
                    booking.Add(new BookingModels
                    {
                        ServiceId = dummy.ServiceId,
                        ProductId = null,
                        DummyId = dummy.Id
                    });
                }

                Session["Booking"] = booking;
            }

            return View();
        }
        
        public ActionResult RemoveFromBooking(Guid id)
        {
            var booking = (List<BookingModels>)Session["Booking"];

            if (booking == null)
                return Content("Запись и так пуста!");

            var item = booking.FirstOrDefault(i => i.ProductId == id);

            if (item != null)
            {
                booking.Remove(item);
                Session["Booking"] = booking;

                return View("AddProduct", id);
            }

            item = booking.FirstOrDefault(i => i.DummyId == id);

            if (item != null)
            {
                booking.Remove(item);
                Session["Booking"] = booking;

                return View("AddProduct", id);
            }
            
            item = booking.FirstOrDefault(i => i.ServiceId == id);

            booking.Remove(item);
            Session["Booking"] = booking;

            return View("AddService", id);
        }







        public ActionResult ChoiceTime()
        {
            

            return View();
        }

    }
}