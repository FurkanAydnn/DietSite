using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMyProject.Areas.Panel.Controllers
{
    public class DietListController : Controller
    {
        UnitOfWork _uw = new UnitOfWork();
        // GET: Panel/DietList
        public ActionResult Index(int? del)
        {
            if (del.HasValue)
            {
                _uw.DietLists.Delete(del.Value);
                _uw.Complete();
            }
            return View(_uw.DietLists.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DietList dietList)
        {
            if (ModelState.IsValid)
            {
                _uw.DietLists.Add(dietList);
                _uw.Complete();
            }

            return View(dietList);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            DietList dietList = _uw.DietLists.GetOne(id);
            return View(dietList);
        }

        [HttpPost]
        public ActionResult Edit(DietList dietList)
        {
            if (ModelState.IsValid)
            {
                _uw.DietLists.Update(dietList);
                _uw.Complete();
                return RedirectToAction("Index");
            }
            return View(dietList);
        }
    }
}