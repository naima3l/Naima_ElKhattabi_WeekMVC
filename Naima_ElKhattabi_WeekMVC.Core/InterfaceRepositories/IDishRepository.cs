using Naima_ElKhattabi_WeekMVC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naima_ElKhattabi_WeekMVC.Core.InterfaceRepositories
{
    public interface IDishRepository : IRepository<Dish>
    {
        Dish GetById(int id);
    }
}
