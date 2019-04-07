using BLL;
using Entity;
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
            ViewBag.Settings = _uw.GeneralSettings.GetSettings();

            return View();
        }

        public ActionResult AboutMe()
        {
            return View(_uw.GeneralSettings.GetSettings());
        }

        public ActionResult Contact()
        {
            return View(_uw.GeneralSettings.GetSettings());
        }

        [HttpGet]
        public ActionResult DietForm()
        {
            ViewBag.ProductTypes = _uw.ProductTypes.GetAll();
            ViewBag.Products = _uw.Products.GetAll();
            ViewBag.HealthInfo = _uw.HealthInfos.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult DietForm(OnlineDietForm dietForm, HttpPostedFileBase word)
        {
            if (ModelState.IsValid)
            {
                List<ProductConsumption> consumptionList = new List<ProductConsumption>();

                foreach (Product item in _uw.Products.GetAll())
                {
                    ProductConsumption consumption = new ProductConsumption();
                    consumption.ProductId = item.Id;
                    consumption.IsConsumed = Convert.ToBoolean(Request.Form[item.Name.Replace(" ", "") + "_" + item.Id]);
                    consumptionList.Add(consumption);
                }

                List<HealthInfoResult> resultList = new List<HealthInfoResult>();

                foreach (HealthInfo item in _uw.HealthInfos.GetAll())
                {
                    HealthInfoResult result = new HealthInfoResult();
                    result.HealthInfoId = item.Id;
                    result.Result = Convert.ToDouble(Request.Form[item.Name]);
                    resultList.Add(result);
                }

                dietForm.ProductConsumptions = consumptionList;
                dietForm.HealthInfoResults = resultList;

                TempData["Notification"] = MailHelper.SendMail();

                return RedirectToAction("/Index");
            }


            ViewBag.ProductTypes = _uw.ProductTypes.GetAll();
            ViewBag.Products = _uw.Products.GetAll();
            ViewBag.HealthInfo = _uw.HealthInfos.GetAll();
            return View(dietForm);
        }

        public ActionResult Article()
        {
            return View(_uw.Articles.GetAll());
        }
    }
}