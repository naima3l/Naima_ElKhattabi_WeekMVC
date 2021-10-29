using Naima_ElKhattabi_WeekMVC.Core.Models;
using System;
using System.Collections.Generic;

namespace Naima_ElKhattabi_WeekMVC.Core
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //menu has n dishes
        public List<Dish> Dishes { get; set; } = new List<Dish>();
    }
}
