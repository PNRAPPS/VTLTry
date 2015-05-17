using System;
using Vital.Model;
namespace Vital.Service
{
    public interface ICustomerService
    {
        void Add(Vital.Model.CustomerModel data);
        Vital.Model.CustomerModel GetByUsername(string username);
        Guid GetCustomerIdByUsername(string username);
        bool ValidateLogin(string username, string password, out string hashPassword);
        void Update(Model.CustomerModel data, string username);
        Guid GetId(string username);
        string GetPassword(string username);

        System.Collections.Generic.IEnumerable<Model.CustomerModel> GetAllCustomer();
        System.Collections.Generic.IEnumerable<Model.CustomerModel> GetListSearchResult(string s);
        bool deleteUserAccount(string username);

    }
}
