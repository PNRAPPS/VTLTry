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
    public class InvoiceService : Vital.Service.IInvoiceService
    {

        private readonly IRepository<Invoice> _invoiceRepository;
        readonly IUnitOfWork _unitOfWork;

        public InvoiceService(IRepository<Invoice> _invoiceRepository, IUnitOfWork unitOfWork)
        {
            this._invoiceRepository = _invoiceRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(InvoiceModel data)
        {

            var add = new Invoice()
            {
                invoiceSubject = data.invoiceSubject,
                invoiceDetails = data.invoiceDetails,
                invoiceDate = data.invoiceDate,
                invoiceFileName = data.invoiceFileName,
                dateUpload = data.dateUpload,
                username = data.username,
                accountnumber = data.accountnumber
            };

            _invoiceRepository.Insert(add);
            _unitOfWork.Save();


        }

        public InvoiceModel GetInvoiceById(int id)
        {


            InvoiceModel invoice = _invoiceRepository
                 .Query().Filter(x => x.invoiceId == id)
                 .Get()
                 .Select(xx => new InvoiceModel()
                 {
                invoiceFileName = xx.invoiceFileName
            }).FirstOrDefault();

            return invoice;
        
        }

        public IEnumerable<InvoiceModel> GetInvoiceListByAccountNumber(string accountnumber, DateTime fromdate, DateTime todate)
        {

            var data = _invoiceRepository
                .Query().Filter(x => x.accountnumber == accountnumber && x.invoiceDate >= fromdate && x.invoiceDate <= todate)
                .Get()
                .Select(x => new InvoiceModel()
                {
                   invoiceId = x.invoiceId,
                   invoiceSubject = x.invoiceSubject,
                   invoiceDetails = x.invoiceDetails,
                   invoiceDate = x.invoiceDate,
                   invoiceFileName = x.invoiceFileName,
                   dateUpload = x.dateUpload,
                   username = x.username,
                   accountnumber = x.accountnumber
                });
            return data;
        }

        public string GetImageFromStream(byte[] imageBytes)
        {
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(imageBytes);
            return "data:application/pdf;base64," + Convert.ToBase64String(memoryStream.ToArray(), 0, memoryStream.ToArray().Length);
        }



    }
}
