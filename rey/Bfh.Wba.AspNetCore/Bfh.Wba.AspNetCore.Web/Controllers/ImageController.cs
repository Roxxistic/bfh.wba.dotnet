using System;
using System.IO;
using Bfh.Wba.AspNetCore.Services.Images;
using Microsoft.AspNetCore.Mvc;

namespace Bfh.Wba.AspNetCore.Web.Controllers
{
    public class ImageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Show(int? id)
        {
            var path = AppDomain.CurrentDomain.GetData("App_Data").ToString();
            var files = Directory.GetFiles(path, "*.jpg");

            return PhysicalFile(files[(id ?? 0) % files.Length], "image/jpeg");
        }

        public IActionResult Thumbnail(int? id, int size = 400)
        {
            var path = AppDomain.CurrentDomain.GetData("App_Data").ToString();
            var files = Directory.GetFiles(path, "*.jpg");

            var tn = new Thumbnail();
            tn.Path = files[(id ?? 0) % files.Length];
            tn.Size = size;

            return File(tn.ToBytes(), "image/png");
        }
    }
}