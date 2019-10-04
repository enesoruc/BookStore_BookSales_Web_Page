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
    public class PublishingHouseService : IPublishingHouseService
    {
        IPublishingHouseDAL _publishingHouseDAL;

        public PublishingHouseService(IPublishingHouseDAL publishingHouseDAL)
        {
            _publishingHouseDAL = publishingHouseDAL;
        }

        public bool Add(PublishingHouse model)
        {
            return _publishingHouseDAL.Add(model) > 0;
        }

        public bool Delete(PublishingHouse model)
        {
            return _publishingHouseDAL.Delete(model) > 0;
        }

        public bool Delete(int modelID)
        {
            PublishingHouse publishingHouse = _publishingHouseDAL.Get(a => a.ID == modelID);
            return _publishingHouseDAL.Delete(publishingHouse) > 0;
        }

        public PublishingHouse Get(int modelID)
        {
            return _publishingHouseDAL.Get(a => a.ID == modelID);
        }

        public List<PublishingHouse> GetAll()
        {
            return _publishingHouseDAL.GetAll().ToList();
        }

        public bool Update(PublishingHouse model)
        {
            return _publishingHouseDAL.Update(model) > 0;
        }
    }
}
