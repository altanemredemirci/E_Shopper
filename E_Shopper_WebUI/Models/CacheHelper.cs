using E_Shopper_BLL;
using E_Shopper_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace E_Shopper_WebUI.Models
{
    public class CacheHelper
    {
        public static List<Category> GetCategoriesFromCache()
        {
            var result = WebCache.Get("category-cache");

            if (result == null)
            {
                CategoryManager categoryManager = new CategoryManager();
                result = categoryManager.List();

                WebCache.Set("category-cache", result, 20, true);
            }

            return result;
        }

        public static void RemoveCategoriesFromCache()
        {
            Remove("category-cache");
        }

        public static List<Brand> GetBrandsFromCache()
        {
            var result = WebCache.Get("brand-cache");

            if (result == null)
            {
                BrandManager brandManager = new BrandManager();
                result = brandManager.List();

                WebCache.Set("brand-cache", result, 20, true);
            }

            return result;
        }

        public static void RemoveBrandsFromCache()
        {
            Remove("brand-cache");
        }

        public static void Remove(string key)
        {
            WebCache.Remove(key);
        }

        public static List<CategoryBrand> GetCategoryBrandsFromCache()
        {
            var result = WebCache.Get("categorybrand-cache");

            if (result == null)
            {
                CategoryManager categoryManager = new CategoryManager();
                result = categoryManager.List();

                WebCache.Set("categorybrand-cache", result, 20, true);
            }

            return result;
        }

        public static void RemoveCategoryBrandFromCache()
        {
            Remove("categorybrand-cache");
        }

    }
}