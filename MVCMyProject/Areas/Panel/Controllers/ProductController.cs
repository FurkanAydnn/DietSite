using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMyProject.Areas.Panel.Controllers
{
    public class ProductController : Controller
    {
        UnitOfWork _uw = new UnitOfWork();

        public ActionResult Index(int? type, int? prod)
        {
            if (type.HasValue)
            {
                _uw.ProductTypes.Delete(type.Value);
                _uw.Complete();
                ViewBag.ProductTypes = _uw.ProductTypes.GetAll();
                return View(_uw.Products.GetAll());
            }

            if (prod.HasValue)
            {
                _uw.Products.Delete(prod.Value);
                _uw.Complete();
                ViewBag.ProductTypes = _uw.ProductTypes.GetAll();
                return View(_uw.Products.GetAll());
            }


            ViewBag.ProductTypes = _uw.ProductTypes.GetAll();
            return View(_uw.Products.GetAll());
        }

        [HttpGet]
        public ActionResult CreateType()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateType(ProductType productType)
        {
            if (ModelState.IsValid)
            {
                _uw.ProductTypes.Add(productType);
                _uw.Complete();
                return RedirectToAction("Index");
            }

            return View(productType);
        }

        [HttpGet]
        public ActionResult CreateProduct(int? type)
        {
            if (type.HasValue)
                ViewBag.SelectedType = type.Value;
            ViewBag.Types = _uw.ProductTypes.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _uw.Products.Add(product);
                _uw.Complete();
                return RedirectToAction("Index");
            }

            ViewBag.Types = _uw.ProductTypes.GetAll();
            return View(product);
        }

        [HttpGet]
        public ActionResult EditType(int id)
        {
            return View(_uw.ProductTypes.GetOne(id));
        }

        [HttpPost]
        public ActionResult EditType(ProductType productType)
        {
            if (ModelState.IsValid)
            {
                _uw.ProductTypes.Update(productType);
                _uw.Complete();
                return RedirectToAction("Index");
            }

            return View(productType);
        }

        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            ViewBag.Types = _uw.ProductTypes.GetAll();
            return View(_uw.Products.GetOne(id));
        }

        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _uw.Products.Update(product);
                _uw.Complete();
                return RedirectToAction("Index");
            }

            ViewBag.Types = _uw.ProductTypes.GetAll();
            return View(product);
        }
    }
}