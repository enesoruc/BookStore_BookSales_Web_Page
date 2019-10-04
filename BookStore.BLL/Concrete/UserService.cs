using BookStore.BLL.Abstract;
using BookStore.DAL.Abstract;
using BookStore.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BLL.Concrete
{
    public class UserService : IUserService
    {
        IUserDAL _userDAL;

        public UserService(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public bool ActivateUser(User user)
        {
            user.IsActive = true;
            return Update(user);
        }

        public bool Add(User model)
        {
           return _userDAL.Add(model) > 0;
        }

        public bool Delete(User model)
        {
            return _userDAL.Delete(model) > 0;
        }

        public bool Delete(int modelID)
        {
            User user = _userDAL.Get(a=>a.ID==modelID);
            return _userDAL.Delete(user) > 0;
        }

        public User Get(int modelID)
        {
            return _userDAL.Get(a => a.ID == modelID);
        }

        public List<User> GetAll()
        {
           return _userDAL.GetAll().ToList();
        }

        public User GetUserByCode(Guid code)
        {
            return _userDAL.Get(a => a.ActivationCode == code);
        }

        public User GetUserByLogin(string userName, string password)
        {
            return _userDAL.Get(a => a.UserName == userName && a.Password == password);
        }

        public bool Update(User model)
        {
            return _userDAL.Update(model) > 0;
        }
    }
}
