using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMyProject.Areas.Panel.Controllers
{
    public class ArticleController : Controller
    {
        UnitOfWork _uw = new UnitOfWork();
        // GET: Panel/Article
        public ActionResult Index(int? del)
        {
            if (del.HasValue)
            {
                _uw.Articles.Delete(del.Value);
                _uw.Complete();
            }
            var list = _uw.Articles.GetAll();
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create(Article article, List<HttpPostedFileBase> images)
        {
            if (ModelState.IsValid)
            {
                //if (images.Count != 0)
                //{
                //    string path = Server.MapPath("/Uploads/ArticleImages/");
                //    Directory.CreateDirectory(path + article.Id);

                //    foreach (var item in images)
                //    {
                //        item.SaveAs(path + item.FileName);
                //    }
                //}
            }
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }


    }
}