using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vital.Model
{
    public class AddressBookInfoModel
    {
        public System.Guid Id { get; set; }
        public string NickName { get; set; }
        public string CompanyOrName { get; set; }
        public string Contact { get; set; }
        public string Country { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public bool IsResidential { get; set; }
        public string Telephone { get; set; }
        public string Extension { get; set; }
        public string Fax { get; set; }
        public string EmailAddress { get; set; }
        public string LocationID { get; set; }
        public bool SaveAsShipperFromFlag { get; set; }
        public string ReceiverUPSAccount { get; set; }
        public string ReceiverPostalCode { get; set; }
        public string ReferenceType1 { get; set; }
        public string ReferenceType2 { get; set; }
        public System.Guid OwnerOfAddressBook_Id { get; set; }
        public Nullable<System.Guid> Customer_Id { get; set; }
    }
}
