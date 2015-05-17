using System;
using Vital.Model;
namespace Vital.Service
{
    public interface IInvoiceService
    {
        void Add(InvoiceModel data);

        System.Collections.Generic.IEnumerable<Model.InvoiceModel> GetInvoiceListByAccountNumber(string accountnumber, DateTime fromdate, DateTime todate);


        InvoiceModel GetInvoiceById(int id);

        string GetImageFromStream(byte[] imageBytes);

    }
}
