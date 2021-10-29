using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Naima_ElKhattabi_WeekMVC.MVC.Models
{
    public class DishViewModel
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public EnumDishType Type { get; set; }
        public decimal Price { get; set; }

        //FK -> Menu
        public int MenuId { get; set; }
        //A dish is in only one Menu
        public MenuViewModel Menu { get; set; }
    }
    public enum EnumDishType
    {
        Primo = 1,
        Secondo = 2,
        Contorno = 3,
        Dolce = 4
    }
}
