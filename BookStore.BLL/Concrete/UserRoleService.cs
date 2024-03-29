﻿using BookStore.BLL.Abstract;
using BookStore.DAL.Abstract;
using BookStore.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BLL.Concrete
{
    public class UserRoleService : IUserRoleService
    {
        IUserRoleDAL _userRoleDAL;

        public UserRoleService(IUserRoleDAL userRoleDAL)
        {
            _userRoleDAL = userRoleDAL;
        }

        public bool Add(UserRole model)
        {
           return _userRoleDAL.Add(model) > 0;
        }

        public bool Delete(UserRole model)
        {
            return _userRoleDAL.Delete(model) > 0;
        }

        public bool Delete(int modelID)
        {
            UserRole userRole = _userRoleDAL.Get(a=>a.ID==modelID);
            return _userRoleDAL.Delete(userRole) > 0;
        }

        public UserRole Get(int modelID)
        {
            return _userRoleDAL.Get(a => a.ID == modelID);
        }

        public List<UserRole> GetAll()
        {
            return _userRoleDAL.GetAll().ToList();
        }

        public UserRole GetByRoleName(string roleName)
        {
            return _userRoleDAL.Get(a => a.RoleName == roleName);
        }

        public bool Update(UserRole model)
        {
            return _userRoleDAL.Update(model) > 0;
        }
    }
}
