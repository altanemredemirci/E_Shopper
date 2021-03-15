using E_Shopper_Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shopper_DAL.EntityFramework
{
    public class MyInitializer : CreateDatabaseIfNotExists<DataContext>
    {
        Random r = new Random();
        int[] fiyatlar = { 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150 };
        protected override void Seed(DataContext context)
        {

            Category cat1 = new Category()
            {
                Title = "T-Shirt",
                Description = "Kısa Kollu",
                ModifiedUsername = "altanemre",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            };
            context.Categories.Add(cat1);
            Category cat2 = new Category()
            {
                Title = "Sweatshirt",
                Description = "Uzun Kollu",
                ModifiedUsername = "altanemre",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            };
            context.Categories.Add(cat2);
            Category cat3 = new Category()
            {
                Title = "Bluz",
                Description = "Bisiklet Yaka",
                ModifiedUsername = "altanemre",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            };
            context.Categories.Add(cat3);
            Category cat4 = new Category()
            {
                Title = "Pantolon",
                Description = "Slim Fit",
                ModifiedUsername = "altanemre",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now

            };
            context.Categories.Add(cat4);
            Category cat5 = new Category()
            {
                Title = "Ayakkabı",
                Description = "Sportwear",
                ModifiedUsername = "altanemre",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            };
            context.Categories.Add(cat5);

            Brand brand1 = new Brand()
            {
                Name = "LcWaikiki",
                ModifiedUsername = "altanemre",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                Categories= new List<Category>()
                {
                    cat1,cat2,cat3,cat4,cat5
                }
            };
            context.Brands.Add(brand1);

            for (int j = 0; j < 10; j++)
            {
                Product product = new Product()
                {
                    Title = "Easy Polo Edition",
                    Price = fiyatlar[r.Next(1,12)],
                    InStock = true,
                    Quantity = 20,
                    Image = "product"+r.Next(1,7)+".jpg",
                    IsDraft = true,
                    IsHome = false,
                    Type = Types.Erkek,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    ModifiedUsername = "altanemre"
                };
                brand1.Products.Add(product);
            }

            Brand brand2 = new Brand()
            {
                Name = "Koton",
                ModifiedUsername = "altanemre",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                Categories = new List<Category>()
                {
                    cat1,cat2,cat3
                }
            };
            context.Brands.Add(brand2);

            for (int j = 0; j < 10; j++)
            {
                Product product = new Product()
                {
                    Title = "Easy Polo Edition",
                    Price = fiyatlar[r.Next(1, 12)],
                    InStock = true,
                    Quantity = 20,
                    Image = "product" + r.Next(1, 7) + ".jpg",
                    IsDraft = true,
                    IsHome = false,
                    Type = Types.Erkek,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    ModifiedUsername = "altanemre"
                };
                brand2.Products.Add(product);
            }

            Brand brand3 = new Brand()
            {
                Name = "Zara",
                ModifiedUsername = "altanemre",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                Categories = new List<Category>()
                {
                    cat1,cat3,cat5
                }
            };
            context.Brands.Add(brand3);

            for (int j = 0; j < 10; j++)
            {
                Product product = new Product()
                {
                    Title = "Easy Polo Edition",
                    Price = fiyatlar[r.Next(1, 12)],
                    InStock = true,
                    Quantity = 20,
                    Image = "product" + r.Next(1, 7) + ".jpg",
                    IsDraft = true,
                    IsHome = false,
                    Type = Types.Erkek,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    ModifiedUsername = "altanemre"
                };
                brand3.Products.Add(product);
            }

            Brand brand4 = new Brand()
            {
                Name = "Mango",
                ModifiedUsername = "altanemre",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                Categories = new List<Category>()
                {
                    cat1,cat3
                }
            };
            context.Brands.Add(brand4);

            for (int j = 0; j < 10; j++)
            {
                Product product = new Product()
                {
                    Title = "Easy Polo Edition",
                    Price = fiyatlar[r.Next(1, 12)],
                    InStock = true,
                    Quantity = 20,
                    Image = "product" + r.Next(1, 7) + ".jpg",
                    IsDraft = true,
                    IsHome = false,
                    Type = Types.Erkek,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    ModifiedUsername = "altanemre"
                };
                brand4.Products.Add(product);
            }

            Brand brand5 = new Brand()
            {
                Name = "Flo",
                ModifiedUsername = "altanemre",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                Categories = new List<Category>()
                {
                    cat5
                }
            };
            context.Brands.Add(brand5);

            for (int j = 0; j < 10; j++)
            {
                Product product = new Product()
                {
                    Title = "Easy Polo Edition",
                    Price = fiyatlar[r.Next(1, 12)],
                    InStock = true,
                    Quantity = 20,
                    Image = "product" + r.Next(1, 7) + ".jpg",
                    IsDraft = true,
                    IsHome = false,
                    Type = Types.Erkek,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    ModifiedUsername = "altanemre"
                };
                brand5.Products.Add(product);
            }
            context.SaveChanges();
        }
    }
}



