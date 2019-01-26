using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.Code;
using Site.Models;

namespace Site.Controllers
{
    public class ImageController : BaseController
    {
        private readonly string _appData = ConfigurationManager.AppSettings["AppData"];
        
        public ImageController()
        {
            _appData = string.IsNullOrEmpty(_appData) ? Server.MapPath("~/App_Data/") : _appData;
        }

        [HttpGet]
        public ActionResult Index(ImageModel model)
        {
            var prefix = string.IsNullOrEmpty(model.Prefix) ? string.Empty : model.Prefix + "_";

            var url = string.IsNullOrEmpty(model.AppDataDir) ? _appData : Path.Combine(_appData, model.AppDataDir);
            Directory.CreateDirectory(url);
            var fileUrl = Directory.GetFiles(url, prefix + model.Id + "*").FirstOrDefault();
            if (string.IsNullOrEmpty(fileUrl))
            {
                fileUrl = Path.Combine(Server.MapPath("~/Content/Images/"), "nail-empty.png");
            }
            return File(fileUrl, MimeMapping.GetMimeMapping(fileUrl));
        }
    }
}