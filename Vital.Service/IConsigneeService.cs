using System;
using System.Collections.Generic;
using Vital.Data.Models;
using Vital.Model;
namespace Vital.Service
{
    public interface IConsigneeService
    {
        Vital.Model.ConsigneeModel GetById(Guid id);
        IEnumerable<ConsigneeModel> GetListByUserName(string username);
        IEnumerable<ValueText> GetValueTextListByUserName(string username);
        AddressInformation GetAddressInformation(Guid id);
        void Update(ConsigneeModel data, Guid id);
        void Add(ConsigneeModel data, string username);
        IEnumerable<ValueText> GetAddressBookValueTextListByUserName(string username);

        bool DeleteAddressBook(Guid id);
    }
}
