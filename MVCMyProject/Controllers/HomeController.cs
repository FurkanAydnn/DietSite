using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMyProject.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork _uw = new UnitOfWork();

        public ActionResult Index()
        {
            ViewBag.Article1 = _uw.Articles
                .GetAll()
                .FirstOrDefault();

            ViewBag.Article2 = _uw.Articles
                .GetAll()
                .Skip(1)
                .FirstOrDefault();

            ViewBag.Article3 = _uw.Articles
                .GetAll()
                .Skip(2)
                .FirstOrDefault();

            ViewBag.DietLists = _uw.DietLists.GetAll();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}