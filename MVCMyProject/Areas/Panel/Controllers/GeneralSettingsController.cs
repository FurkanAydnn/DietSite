using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMyProject.Areas.Panel.Controllers
{
    public class GeneralSettingsController : Controller
    {
        UnitOfWork _uw = new UnitOfWork();
        // GET: Panel/DietList
        public ActionResult Index(int? del)
        {
            if (del.HasValue)
            {
                _uw.GeneralSettings.Delete(del.Value);
                _uw.Complete();
            }
            return View(_uw.GeneralSettings.GetSettings());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GeneralSettings setting)
        {
            if (ModelState.IsValid)
            {
                _uw.GeneralSettings.Add(setting);
                _uw.Complete();
                return RedirectToAction("Index");
            }

            return View(setting);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            GeneralSettings settingList = _uw.GeneralSettings.GetOne(id);
            return View(settingList);
        }

        [HttpPost]
        public ActionResult Edit(GeneralSettings setting)
        {
            if (ModelState.IsValid)
            {
                _uw.GeneralSettings.Update(setting);
                _uw.Complete();
                return RedirectToAction("Index");
            }
            return View(setting);
        }
    }
}