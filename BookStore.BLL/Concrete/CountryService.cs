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
    public class CountryService : ICountryService
    {
        ICountryDAL _countryDAL;

        public CountryService(ICountryDAL countryDAL)
        {
            _countryDAL = countryDAL;
        }

        public bool Add(Country model)
        {
            return _countryDAL.Add(model) > 0;
        }

        public bool Delete(Country model)
        {
            return _countryDAL.Delete(model) > 0;
        }

        public bool Delete(int modelID)
        {
            Country country = _countryDAL.Get(a => a.ID == modelID);
            return _countryDAL.Delete(country) > 0;
        }

        public Country Get(int modelID)
        {
            return _countryDAL.Get(a => a.ID == modelID);
        }

        public List<Country> GetAll()
        {
            return _countryDAL.GetAll().ToList();
        }

        public bool Update(Country model)
        {
            return _countryDAL.Update(model) > 0;
        }
    }
}
