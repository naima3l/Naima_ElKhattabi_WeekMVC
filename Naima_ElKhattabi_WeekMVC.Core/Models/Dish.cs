using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naima_ElKhattabi_WeekMVC.Core.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public EnumDishType Type{ get; set; }
        public decimal Price { get; set; }

        //FK -> Menu
        public int MenuId { get; set; }
        //A dish is in only one Menu
        public Menu Menu { get; set; }
    }
    public enum EnumDishType
    {
        Primo = 1,
        Secondo = 2,
        Contorno = 3,
        Dolce = 4
    }
}
