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

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Article article, List<HttpPostedFileBase> images)
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }


    }
}