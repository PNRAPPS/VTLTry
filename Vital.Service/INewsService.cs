using System;
using Vital.Model;
namespace Vital.Service
{
    public interface INewsService
    {
        void Add(Vital.Model.NewsModel data);
        //Vital.Model.NewsModel GetByUsername(string username);
        //Guid GetCustomerIdByUsername(string username);
      //  bool ValidateLogin(string username, string password, out string hashPassword);
        void Update(Model.NewsModel data, int id);
        //Guid GetId(string username);
        //string GetPassword(string username);

        NewsModel GetNewsId(int id);

        System.Collections.Generic.IEnumerable<Model.NewsModel> GetAllNews();

        bool deleteNews(int id);


       // void update(NewsModel news);
    }
}
