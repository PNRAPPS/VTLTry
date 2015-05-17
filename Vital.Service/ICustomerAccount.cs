namespace Vital.Service
{
    public interface ICustomerAccountService
    {
        Model.CustomerAccountModel Add(Model.CustomerAccountModel model, string username);
        System.Collections.Generic.IEnumerable<Model.CustomerAccountModel> GetListByUsername(string username);

        bool deleteAccountNumber(string accountnumber);

        //for invoice
        System.Collections.Generic.IEnumerable<Model.ShipmentDetailModel> GetInvoiceListByAccountNumber(string accountnumber);
    }
}
