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
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EfBasketDal(Context context) : base(context)
        {

        }

        public List<Basket> GetBasketByMenuTableNumber(int id)
        {
            using var context = new Context();
            var values= context.Baskets.Where(x=>x.MenuTableId == id).Include(y=>y.Product).ToList();
            return values;
        }
    }
}
