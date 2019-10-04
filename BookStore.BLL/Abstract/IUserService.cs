using BookStore.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BLL.Abstract
{
    public interface IUserService : IBaseService<User>
    {
        User GetUserByCode(Guid code);
        bool ActivateUser(User user);
        User GetUserByLogin(string userName, string password);
    }
}
