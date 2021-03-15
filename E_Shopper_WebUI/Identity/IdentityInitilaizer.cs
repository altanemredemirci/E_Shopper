using E_Shopper_Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shopper_WebUI.Identity
{
    public class IdentityInitilaizer:CreateDatabaseIfNotExists<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            //Rolleri
            if (!context.Roles.Any(i => i.Name == "admin"))
            {
                var store = new RoleStore<Role>(context);
                var manager = new RoleManager<Role>(store);
                var role = new Role() { Name = "admin", Description = "admin rolü" };
                manager.Create(role);
            }
            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<Role>(context);
                var manager = new RoleManager<Role>(store);
                var role = new Role() { Name = "user", Description = "user rolü" };
                manager.Create(role);
            }

            //User

            if (!context.Users.Any(i => i.Name == "altanemre"))
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var user = new User() { Name = "altanemre", Surname = "demirci", UserName = "altanemre", Email = "altanemre@gmail.com", IsAdmin=true, IsActive=true};
                Address address = new Address()
                {
                    AdresBasligi = "Ev",
                    Ad = "Altan Emre",
                    Soyad = "Demirci",
                    Email = "altanemre1989@hotmail.com",
                    TelefonNumarasi = "05366295131",
                    Adres = "Akın Sok. No:10 Daire:5",
                    Il = "İstanbul",
                    Ilce = "Ümraniye",
                    Mahalle = "Tantavi",
                    PostaKodu = "34220"
                };
                user.Addresses.Add(address);
                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");
            }

            if (!context.Users.Any(i => i.Name == "altanuras"))
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var user = new User() { Name = "altan", Surname = "uras", UserName = "altanuras", Email = "altanuras@gmail.com", IsAdmin = false, IsActive = true };
                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "user");
            }

            base.Seed(context);
        }
    }
}

