using E_Shopper_BLL;
using E_Shopper_BLL.Models;
using E_Shopper_Entity;
using E_Shopper_WebUI.Identity;
using E_Shopper_WebUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Shopper_WebUI.Controllers
{
    public class AccountController : Controller
    {
        DataContext db = new DataContext();

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        private readonly AddressManager addressManager;


        public AccountController()
        {
            var userStore = new UserStore<User>(new DataContext());
            _userManager = new UserManager<User>(userStore);

            var roleStore = new RoleStore<Role>(new DataContext());
            _roleManager = new RoleManager<Role>(roleStore);

            addressManager = new AddressManager();
        }
      
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Kayıt işlemleri
                var user = new User();
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Email = model.Email;
                user.UserName = model.Username;
                user.IsActive = false;
                user.IsAdmin = false;
                
                var result = _userManager.Create(user, model.Password);

                if (result.Succeeded)
                {
                    //Kullanıcı oluştu ve kullanıcıya bir rol atayabiliriz.
                    if (_roleManager.RoleExists("user"))
                    {
                        _userManager.AddToRole(user.Id, "user");
                    }
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı oluşturma hatası");
                }
            }
            return View(model);
        }

        public ActionResult Login()
        {
            if (Request.UrlReferrer != null)
            {
                TempData["returnUrl"] = Request.UrlReferrer.OriginalString;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                //Login işlemleri
                var user = _userManager.Find(model.Username, model.Password);

                if (user != null)
                {
                    //varolan kullanıcıyı sisteme dahil et.
                    //ApplicationCookie oluşturup sisteme bırak.

                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityClaims = _userManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProperties, identityClaims);
                    Session["login"] = user;
                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    ModelState.AddModelError("LoginUserError", "Böyle bir kullanıcı yok.");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult AddAddress(Address model)
        {
            if (ModelState.IsValid)
            {
                User user = (User)Session["login"];
                if (Request.IsAuthenticated && user.Addresses.Count==0)
                {
                    model.Ad = user.Name;
                    model.Soyad = user.Surname;
                    user.Addresses.Add(model);
                }   
                _userManager.Update(user);

                return View();
            }
            return View();
        }
    }
}