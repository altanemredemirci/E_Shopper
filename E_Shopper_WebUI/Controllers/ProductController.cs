using E_Shopper_BLL;
using E_Shopper_Entity;
using E_Shopper_WebUI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace E_Shopper_WebUI.Controllers
{
    public class ProductController : Controller
    {
        private ProductManager productManager = new ProductManager();
        private CategoryManager categoryManager = new CategoryManager();
        private BrandManager brandManager = new BrandManager();

        // GET: Product
        public ActionResult Index()
        {            
            return View(productManager.List());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productManager.Find(x => x.Id == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(categoryManager.List(), "Id", "Title");
            ViewBag.BrandId = new SelectList(brandManager.List(), "Id", "Name");
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, HttpPostedFileBase file)
        {
            try
            {
                ModelState.Remove("CreatedOn");
                ModelState.Remove("ModifiedOn");
                ModelState.Remove("ModifiedUsername");

                if (ModelState.IsValid)
                {
                    var yuklemeYeri = Path.Combine(Server.MapPath("~/images/product"), file.FileName);
                    file.SaveAs(yuklemeYeri);
                    product.Image = file.FileName;
                    productManager.Insert(product);
                    CacheHelper.RemoveCategoriesFromCache();

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(product);
                }
            }
            catch
            {
                return View(product);
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productManager.Find(x => x.Id == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Product product)
        //{
        //    try
        //    {
        //        ModelState.Remove("CreatedOn");
        //        ModelState.Remove("ModifiedOn");
        //        ModelState.Remove("ModifiedUsername");

        //        if (ModelState.IsValid)
        //        {
        //            Product pro = productManager.Find(x => x.Id == product.Id);
        //            pro.Title = product.Title;
        //            pro.BrandId = product.BrandId;
        //            pro.CategoryId = product.CategoryId;
        //            pro.Image = product.Image;
        //            pro.InStock = product.InStock;
        //            pro.IsDraft = product.IsDraft;
        //            pro.Price = product.Price;
        //            pro.Quantity = product.Quantity;

        //            productManager.Update(pro);
        //            CacheHelper.RemoveCategoriesFromCache();

        //            return RedirectToAction("Index");
        //        }
        //        return View(product);
        //    }
        //    catch
        //    {
        //        return View(product);
        //    }
        //}

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = productManager.Find(x => x.Id == id);

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = productManager.Find(x => x.Id == id);
            productManager.Delete(product);

            CacheHelper.RemoveCategoriesFromCache();


            return RedirectToAction("Index");
        }
    }
}
