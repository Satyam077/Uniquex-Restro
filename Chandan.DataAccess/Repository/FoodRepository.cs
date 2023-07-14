using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abby.DataAccess.Repository
{
    public class FoodRepository : Repository<FoodType>, IFoodRepository
    {
        private readonly ApplicationDbContext _db;
        public FoodRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }   
        public void Update(FoodType obj)
        {
            var objFromDb = _db.FoodType.FirstOrDefault(u => u.Id == obj.Id);
            objFromDb.Name = obj.Name;            
        }
    }
}
