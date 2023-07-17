﻿using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abby.DataAccess.Repository
{
    public class UnitOfWork :IUnitOfWork
    {
        
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;          
            Category = new CategoryRepository(_db);
            FoodType = new FoodRepository(_db);
            MenuItem = new MenuItemRepository(_db);
        }

        public ICategoryRepository Category { get; private set; }
        public IFoodRepository FoodType { get; private set; }
        public IMenuItemRepository MenuItem { get; private set; }

        public void Dispose()
        {
           _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();

        }
    }
}
