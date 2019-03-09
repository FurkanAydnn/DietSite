using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMyProject.Areas.Panel.Controllers
{
    public class ArticleController : Controller
    {
        UnitOfWork _uw = new UnitOfWork();
        // GET: Panel/Article
        public ActionResult Index()
        {
            var list = _uw.Articles.GetAll();
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }


    }
}