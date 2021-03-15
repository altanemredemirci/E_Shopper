using E_Shopper_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Shopper_WebUI.Controllers
{
    public class AdminController : Controller
    {       
        // GET: Admin
        public ActionResult Index()
        {            
            return View();
        }

        // GET: Admin/Details/5
        public ActionResult Category()
        {
            return RedirectToAction("Index", "Category");
        }

        // GET: Admin/Create
        public ActionResult Brand()
        {
            return RedirectToAction("Index", "Brand");
        }
        public ActionResult Product()
        {
            return RedirectToAction("Index", "Product");
        }
        //public ActionResult User()
        //{
        //    return RedirectToAction("Index", "User");
        //}
    }
}
