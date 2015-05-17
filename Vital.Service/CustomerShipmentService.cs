using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vital.Model;
using Repository;
using Vital.Data.Models;

namespace Vital.Service
{
    public class CustomerShipmentService : Vital.Service.ICustomerShipmentService
    {

        readonly IRepository<CustomerShipment> _customerShipmentRepository;
        readonly ICustomerService _customerService;

        public CustomerShipmentService(
            IRepository<CustomerShipment> customerShipmentRepository,
            ICustomerService customerService)
        {
            this._customerService = customerService;
            this._customerShipmentRepository = customerShipmentRepository;
        }

        public void Add(CustomerShipmentModel data, string username)
        {
            data.customerId = _customerService.GetId(username);
            var id = Guid.NewGuid();
            var add = new CustomerShipment()
            {
                Id = id,
                customerId = data.customerId,
                trackingNumber = data.trackingNumber,
                pickupNumber = data.pickupNumber ?? string.Empty,
                status = data.status,
                shipmentLabel = data.shipmentLabel,
                createdDate = DateTime.Now,
            };
            data.Id = id;
            _customerShipmentRepository.Insert(add);
        }

        public void Void(string id)
        {
            var data = _customerShipmentRepository.Query().Filter(r => r.trackingNumber == id).Get();
            var upt = _customerShipmentRepository.Find(data.First().Id);

            upt.status = ShipmentModel.Void;
            upt.modifiedDate = DateTime.Now;

            upt.ObjectState = ObjectState.Modified;
            _customerShipmentRepository.Update(upt);

        }

        public CustomerShipmentModel GetShipment(string trackingNumber)
        {
            return _customerShipmentRepository.Query().Filter(r => r.trackingNumber == trackingNumber).Get().Select(r => new CustomerShipmentModel() { 
            
                trackingNumber = r.trackingNumber,
                status = r.status,
                shipmentLabel = r.shipmentLabel,
                pickupNumber = r.pickupNumber,
                Id = r.Id,
                customerId = r.customerId,
                createdDate = r.createdDate

            }).First();
        }

        public IEnumerable<CustomerShipmentModel> GetListByPage(string username, int page, out int totalCount)
        {
            var customerId = _customerService.GetId(username);
            int _totalCount = 0;
            var data = _customerShipmentRepository
                .Query()
                .Filter(x => x.customerId == customerId)
                .OrderBy(x => x.OrderByDescending(c => c.createdDate))
                .GetPage(page, 10, out _totalCount).Select(x => new CustomerShipmentModel()
                 {
                     trackingNumber = x.trackingNumber,
                     pickupNumber = x.pickupNumber,
                     status = x.status,
                     Id = x.Id,
                     createdDate = x.createdDate,
                     customerId = x.customerId,
                 })
                 .ToList();
            totalCount = _totalCount;
            return data;
        }

        public IEnumerable<CustomerShipmentModel> GetAll(string username, out int totalCount)
        {
            var customerId = _customerService.GetId(username);
            var data = _customerShipmentRepository
                .Query()
                .Filter(x => x.customerId == customerId)
                .OrderBy(x => x.OrderByDescending(c => c.createdDate))
                .Get()
                .Select(x => new CustomerShipmentModel()
                {
                    trackingNumber = x.trackingNumber,
                    pickupNumber = x.pickupNumber,
                    status = x.status,
                    Id = x.Id,
                    createdDate = x.createdDate,
                    customerId = x.customerId,
                })
                 .ToList();
            totalCount = data.Count();
            return data;
        }

    }
}
