using E_Shopper_Entity;
using E_Shopper_WebUI.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Shopper_WebUI.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Checkout()
        {
            if (Request.IsAuthenticated)
            {
                User user = (User)Session["login"];
                TempData["login"] = user;
                ViewBag.Address = new SelectList(user.Addresses.ToList(), "Id", "AdresBasligi");
            }
            
            return View(GetCart());
        }
        public Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];

            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}