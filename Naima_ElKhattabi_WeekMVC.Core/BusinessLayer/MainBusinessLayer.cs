using Naima_ElKhattabi_WeekMVC.Core.InterfaceRepositories;
using Naima_ElKhattabi_WeekMVC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naima_ElKhattabi_WeekMVC.Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {
        private readonly IMenuRepository menuRepo;
        private readonly IDishRepository dishRepo;
        private readonly IUserRepository userRepo;

        public MainBusinessLayer(IMenuRepository menuRepository, IDishRepository dishRepository, IUserRepository userRepository)
        {
            menuRepo = menuRepository;
            dishRepo = dishRepository;
            userRepo = userRepository;
        }

        public bool AddNewDish(Dish dish)
        {
            var existingMenu = menuRepo.GetById(dish.MenuId);
            if(existingMenu == null)
            {
                return false; // non esiste un menù con quell'id
            }

            dishRepo.Add(dish);
            return true;
        }

        public bool AddNewMenu(Menu menu)
        {
            var existingMenu = menuRepo.GetById(menu.Id);
            if (existingMenu == null)
            {
                return false;
            }
            menuRepo.Add(menu);
            return true;
        }

        public bool DeleteDish(int dishId)
        {
            var exisistingDish = dishRepo.GetById(dishId);
            if(exisistingDish == null)
            {
                return false;
            }
            return dishRepo.Delete(exisistingDish);
        }

        public bool DeleteMenu(int menuId)
        {
            var existingMenu = menuRepo.GetById(menuId);
            if(existingMenu == null)
            {
                return false;
            }
            if(existingMenu.Dishes.Count !=0)
            {
                return false; //ho dei piatti associati quindi non posso eliminare il menu
            }
            return menuRepo.Delete(existingMenu);
        }

        public bool EditDish(Dish dish)
        {
            var old = dishRepo.GetById(dish.Id);
            if(old == null)
            {
                return false;
            }
            dishRepo.Update(dish);
            return true;
        }

        public bool EditMenu(Menu menu)
        {
            var existingMenu = menuRepo.GetById(menu.Id);
            if (existingMenu == null)
            {
                return false;
            }
            menuRepo.Update(menu);
            return true;
        }

        public User GetAccount(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return null;
            }
            return userRepo.GetByUsername(username);
        }

        public List<Dish> GetDishes()
        {
            return dishRepo.Fetch();
        }

        public List<Menu> GetMenus()
        {
            return menuRepo.Fetch();
        }
    }
}
