using BookStore.Core.DAL;
using BookStore.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Abstract
{
    public interface IMessageDAL : IRepository<Message>
    {
    }
}
