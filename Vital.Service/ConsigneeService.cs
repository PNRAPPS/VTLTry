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
    public class ConsigneeService : Vital.Service.IConsigneeService
    {
        readonly IRepository<Consignee> _consigneeRepository;
        readonly IRepository<Customer> _customerRepository;
        readonly IRepository<ConsigneeCustomer> _consigneeCustomerRepository;
        readonly ICustomerService _customerService;
        readonly IUnitOfWork _unitOfWork;

        public ConsigneeService(
            IRepository<Consignee> consigneeRepository,
            IRepository<Customer> customerRepository,
            IRepository<ConsigneeCustomer> consigneeCustomerRepository,
            ICustomerService customerService,IUnitOfWork unitOfWork)
        {
            this._consigneeRepository = consigneeRepository;
            this._customerRepository = customerRepository;
            this._consigneeCustomerRepository = consigneeCustomerRepository;
            this._customerService = customerService;
            this._unitOfWork = unitOfWork;
        }

        public AddressInformation GetAddressInformation(Guid id)
        {
            var data = this._consigneeRepository.Find(id);

            var info = new AddressInformation()
            {
                Id = id,
                Address1 = data.ConsigneeAddress1,
                Address2 = data.ConsigneeAddress2,
                Address3 = data.ConsigneeAddress3,
                City = data.ConsigneeCity,
                StateOrProvince = data.ConsigneeStateOrProvince,
                Country = data.ConsigneeCountry,
                Phone = data.ConsigneePhone,
                PostalOrZip = data.COnsigneePostalOrZip,
                PhoneExt = data.ConsigneePhoneExt,
                CompanyName = data.ConsigneeName,
                ContactName = data.ConsigneeContactPerson,
                Email = data.ConsigneeEmail,
            };

            return info;

        }

        public ConsigneeModel GetById(Guid id)
        {
            var data = this._consigneeRepository.Find(id);

            if (data == null)
                throw new Exception("Invalid Consignee ID");

            return new ConsigneeModel()
            {
                Id = data.Id,
                ConsigneeName = data.ConsigneeName,
                ConsigneeAddress1 = data.ConsigneeAddress1,
                ConsigneeAddress2 = data.ConsigneeAddress2,
                ConsigneeCity = data.ConsigneeCity,
                ConsigneeStateOrProvince = data.ConsigneeStateOrProvince,
                COnsigneePostalOrZip = data.COnsigneePostalOrZip,
                ConsigneeCountry = data.ConsigneeCountry,
                ConsigneeContactPerson = data.ConsigneeContactPerson,
                ConsigneePhone = data.ConsigneePhone,
                UPSId = data.UPSId,
                ConsigneeAddress3 = data.ConsigneeAddress3,
                ConsigneeEmail = data.ConsigneeEmail,
                ConsigneeIsResidential = data.ConsigneeIsResidential ?? false,
                ConsigneePhoneExt = data.ConsigneePhoneExt,
            };

        }

        public void Update(ConsigneeModel data, Guid id)
        {
            var upt = _consigneeRepository.Find(id);
            upt.AddressBookName = data.AddressBookName;
            upt.ConsigneeName = data.ConsigneeName;
            upt.ConsigneeContactPerson = data.ConsigneeContactPerson;
            upt.ConsigneeCountry = data.ConsigneeCountry;
            upt.ConsigneeAddress1 = data.ConsigneeAddress1;
            upt.ConsigneeAddress2 = data.ConsigneeAddress2;
            upt.ConsigneeAddress3 = data.ConsigneeAddress3;
            upt.ConsigneeCity = data.ConsigneeCity;
            upt.ConsigneeStateOrProvince = data.ConsigneeStateOrProvince;
            upt.COnsigneePostalOrZip = data.COnsigneePostalOrZip;
            upt.ConsigneePhone = data.ConsigneePhone;
            upt.ConsigneePhoneExt = data.ConsigneePhoneExt;
            upt.ConsigneeEmail = data.ConsigneeEmail;
            upt.ConsigneeIsResidential = data.ConsigneeIsResidential;

            upt.ObjectState = ObjectState.Modified;
            _consigneeRepository.Update(upt);
        }

        public void Add(ConsigneeModel data, string username)
        {
            Guid consigneeId = Guid.NewGuid();

            Guid customerId = _customerService.GetId(username);

            var insert = new Consignee()
            {
                Id = consigneeId,
                AddressBookName = data.AddressBookName,
                ConsigneeName = data.ConsigneeName,
                ConsigneeContactPerson = data.ConsigneeContactPerson,
                ConsigneeCountry = data.ConsigneeCountry,
                ConsigneeAddress1 = data.ConsigneeAddress1,
                ConsigneeAddress2 = data.ConsigneeAddress2,
                ConsigneeAddress3 = data.ConsigneeAddress3,
                ConsigneeCity = data.ConsigneeCity,
                ConsigneeStateOrProvince = data.ConsigneeStateOrProvince,
                COnsigneePostalOrZip = data.COnsigneePostalOrZip,
                ConsigneePhone = data.ConsigneePhone,
                ConsigneePhoneExt = data.ConsigneePhoneExt,
                ConsigneeEmail = data.ConsigneeEmail,
                ConsigneeIsResidential = data.ConsigneeIsResidential,
            };

            _consigneeRepository.Insert(insert);

            _consigneeCustomerRepository.Insert(new ConsigneeCustomer() { Customer_Id = customerId, Consignee_Id = insert.Id });

            data.Id = consigneeId;
        }

        public IEnumerable<ConsigneeModel> GetListByUserName(string username)
        {
            var list = this._customerRepository
                .Query()
                .Filter(x => x.UserName == username)
                .Include(x => x.ConsigneeCustomers)
                .Include(x => x.ConsigneeCustomers.Select(y => y.Consignee))
                .Get()
                .FirstOrDefault()
                .ConsigneeCustomers
                .Select(x => x.Consignee)
                .Select(data => new ConsigneeModel()
                {
                    Id = data.Id,
                    ConsigneeName = data.ConsigneeName,
                    ConsigneeAddress1 = data.ConsigneeAddress1,
                    ConsigneeAddress2 = data.ConsigneeAddress2,
                    ConsigneeAddress3 = data.ConsigneeAddress3,
                    ConsigneeCity = data.ConsigneeCity,
                    ConsigneeStateOrProvince = data.ConsigneeStateOrProvince,
                    COnsigneePostalOrZip = data.COnsigneePostalOrZip,
                    ConsigneeCountry = data.ConsigneeCountry,
                    ConsigneeContactPerson = data.ConsigneeContactPerson,
                    ConsigneePhone = data.ConsigneePhone,
                    UPSId = data.UPSId,
                    ConsigneeEmail = data.ConsigneeEmail,
                    ConsigneeIsResidential = data.ConsigneeIsResidential ?? false,
                    ConsigneePhoneExt = data.ConsigneePhoneExt,
                });
            return list.ToList();
        }

        public IEnumerable<ValueText> GetValueTextListByUserName(string username)
        {
            var list = this._customerRepository
                .Query()
                .Filter(x => x.UserName == username)
                .Include(x => x.ConsigneeCustomers)
                .Include(x => x.ConsigneeCustomers.Select(y => y.Consignee))
                .Get()
                .FirstOrDefault();

            var cc = list
                .ConsigneeCustomers
                .Select(x => x.Consignee)
                .Select(x => new ValueText()
                {
                    Text = x.ConsigneeName,
                    Value = x.Id.ToString(),
                });

            return cc.ToList();
        }

        public IEnumerable<ValueText> GetAddressBookValueTextListByUserName(string username)
        {
            var list = this._customerRepository
                .Query()
                .Filter(x => x.UserName == username)
                .Include(x => x.ConsigneeCustomers)
                .Include(x => x.ConsigneeCustomers.Select(y => y.Consignee))
                .Get()
                .FirstOrDefault()
                .ConsigneeCustomers
                .Select(x => x.Consignee)
                .ToList()
                .Select(x => new ValueText()
                {
                    Text = string.IsNullOrEmpty(x.AddressBookName) ? x.ConsigneeName : x.AddressBookName,
                    Value = x.Id.ToString(),
                });

            return list.ToList();
        }

        public bool DeleteAddressBook(Guid id){

            var data = _consigneeRepository.Query().Get().Where(x => x.Id == id).FirstOrDefault();

            if (data != null)
            {
                _consigneeRepository.Delete(data.Id);
                _unitOfWork.Save();
                return true;
            }
            else
            {

                return false;

            }
        }
    }
}
