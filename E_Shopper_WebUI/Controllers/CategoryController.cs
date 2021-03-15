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
    public class CategoryController : Controller
    {
        private CategoryManager categoryManager = new CategoryManager();
        private ProductManager productManager = new ProductManager();
        
        // GET: Category
        public ActionResult Index()
        {
            return View(categoryManager.List());
        }

        // GET: Category/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Category category = categoryManager.Find(x=> x.Id==id);
        //    if(category == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.urunler = new SelectList(productManager.List().Where(x => x.CategoryId == id), "Id", "Title");            
        //    return View(category);
        //}

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
                ModelState.Remove("CreatedOn");
                ModelState.Remove("ModifiedOn");
                ModelState.Remove("ModifiedUsername");

                if (ModelState.IsValid)
                {
                    categoryManager.Insert(category);
                    CacheHelper.RemoveCategoriesFromCache();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(category);
                }
            }
            catch
            {
                return View(category);
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = categoryManager.Find(x => x.Id == id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            try
            {
                ModelState.Remove("CreatedOn");
                ModelState.Remove("ModifiedOn");
                ModelState.Remove("ModifiedUsername");

                if (ModelState.IsValid)
                {
                    Category cat = categoryManager.Find(x => x.Id == category.Id);
                    cat.Title = category.Title;
                    cat.Description = category.Description;

                    categoryManager.Update(cat);
                    CacheHelper.RemoveCategoriesFromCache();

                    return RedirectToAction("Index");
                }
                return View(category);
            }
            catch
            {
                return View(category);
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = categoryManager.Find(x => x.Id == id);

            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = categoryManager.Find(x => x.Id == id);
            categoryManager.Delete(category);

            CacheHelper.RemoveCategoriesFromCache();


            return RedirectToAction("Index");
        }
       
    }
}
