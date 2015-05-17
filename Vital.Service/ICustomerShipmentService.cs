using System;
using System.Collections.Generic;
using Vital.Model;
namespace Vital.Service
{
    public interface ICustomerShipmentService
    {
        void Add(Vital.Model.CustomerShipmentModel data, string username);
        void Void(string id);
        IEnumerable<CustomerShipmentModel> GetListByPage(string username, int page, out int totalCount);
        IEnumerable<CustomerShipmentModel> GetAll(string username, out int totalCount);
        CustomerShipmentModel GetShipment(string trackingNumber);
    }
}
