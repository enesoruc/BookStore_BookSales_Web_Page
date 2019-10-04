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
    public class MessageService : IMessageService
    {
        IMessageDAL _messageDAL;

        public MessageService(IMessageDAL messageDAL)
        {
            _messageDAL = messageDAL;
        }

        public bool Add(Message model)
        {
            return _messageDAL.Add(model) > 0;
        }

        public bool Delete(Message model)
        {
            return _messageDAL.Delete(model) > 0;
        }

        public bool Delete(int modelID)
        {
            Message message = _messageDAL.Get(a => a.ID == modelID);
            return _messageDAL.Delete(message) > 0;
        }

        public Message Get(int modelID)
        {
            return _messageDAL.Get(a => a.ID == modelID);
        }

        public List<Message> GetAll()
        {
            return _messageDAL.GetAll().ToList();
        }

        public bool Update(Message model)
        {
            return _messageDAL.Update(model) > 0;
        }
    }
}
