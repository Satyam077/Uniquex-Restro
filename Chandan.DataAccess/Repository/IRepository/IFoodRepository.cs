using Abby.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abby.DataAccess.Repository.IRepository
{
    public interface IFoodRepository : IRepository<FoodType>
    {
        void Update(FoodType obj);
        
    }
}
