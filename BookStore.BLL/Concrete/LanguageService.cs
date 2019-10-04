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
    public class LanguageService : ILanguageService
    {
        ILanguageDAL _languageDAL;

        public LanguageService(ILanguageDAL languageDAL)
        {
            _languageDAL = languageDAL;
        }

        public bool Add(Language model)
        {
            return _languageDAL.Add(model) > 0;
        }

        public bool Delete(Language model)
        {
            return _languageDAL.Delete(model) > 0;
        }

        public bool Delete(int modelID)
        {
            Language language = _languageDAL.Get(a => a.ID == modelID);
            return _languageDAL.Delete(language) > 0;
        }

        public Language Get(int modelID)
        {
            return _languageDAL.Get(a => a.ID == modelID);
        }

        public List<Language> GetAll()
        {
            return _languageDAL.GetAll().ToList();
        }

        public bool Update(Language model)
        {
            return _languageDAL.Update(model) > 0;
        }
    }
}
