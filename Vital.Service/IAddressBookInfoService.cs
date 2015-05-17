using System;
namespace Vital.Service
{
    public interface IAddressBookInfoService
    {
        Guid Add(Vital.Model.AddressBookInfoModel data, string username);
        Vital.Model.AddressBookInfoModel Get(Guid id);
        void Update(Vital.Model.AddressBookInfoModel data, Guid id);
    }
}
