using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin.Code;
using Admin.Models;
using Newtonsoft.Json;

namespace Admin.Controllers
{
    [Authorize]
    public class FilesController : BaseController
    {
        private readonly string _appData = ConfigurationManager.AppSettings["AppData"];


        public FilesController()
        {
            _appData = string.IsNullOrEmpty(_appData) ? Server.MapPath("~/App_Data/") : _appData;
        }



        public ActionResult Index(FileModel model)
        {
            var prefix = string.IsNullOrEmpty(model.Prefix) ? string.Empty : model.Prefix + "_";

            var url = Path.Combine(_appData, model.AppDataDir);
            Directory.CreateDirectory(url);
            var fileUrl = Directory.GetFiles(url, prefix + model.Id + "*").FirstOrDefault();

            model.IsFileExists = !string.IsNullOrEmpty(fileUrl);

            ViewBag.json = JsonConvert.SerializeObject(model);


            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Upload(FileModel model)
        {
            var prefix = string.IsNullOrEmpty(model.Prefix) ? string.Empty : model.Prefix + "_";

            try
            {
                foreach (string f in Request.Files)
                {
                    var file = Request.Files[f];

                    if (file != null)
                    {
                        if (new[] { "image/jpeg", "image/png", "image/gif", "image/bmp" }.Contains(file.ContentType))
                        {
                            using (var image = Image.FromStream(file.InputStream))
                            {

                                if (model.ImageFixWidth + model.ImageFixHeight > 0)
                                {
                                    if (!(model.ImageFixWidth == image.Width && model.ImageFixHeight == image.Height))
                                    {
                                        ViewBag.Error = $"Размер изображения должен быть {model.ImageFixWidth}x{model.ImageFixHeight} не больше не меньше!";
                                        goto Return;
                                    }
                                }
                                else if (model.ImageMaxWidth + model.ImageMaxHeight > 0)
                                {
                                    if (model.ImageMaxWidth > image.Width && model.ImageMaxHeight > image.Height)
                                    {
                                        ViewBag.Error = "Изображение слишком маленькое.";
                                        goto Return;
                                    }
                                }
                                
                                try
                                {
                                    var url = Path.Combine(_appData, model.AppDataDir);
                                    Directory.CreateDirectory(url);
                                    var ext = file.FileName.Split('.').Last();
                                    DeleteFile(model);
                                    
                                    if (model.ImageMaxWidth + model.ImageMaxHeight > 0)
                                    {
                                        using (var bmp = ResizeImage((Bitmap)image, model.ImageMaxWidth, model.ImageMaxHeight))
                                        {
                                            bmp.Save(Path.Combine(url, prefix + model.Id + "." + ext), image.RawFormat);
                                        }
                                        goto Return;
                                    }
                                    
                                    image.Save(Path.Combine(url, prefix + model.Id + "." + ext), image.RawFormat);
                                }
                                catch (Exception exc)
                                {
                                    ViewBag.Error = exc.Message;
                                    goto Return;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                ViewBag.Error = "Некорректный формат изображения.";
                goto Return;
            }

            Return:

            ViewBag.json = JsonConvert.SerializeObject(model);

            return View("Index", model);
        }



        


        [HttpGet]
        public ActionResult GetImage(FileModel model)
        {
            var prefix = string.IsNullOrEmpty(model.Prefix) ? string.Empty : model.Prefix + "_";

            var url = string.IsNullOrEmpty(model.AppDataDir) ? _appData : Path.Combine(_appData, model.AppDataDir);
            Directory.CreateDirectory(url);
            var fileUrl = Directory.GetFiles(url, prefix + model.Id + "*").FirstOrDefault();
            if (string.IsNullOrEmpty(fileUrl))
            {
                fileUrl = Path.Combine(Server.MapPath("~/Content/Images/"), "No_image_available.jpg");
            }
            
            return File(fileUrl, MimeMapping.GetMimeMapping(fileUrl));
        }
        
        public void DeleteFile(FileModel model)
        {
            var prefix = string.IsNullOrEmpty(model.Prefix) ? string.Empty : model.Prefix + "_";

            var url = string.IsNullOrEmpty(model.AppDataDir) ? _appData : Path.Combine(_appData, model.AppDataDir);
            var files = Directory.GetFiles(url, prefix + model.Id + "*");
            if (files.Any())
            {
                foreach (var file in files)
                {
                    System.IO.File.Delete(file);
                }
            }
        }










        private static Bitmap ResizeImage(Bitmap src, int newWidth, int newHeight)
        {
            if (src.Width > newWidth || src.Height > newHeight)
            {
                int width = newWidth, height = newHeight;

                if (src.Width > newWidth && src.Height <= newHeight)
                {
                    height = newWidth * src.Height / src.Width;
                }
                else if (src.Width <= newWidth && src.Height > newHeight)
                {
                    width = newHeight * src.Width / src.Height;
                }
                else
                {
                    if (src.Width - newWidth > src.Height - newHeight)
                    {
                        height = newWidth * src.Height / src.Width;

                    }
                    else
                    {
                        width = newHeight * src.Width / src.Height;
                    }
                }
                try
                {
                    var bitmap = new Bitmap(width, height);
                    using (var graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.DrawImage(src, new Rectangle(0, 0, width, height));
                    }
                    return bitmap;

                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc);
                }
            }

            return src;
        }







        public ActionResult FileListForItem(FileModel model)
        {
            try
            {
                var url = Path.Combine(_appData, model.AppDataDir, model.Id.ToString());
                Directory.CreateDirectory(url);
                model.FileUrl = Directory.GetFiles(url, "*");

                ViewBag.json = JsonConvert.SerializeObject(model);
            }
            catch (Exception exc)
            {
                _logger.Error(exc);
            }
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult UploadFileForItem(FileModel model)
        {
            try
            {
                var url = Path.Combine(_appData, model.AppDataDir, model.Id.ToString());

                foreach (string f in Request.Files)
                {
                    var file = Request.Files[f];

                    var fileName = Path.GetFileName(file?.FileName);

                    if (fileName != null)
                    {
                        file.SaveAs(Path.Combine(url, fileName));
                    }
                }
            }
            catch (Exception exc)
            {
                _logger.Error(exc);
            }
            return RedirectToAction("FileListForItem", model);
        }

        [HttpPost]
        public ActionResult DeleteFileForItem(FileModel model)
        {
            try
            {
                var filePath = Path.Combine(_appData, model.AppDataDir, model.Id.ToString(), model.FileName);

                if (System.IO.File.Exists(filePath)) System.IO.File.Delete(filePath);
            }
            catch (Exception exc)
            {
                _logger.Error(exc);
            }

            return RedirectToAction("FileListForItem", model);
        }

        [HttpGet]
        public ActionResult GetFile(FileModel model)
        {
            try
            {
                var url = string.IsNullOrEmpty(model.AppDataDir) ? _appData : Path.Combine(_appData, model.AppDataDir);

                Directory.CreateDirectory(url);
                
                var fileUrl = Directory.GetFiles(Path.Combine(url, model.Id.ToString()), model.FileName);

                if (fileUrl.Length > 0)
                {
                    switch (model.Param)
                    {
                        case "view":
                                return File(fileUrl[0], MimeMapping.GetMimeMapping(fileUrl[0]));
                            break;
                        default:
                                goto theend;
                            break;
                    }
                }
            }
            catch (Exception exc)
            {
                _logger.Error(exc);
            }

            theend:

            return Content("Файл не найден!");
        }

    }
}