using Naima_ElKhattabi_WeekMVC.Core;
using Naima_ElKhattabi_WeekMVC.Core.Models;
using Naima_ElKhattabi_WeekMVC.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Naima_ElKhattabi_WeekMVC.MVC.Helper
{
    public static class Mapping
    {
        public static MenuViewModel toMenuViewModel(this Menu menu)
        {
            List<DishViewModel> dishesViewModel = new List<DishViewModel>();
            foreach (var item in menu.Dishes)
            {
                dishesViewModel.Add(item.toDishViewModel());
            }

            return new MenuViewModel
            {
                Id = menu.Id,
                Name = menu.Name,
                Dishes = dishesViewModel
            };
        }

        public static Menu toMenu(this MenuViewModel menuViewModel)
        {
            List<Dish> dishes = new List<Dish>();
            foreach (var item in menuViewModel.Dishes)
            {
                dishes.Add(item.toDish());
            }

            return new Menu
            {
                Id = menuViewModel.Id,
                Name = menuViewModel.Name,
                Dishes = dishes
            };
        }

        public static DishViewModel toDishViewModel(this Dish dish)
        {
            return new DishViewModel
            {
                Id = dish.Id,
                Name = dish.Name,
                Description = dish.Description,
                Type = (Models.EnumDishType)dish.Type,
                Price = dish.Price,
                MenuId = dish.MenuId
            };
        }

        public static Dish toDish(this DishViewModel dishViewModel)
        {
            return new Dish
            {
                Id = dishViewModel.Id,
                Name = dishViewModel.Name,
                Description = dishViewModel.Description,
                Type = (Core.Models.EnumDishType)dishViewModel.Type,
                Price = dishViewModel.Price,
                MenuId = dishViewModel.MenuId
            };
        }
    }
}
