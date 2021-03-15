using E_Shopper_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Shopper_WebUI.Models;
using System.Data.Entity;
using E_Shopper_BLL;

namespace E_Shopper_WebUI.Controllers
{
    public class HomeController : Controller
    {
        private CategoryManager categoryManager = new CategoryManager();
        private ProductManager productManager = new ProductManager();
        private BrandManager brandManager = new BrandManager();
        // GET: Home
        public ActionResult Index()
        {
            List<Product> productlist = productManager.ListQueryable().ToList();
            if (productlist.Count > 0)
            {
                return View(productManager.ListQueryable().Where(x => x.IsDraft == true && x.IsHome == true).OrderByDescending(x => x.ModifiedOn).ToList());
            }
            else
            {
                return View();
            }
        }

        public PartialViewResult CategoryTab()
        {
            return PartialView(productManager.ListQueryable().OrderByDescending(i => i.ModifiedOn).ToList());
        }


        public ActionResult ProductList(int? id, int? page)
        {
            var viewModel = new ProductViewModel();
            List<Product> Items = productManager.ListQueryable().Include("Brand").Where(p => p.IsDraft == true).OrderByDescending(p => p.ModifiedOn).ToList();
            viewModel.Items = Items;

            if (id != null)
            {
                Items = Items.Where(p => p.BrandId == id).ToList();
            }

            var pager = new Pager(Items.Count(), page);
            viewModel.Items = Items.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList();
            viewModel.Pager = pager;
            ViewBag.BrandId = id;           
            return View(viewModel);
        }

        public ActionResult Details(int Id)
        {
            return View(productManager.Find(i => i.Id == Id));
        }

    }
}