using Naima_ElKhattabi_WeekMVC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naima_ElKhattabi_WeekMVC.Core.BusinessLayer
{
    public interface IBusinessLayer
    {
        #region Menu
        public List<Menu> GetMenus();
        public bool AddNewMenu(Menu menu);
        public bool EditMenu(Menu menu);
        public bool DeleteMenu(int menuId);
        #endregion

        #region Dish
        public List<Dish> GetDishes();
        public bool AddNewDish(Dish dish);
        public bool EditDish(Dish dish);
        public bool DeleteDish(int dishId);
        #endregion

        #region User
        public User GetAccount(string username);
        #endregion
    }
}
