using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vital.Data.Models;
using Vital.Model;

namespace Vital.Service
{
    public class CustomerAccountService : Vital.Service.ICustomerAccountService
    {
        private readonly IRepository<CustomerAccount> _customerAccountRepository;
        private readonly ICustomerService _customerService;
        readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ShipmentDetail> _shipmentDetailRepository;
        public CustomerAccountService(IRepository<CustomerAccount> customerAccountRepository, ICustomerService customerService,
            IUnitOfWork unitOfWork, IRepository<ShipmentDetail> shipmentDetailRepository)
        {
            this._customerAccountRepository = customerAccountRepository;
            this._customerService = customerService;
            this._unitOfWork = unitOfWork;
            this._shipmentDetailRepository = shipmentDetailRepository;
        }

        public IEnumerable<CustomerAccountModel> GetListByUsername(string username)
        {
            var data = _customerAccountRepository
                .Query().Filter(x => x.Customer.UserName == username)
                .Get()
                .Select(x => new CustomerAccountModel()
                {
                    Id = x.Id,
                    RateYear = x.RateYear,
                    TermName = x.Term.TermName,
                    UPSEnabled = x.UPSEnabled,
                });
            return data;
        }

        public CustomerAccountModel Add(CustomerAccountModel model, string username)
        {
            if (string.IsNullOrEmpty(model.Id)) throw new Exception("Account Number is empty");
            if (_customerAccountRepository.Find(model.Id) != null)
                throw new Exception("Account Number already belong to other Customer.");

            Guid customerId = _customerService.GetCustomerIdByUsername(username);

            var add = new CustomerAccount()
            {
                UPSEnabled = model.UPSEnabled,
                TermId = model.termId,
                Id = model.Id,
                CustomerId = customerId,
            };

            _customerAccountRepository.Insert(add);

            return model;
        }

        public bool deleteAccountNumber(string id)
        {
            var data = _customerAccountRepository.Query().Get().Where(x => x.Id == id).FirstOrDefault();

            if (data != null)
            {
                _customerAccountRepository.Delete(data.Id);
                _unitOfWork.Save();
                return true;
            }
            else
            {

                return false;

            }

        }

        //for invoice here
        public IEnumerable<ShipmentDetailModel> GetInvoiceListByAccountNumber(string accountnumber)
        {


            var data = _shipmentDetailRepository.Query().Filter(x => x.AccountNumber == accountnumber).Get().
                Select(x => new ShipmentDetailModel()
                {
                    InvoiceDate = x.InvoiceDate,
                    InvoiceNumber = x.InvoiceNumber,
                    LeadShipmentNumber = x.LeadShipmentNumber
                });

            return data;

        }
        //end

    }
}
