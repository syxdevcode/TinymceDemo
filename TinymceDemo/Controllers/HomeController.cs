using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TinymceDemo.Models;

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

        /// <summary>
        /// 接收tinymce插件的内容
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Test(TinyMCEModels model)
        {
            var path = Server.MapPath("~/File/123.txt");
            var str = System.IO.File.ReadAllText(path);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            System.IO.File.WriteAllText(path, model.content);

            return RedirectToAction("Show");
        }

        /// <summary>
        /// 将记事本的内容读出来，重新加载到页面上
        /// </summary>
        /// <returns></returns>
        public ActionResult Show()
        {
            var str = System.IO.File.ReadAllText(Server.MapPath("~/File/123.txt"));
            ViewBag.str = str.Trim();
            return View();
        }
    }
}