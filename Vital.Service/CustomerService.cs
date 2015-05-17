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
    public class CustomerService : Vital.Service.ICustomerService
    {

        private readonly IRepository<Customer> _customerRepository;
        readonly IUnitOfWork _unitOfWork;

        public CustomerService(IRepository<Customer> customerRepository,IUnitOfWork unitOfWork)
        {
            this._customerRepository = customerRepository;
            this._unitOfWork = unitOfWork;
        }

        public string GetPassword(string username)
        {
            var data = _customerRepository
                .Query()
                .Filter(x => x.UserName == username)
                .Get()
                .Select(x => x.UPSPassword)
                .FirstOrDefault();
            return data;
        }

        public bool ValidateLogin(string username, string password, out string hashPassword)
        {

            var check = _customerRepository.Query().Filter(x => x.UserName == username).Get().Select(x => x.Password);

            if (!check.Any())
            {
                hashPassword = "";
                return false;
            }
            hashPassword = check.FirstOrDefault();
            return true;
        }

        public void Add(CustomerModel data)
        {

            var checkUsernameExists = _customerRepository.Query().Filter(x => x.UserName == data.Username).Get().Any();
            if (checkUsernameExists)
                throw new Exception("Username \"" + data.Username + "\" already exists.");

            var add = new Customer
                {
                    Id = Guid.NewGuid(),
                    CustomerName = data.CompanyName,
                    ContactPerson = data.ContactPerson,
                    Email1 = data.Email,
                    Address1 = data.Address1,
                    Address2 = data.Address2,
                    City = data.City,
                    Province = data.State,
                    PostalCode = data.Zip,
                    Country = data.Country,
                    Phone = data.Phone,
                    UserName = data.Username,
                    Password = data.Password,
                    //Password = Crypto.HashPassword(data.Password)
                };

            _customerRepository.Insert(add);

        }

        public CustomerModel GetByUsername(string username)
        {

            return _customerRepository
                .Query()
                .Filter(x => x.UserName == username)
                .Get()
                .Select(x => new CustomerModel()
                {
                    Address1 = x.Address1,
                    Address2 = x.Address2,
                    City = x.City,
                    CompanyName = x.CustomerName,
                    ContactPerson = x.ContactPerson,
                    Country = x.Country,
                    Email = x.Email1,
                    Phone = x.Phone,
                    Password = "",
                    State = x.Province,
                    Username = x.UserName,
                    Zip = x.PostalCode,
                    PhoneExt = x.PhoneExt,
                    UPSUsername = x.UPSUsername,
                    UPSPassword = x.UPSPassword,
                })
                .FirstOrDefault();
        }

        public Guid GetCustomerIdByUsername(string username)
        {
            Guid customerId = _customerRepository
                .Query()
                .Filter(x => x.UserName == username)
                .Get()
                .Select(x => x.Id)
                .First();
            return customerId;
        }


        public void Update(CustomerModel data, string username)
        {
            var upt = _customerRepository
                .Query()
                .Filter(x => x.UserName == username)
                .Get().FirstOrDefault();

            if (upt == null) throw new Exception("Unable to find username");

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
            _customerRepository.Update(upt);
            _unitOfWork.Save();

        }

        public Guid GetId(string username)
        {
            var data = _customerRepository
                .Query()
                .Filter(x => x.UserName == username)
                .Get()
                .Select(x => x.Id)
                .FirstOrDefault();

            if (data == null) throw new Exception("Invalid Username");

            return data;

        }

        public IEnumerable<CustomerModel> GetAllCustomer()
        {

            var data = _customerRepository.Query().Get().Select(x => new CustomerModel()
            {
               
               ContactPerson = x.ContactPerson,
               Username = x.UserName,
               Email = x.Email1,
               Address1 = x.Address1,
               Address2 = x.Address2,
               City = x.City,
               State = x.Province,
               Country = x.Country,
               Zip = x.PostalCode,
               Phone = x.Phone,
               CompanyName = x.CustomerName
            }); ;

            return data;
        }

        public IEnumerable<CustomerModel> GetListSearchResult(string s)
        {

            var data = _customerRepository.Query().Filter(x => x.UserName.Contains(s)).Get().Select(x => new CustomerModel()
            {

                ContactPerson = x.ContactPerson,
                Username = x.UserName,
                Email = x.Email1,
                Address1 = x.Address1,
                Address2 = x.Address2,
                City = x.City,
                State = x.Province,
                Country = x.Country,
                Zip = x.PostalCode,
                Phone = x.Phone,
                CompanyName = x.CustomerName,
                PhoneExt = x.PhoneExt
            }); ;

            return data;
        }

        
        public bool deleteUserAccount(string username) 
        {
            var data = _customerRepository.Query().Get().Where(x => x.UserName == username).FirstOrDefault();

            if (data != null)
            {
                _customerRepository.Delete(data.Id);
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
