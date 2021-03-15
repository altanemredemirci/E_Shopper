using E_Shopper_BLL;
using E_Shopper_Entity;
using E_Shopper_WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace E_Shopper_WebUI.Controllers
{
    public class BrandController : Controller
    {
        BrandManager brandManager = new BrandManager();
        ProductManager productManager = new ProductManager();
        // GET: Brand
        public ActionResult Index()
        {
            return View(brandManager.List());
        }

        // GET: Brand/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = brandManager.Find(x => x.Id == id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            ViewBag.urunler = new SelectList(productManager.List().Where(x => x.BrandId == id), "Id", "Title");
            return View(brand);
        }

        // GET: Brand/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Brand/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Brand brand)
        {
            try
            {
                ModelState.Remove("CreatedOn");
                ModelState.Remove("ModifiedOn");
                ModelState.Remove("ModifiedUsername");

                if (ModelState.IsValid)
                {
                    brandManager.Insert(brand);
                    CacheHelper.RemoveBrandsFromCache();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(brand);
                }
            }
            catch
            {
                return View(brand);
            }
        }
    
        // GET: Brand/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = brandManager.Find(x => x.Id == id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // POST: Brand/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Brand brand)
        {
            try
            {
                ModelState.Remove("CreatedOn");
                ModelState.Remove("ModifiedOn");
                ModelState.Remove("ModifiedUsername");

                if (ModelState.IsValid)
                {
                    Brand brnd = brandManager.Find(x => x.Id == brand.Id);
                    brnd.Name = brand.Name;

                    brandManager.Update(brnd);
                    CacheHelper.RemoveBrandsFromCache();

                    return RedirectToAction("Index");
                }
                return View(brand);
            }
            catch
            {
                return View(brand);
            }
        }

        // GET: Brand/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Brand brand = brandManager.Find(x => x.Id == id);

            if (brand == null)
            {
                return HttpNotFound();
            }

            return View(brand);
        }

        // POST: Brand/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Brand brand = brandManager.Find(x => x.Id == id);
            brandManager.Delete(brand);

            CacheHelper.RemoveBrandsFromCache();


            return RedirectToAction("Index");
        }
    }
}
