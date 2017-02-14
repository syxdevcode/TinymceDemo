using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TinymceDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ContentResult Upload(HttpPostedFileBase Filedata)
        {
            string result = string.Empty;
            string folder = Server.MapPath("~/File/");
            string time = DateTime.Now.ToString("yyyyMMddHHmmssff");//获取时间
            string extension = System.IO.Path.GetExtension(Filedata.FileName);//获取扩展名
            string newFileName = time + extension;//重组成新的文件名
            if (!System.IO.Directory.Exists(folder))
                System.IO.Directory.CreateDirectory(folder);

            Filedata.SaveAs(folder + "\\" + newFileName);

            return Content(newFileName);
        }
    }
}