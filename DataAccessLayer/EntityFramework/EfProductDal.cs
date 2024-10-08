﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(Context context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            var context = new Context();
            var values = context.Products.Include(x => x.Category).ToList();
            return values;
        }

        public int ProductCount()
        {
            using var context = new Context();
            return context.Products.Count();
        }
        
        public int ProductCountByCategoryNameDrink()
        {
            using var context = new Context();
            return context.Products.
                Where(x => x.CategoryId == (context.Categories.
                Where(y => y.CategoryName == "İçecek").
                Select(z => z.CategoryId).FirstOrDefault())).Count();
        }

        public int ProductCountByCategoryNameHamburger()
        {
            using var context = new Context();
            return context.Products.
                Where(x => x.CategoryId == (context.Categories.
                Where(y => y.CategoryName == "Hamburger").
                Select(z => z.CategoryId).FirstOrDefault())).Count();
        }

        public string ProductNameByMaxPrice()
        {
            using var context = new Context();
            return context.Products.Where(x => x.Price == (context.Products.Max(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
        }

        public string ProductNameByMinPrice()
        {
            using var context = new Context();
            return context.Products.Where(x => x.Price == (context.Products.Min(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
        }

        public decimal ProductPriceAvg()
        {
            using var context = new Context();
            return context.Products.Average(x => x.Price);
        }

        public decimal ProductAvgPriceByHamburger()
        {
            using var context = new Context();
            return context.Products.Where(x=>x.CategoryId==(context.Categories.Where(y=>y.CategoryName=="Hamburger").Select(z=>z.CategoryId).FirstOrDefault())).Average(w=>w.Price);
        }

        public decimal ProductPriceBySteakBurger()
        {
            using var context = new Context();
            return context.Products.Where(x => x.ProductName == "Steak Burger").Select(y => y.Price).FirstOrDefault();
        }

        public decimal TotalPriceByDrinkCategory()
        {
            using var context = new Context();
            int id = context.Categories.Where(x => x.CategoryName == "İçecek").Select(y => y.CategoryId).FirstOrDefault();
            return context.Products.Where(x => x.CategoryId == id).Sum(y => y.Price);
        }

        public decimal TotalPriceBySaladCategory()
        {
            using var context = new Context();
            int id = context.Categories.Where(x => x.CategoryName == "Salata").Select(y => y.CategoryId).FirstOrDefault();
            return context.Products.Where(x => x.CategoryId == id).Sum(y => y.Price);
        }

		public List<Product> GetLast9Products()
		{
			var context = new Context();
            var values = context.Products.Take(9).ToList();
            return values;
		}
	}
}
