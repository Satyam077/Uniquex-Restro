using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Abby.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        public DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            //_db.MenuItem.Include(u => u.FoodType).Include(u => u.Category);
            //Order By
           // _db.MenuItem.OrderBy(u => u.Name);
            this.dbSet = db.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null,
            string ? includeproperties = null)
        {
            IQueryable < T > query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeproperties != null)
            {
                foreach (var includeProperty in includeproperties.Split(
                new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) {
                    query = query.Include(includeProperty);
                }
            }
            if(orderby != null) 
            {
                return orderby(query).ToList();
            }
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null, string? includeproperties = null)
        {
            IQueryable<T> query = dbSet;
            if(filter != null)
            {
               query = query.Where(filter);
            }
            if (includeproperties != null)
            {
                foreach (var includeProperty in includeproperties.Split(
                new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
