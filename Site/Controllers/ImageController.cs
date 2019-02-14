using System.Configuration;
using System.Drawing;
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
            var fileUrl = GetUrlToFile(model);

            if (string.IsNullOrEmpty(fileUrl)) return Content("Изображение не найдено!");

            return File(fileUrl, MimeMapping.GetMimeMapping(fileUrl));
        }

        public ActionResult Mark(ImageModel model)
        {
            var fileUrl = GetUrlToFile(model);

            if (string.IsNullOrEmpty(fileUrl)) return Content("Изображение не найдено!");
            
            var newRec = new Rectangle();

            var bmp = new Bitmap(fileUrl);
            var mark = new Bitmap(model.Mark);
            
            if (bmp.Width > bmp.Height)
            {
                newRec.Height = bmp.Height / 100 * model.MarkPercent > 100 || model.MarkPercent < 1 ? 100 : model.MarkPercent;
                newRec.Width = newRec.Height / (mark.Width / mark.Height);
            }
            else
            {
                newRec.Width = bmp.Width / 100 * (model.MarkPercent > 100 || model.MarkPercent < 1 ? 100 : model.MarkPercent);
                newRec.Height = newRec.Width / (mark.Height / mark.Width);
            }

            newRec.X = bmp.Width - newRec.Width;
            newRec.Y = bmp.Height - newRec.Height;

            using (var g = Graphics.FromImage(bmp))
            {
                g.DrawImage(mark, newRec);
            }

            return File(BitmapToBytes(bmp), MimeMapping.GetMimeMapping(fileUrl));
        }

        private string GetUrlToFile(ImageModel model)
        {
            var prefix = string.IsNullOrEmpty(model.Prefix) ? string.Empty : model.Prefix + "_";
            var url = string.IsNullOrEmpty(model.AppDataDir) ? _appData : Path.Combine(_appData, model.AppDataDir);
            Directory.CreateDirectory(url);
            return Directory.GetFiles(url, prefix + model.Id + "*").FirstOrDefault();
        }

        private static byte[] BitmapToBytes(Bitmap img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                return stream.ToArray();
            }
        }


    }
}