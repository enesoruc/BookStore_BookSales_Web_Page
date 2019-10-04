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
    public class OrderService : IOrderService
    {
        IOrderDAL _orderDAL;

        public OrderService(IOrderDAL orderDAL)
        {
            _orderDAL = orderDAL;
        }

        public bool Add(Order model)
        {
            return _orderDAL.Add(model) > 0;
        }

        public bool Delete(Order model)
        {
            return _orderDAL.Delete(model) > 0;
        }

        public bool Delete(int modelID)
        {
            Order order = _orderDAL.Get(a => a.ID == modelID);
            return _orderDAL.Delete(order) > 0;
        }

        public Order Get(int modelID)
        {
            return _orderDAL.Get(a => a.ID == modelID);
        }

        public List<Order> GetAll()
        {
            return _orderDAL.GetAll().ToList();
        }

        public bool Update(Order model)
        {
            return _orderDAL.Update(model) > 0;
        }
    }
}
