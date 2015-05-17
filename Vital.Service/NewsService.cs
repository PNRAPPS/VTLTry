using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Vital.Data.Models;
using Vital.Model;

namespace Vital.Service
{
    public class NewsService : Vital.Service.INewsService
    {

        private readonly IRepository<News> _newsRepository;
        readonly IUnitOfWork _unitOfWork;

        public NewsService(IRepository<News> newsRepository, IUnitOfWork unitOfWork)
        {
            this._newsRepository = newsRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(NewsModel data)
        {

            var add = new News()
            {
                NewsTitle = data.NewsTitle,
                NewsDate = data.NewsDate,
                NewsCaption = data.NewsCaption,
                NewsContent = data.NewsContent,
                DateCreated = System.DateTime.Today
            };

            _newsRepository.Insert(add);
           _unitOfWork.Save();
         

        }


        public NewsModel GetNewsId(int id) {

            var data = _newsRepository.Query().Filter(x => x.ID == id).Get().Select(xx => new NewsModel
            {
                ID = xx.ID,
                NewsTitle = xx.NewsTitle,
                NewsDate = xx.NewsDate,
                NewsCaption = xx.NewsCaption,
                NewsContent = xx.NewsContent,
                
            }).FirstOrDefault();

            

            return data;
        
        }


        public void Update(NewsModel data, int id)
        {
            var news = _newsRepository
                .Query()
                .Filter(x => x.ID == id)
                .Get().FirstOrDefault();

            if (news == null) throw new Exception("Unable to find username");

            news.NewsTitle = data.NewsTitle;
            news.NewsDate = data.NewsDate;
            news.NewsCaption = data.NewsCaption;
            news.NewsContent = data.NewsContent;
            news.ObjectState = ObjectState.Modified;
            _newsRepository.Update(news);
            _unitOfWork.Save();

            /*
            upt.CustomerName = data.CompanyName;
            upt.ContactPerson = data.ContactPerson;
            upt.Email1 = data.Email;
            upt.Address1 = data.Address1;
            upt.Address2 = data.Address2;
            upt.City = data.City;
            upt.Province = data.State;
            upt.PostalCode = data.Zip;
            upt.Country = data.Country;
            upt.Phone = data.Phone;
            upt.PhoneExt = data.PhoneExt;

            upt.ObjectState = ObjectState.Modified;
            _customerRepository.Update(upt);*/
          
        }  /**/


        public IEnumerable<NewsModel> GetAllNews()
        {

            var data = _newsRepository.Query().Get().Select(x => new NewsModel()
            {
               ID = x.ID,
               NewsTitle = x.NewsTitle,
               NewsDate = x.NewsDate,
               NewsCaption = x.NewsCaption,
               NewsContent = x.NewsContent,
               DateCreated = x.DateCreated
            }); ;

            return data;
        }

        
        public bool deleteNews(int id) 
        {
            var data = _newsRepository.Query().Get().Where(x => x.ID == id).FirstOrDefault();

            if (data != null)
            {
                _newsRepository.Delete(data.ID);
                _unitOfWork.Save();
                return true;
            }
            else {

                return false;

            }
        
        }

        //public bool deleteUserAccount(string username)
        //{
        //    var data = _customerRepository.Query().Get().Where(x => x.UserName == username).FirstOrDefault();
            
        //    if (data != null)
        //    { 
                
        //    }

        //}

    }
}
