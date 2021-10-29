using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Naima_ElKhattabi_WeekMVC.MVC.Models
{
    public class MenuViewModel
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }

        //menu has n dishes
        public List<DishViewModel> Dishes { get; set; } = new List<DishViewModel>();
    }
}
