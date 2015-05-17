using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Vital.Model;
using Vital.Data.Models;

namespace Vital.Service
{
    public class AddressBookInfoService : Vital.Service.IAddressBookInfoService
    {

        readonly IRepository<AddressBookInfo> _addressRepository;
        readonly ICustomerService _customerService;

        public AddressBookInfoService(IRepository<AddressBookInfo> addressRepository, ICustomerService customerService)
        {
            this._addressRepository = addressRepository;
            this._customerService = customerService;
        }

        public Guid Add(AddressBookInfoModel data, string username)
        {
            Guid customerId = _customerService.GetId(username);
            var newAddress = new AddressBookInfo()
            {
                Id = Guid.NewGuid(),
                NickName = data.NickName,
                CompanyOrName = data.CompanyOrName,
                Contact = data.Contact,
                Country = data.Country,
                AddressLine1 = data.AddressLine1,
                AddressLine2 = data.AddressLine2,
                AddressLine3 = data.AddressLine3,
                City = data.City,
                Province = data.Province,
                PostalCode = data.PostalCode,
                IsResidential = data.IsResidential,
                Telephone = data.Telephone,
                Extension = data.Extension,
                EmailAddress = data.EmailAddress,
                SaveAsShipperFromFlag = false,
                Customer_Id = customerId,
            };
            _addressRepository.Insert(newAddress);
            return newAddress.Id;
        }

        public AddressBookInfoModel Get(Guid id)
        {
            var data = _addressRepository.Find(id);
            return new AddressBookInfoModel()
            {
                Id = data.Id,
                NickName = data.NickName,
                CompanyOrName = data.CompanyOrName,
                Contact = data.Contact,
                Country = data.Country,
                AddressLine1 = data.AddressLine1,
                AddressLine2 = data.AddressLine2,
                AddressLine3 = data.AddressLine3,
                City = data.City,
                Province = data.Province,
                PostalCode = data.PostalCode,
                IsResidential = data.IsResidential,
                Telephone = data.Telephone,
                Extension = data.Extension,
                EmailAddress = data.EmailAddress,
                SaveAsShipperFromFlag = data.SaveAsShipperFromFlag,
                Customer_Id = data.Customer_Id,
            };
        }

        public void Update(AddressBookInfoModel data, Guid id)
        {
            var upt = _addressRepository.Find(id);
            upt.NickName = data.NickName;
            upt.CompanyOrName = data.CompanyOrName;
            upt.Contact = data.Contact;
            upt.Country = data.Country;
            upt.AddressLine1 = data.AddressLine1;
            upt.AddressLine2 = data.AddressLine2;
            upt.AddressLine3 = data.AddressLine3;
            upt.City = data.City;
            upt.Province = data.Province;
            upt.PostalCode = data.PostalCode;
            upt.IsResidential = data.IsResidential;
            upt.Telephone = data.Telephone;
            upt.Extension = data.Extension;
            upt.EmailAddress = data.EmailAddress;
            upt.ObjectState = ObjectState.Modified;
            _addressRepository.Update(upt);
        }

    }
}
