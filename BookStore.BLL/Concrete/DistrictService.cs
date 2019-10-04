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
    public class DistrictService : IDistrictService
    {
        IDistrictDAL _districtDAL;

        public DistrictService(IDistrictDAL districtDAL)
        {
            _districtDAL = districtDAL;
        }

        public bool Add(District model)
        {
            return _districtDAL.Add(model) > 0;
        }

        public bool Delete(District model)
        {
            return _districtDAL.Delete(model) > 0;
        }

        public bool Delete(int modelID)
        {
            District district = _districtDAL.Get(a => a.ID == modelID);
            return _districtDAL.Delete(district) > 0;
        }

        public District Get(int modelID)
        {
            return _districtDAL.Get(a => a.ID == modelID);
        }

        public List<District> GetAll()
        {
            return _districtDAL.GetAll().ToList();
        }

        public bool Update(District model)
        {
            return _districtDAL.Update(model) > 0;
        }
    }
}
