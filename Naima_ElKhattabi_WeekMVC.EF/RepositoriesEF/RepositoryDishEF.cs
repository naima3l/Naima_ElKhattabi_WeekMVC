using Microsoft.EntityFrameworkCore;
using Naima_ElKhattabi_WeekMVC.Core.InterfaceRepositories;
using Naima_ElKhattabi_WeekMVC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naima_ElKhattabi_WeekMVC.EF.RepositoriesEF
{
    public class RepositoryDishEF : IDishRepository
    {
        public Dish Add(Dish item)
        {
            using (var ctx = new RestaurantContext())
            {
                ctx.Dishes.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Dish item)
        {
            using (var ctx = new RestaurantContext())
            {
                ctx.Dishes.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Dish> Fetch()
        {
            using (var ctx = new RestaurantContext())
            {
                return ctx.Dishes.Include(d => d.Menu).ToList();
            }
        }

        public Dish GetById(int id)
        {
            using (var ctx = new RestaurantContext())
            {
                return ctx.Dishes.Include(d => d.Menu).FirstOrDefault(d => d.Id == id);
            }
        }

        public Dish Update(Dish item)
        {
            using (var ctx = new RestaurantContext())
            {
                ctx.Dishes.Update(item);
                ctx.SaveChanges();
            }
            return item;
        }
    }
}
