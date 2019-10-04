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
    public class CampaignService : ICampaignService
    {
        ICampaignDAL _campaignDAL;

        public CampaignService(ICampaignDAL campaignDAL)
        {
            _campaignDAL = campaignDAL;
        }

        public bool Add(Campaign model)
        {
            return _campaignDAL.Add(model) > 0;
        }

        public bool Delete(Campaign model)
        {
            return _campaignDAL.Delete(model) > 0;
        }

        public bool Delete(int modelID)
        {
            Campaign campaign = _campaignDAL.Get(a => a.ID == modelID);
            return _campaignDAL.Delete(campaign) > 0;
        }

        public Campaign Get(int modelID)
        {
            return _campaignDAL.Get(a => a.ID == modelID);
        }

        public List<Campaign> GetAll()
        {
            return _campaignDAL.GetAll().ToList();
        }

        public bool Update(Campaign model)
        {
            return _campaignDAL.Update(model) > 0;
        }
    }
}
