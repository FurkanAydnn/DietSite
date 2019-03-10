using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMyProject.Areas.Panel.Controllers
{
    public class HealthController : Controller
    {
        UnitOfWork _uw = new UnitOfWork();
        // GET: Panel/Health
        public ActionResult Index(int? del)
        {
            if (del.HasValue)
            {
                _uw.HealthInfos.Delete(del.Value);
                _uw.Complete();
            }

            return View(_uw.HealthInfos.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HealthInfo healthInfo)
        {
            if (ModelState.IsValid)
            {
                _uw.HealthInfos.Add(healthInfo);
                _uw.Complete();
                return RedirectToAction("Index");
            }

            return View(healthInfo);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(_uw.HealthInfos.GetOne(id));
        }

        [HttpPost]
        public ActionResult Edit(HealthInfo info)
        {
            if (ModelState.IsValid)
            {
                HealthInfo old = _uw.HealthInfos.GetOne(info.Id);
                _uw.db.Entry(old).CurrentValues.SetValues(info);
                _uw.Complete();
                return RedirectToAction("Index");
            }

            return View(info);
        }
    }
}