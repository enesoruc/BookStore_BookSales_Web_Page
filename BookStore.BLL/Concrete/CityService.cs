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
    public class CityService : ICityService
    {
        ICityDAL _cityDAL;

        public CityService(ICityDAL cityDAL)
        {
            _cityDAL = cityDAL;
        }

        public bool Add(City model)
        {
            return _cityDAL.Add(model) > 0;
        }

        public bool Delete(City model)
        {
            return _cityDAL.Delete(model) > 0;
        }

        public bool Delete(int modelID)
        {
            City city = _cityDAL.Get(a => a.ID == modelID);
            return _cityDAL.Delete(city) > 0;
        }

        public City Get(int modelID)
        {
            return _cityDAL.Get(a => a.ID == modelID);
        }

        public List<City> GetAll()
        {
            return _cityDAL.GetAll().ToList();
        }

        public bool Update(City model)
        {
            return _cityDAL.Update(model) > 0;
        }
    }
}
