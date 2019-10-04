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
    public class AddressService : IAddressService
    {
        IAddressDAL _addressDAL;

        public AddressService(IAddressDAL addressDAL)
        {
            _addressDAL = addressDAL;
        }

        public bool Add(Address model)
        {
            return _addressDAL.Add(model) > 0;
        }

        public bool Delete(Address model)
        {
            return _addressDAL.Delete(model) > 0;
        }

        public bool Delete(int modelID)
        {
            Address address = _addressDAL.Get(a => a.ID == modelID);
            return _addressDAL.Delete(address) > 0;
        }

        public Address Get(int modelID)
        {
            return _addressDAL.Get(a => a.ID == modelID);
        }

        public List<Address> GetAll()
        {
            return _addressDAL.GetAll().ToList();
        }

        public bool Update(Address model)
        {
            return _addressDAL.Update(model) > 0;
        }
    }
}
