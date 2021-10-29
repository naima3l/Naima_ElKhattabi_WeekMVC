using Microsoft.EntityFrameworkCore;
using Naima_ElKhattabi_WeekMVC.Core;
using Naima_ElKhattabi_WeekMVC.Core.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naima_ElKhattabi_WeekMVC.EF.RepositoriesEF
{
    public class RepositoryMenuEF : IMenuRepository
    {
        public Menu Add(Menu item)
        {
            using (var ctx = new RestaurantContext())
            {
                ctx.Menus.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Menu item)
        {
            using (var ctx = new RestaurantContext())
            {
                ctx.Menus.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Menu> Fetch()
        {
            using (var ctx = new RestaurantContext())
            {
                return ctx.Menus.Include(m=> m.Dishes).ToList();
            }
        }

        public Menu GetById(int menuId)
        {
            using (var ctx = new RestaurantContext())
            {
                return ctx.Menus.Include(m => m.Dishes).FirstOrDefault(m=> m.Id == menuId);
            }
        }

        public Menu Update(Menu item)
        {
            using (var ctx = new RestaurantContext())
            {
                ctx.Menus.Update(item);
                ctx.SaveChanges();
            }
            return item;
        }
    }
}
