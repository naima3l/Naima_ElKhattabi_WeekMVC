using Naima_ElKhattabi_WeekMVC.Core.InterfaceRepositories;
using Naima_ElKhattabi_WeekMVC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naima_ElKhattabi_WeekMVC.EF.RepositoriesEF
{
    public class RepositoryUserEF : IUserRepository
    {
        public User Add(User item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(User item)
        {
            throw new NotImplementedException();
        }

        public List<User> Fetch()
        {
            throw new NotImplementedException();
        }

        public User GetByUsername(string username)
        {
            using (var ctx = new RestaurantContext())
            {
                if (string.IsNullOrEmpty(username))
                {
                    return null;
                }
                return ctx.Users.FirstOrDefault(u => u.Username == username);
            }
        }

        public User Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
