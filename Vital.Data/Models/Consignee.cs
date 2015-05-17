using System;
using System.Collections.Generic;

namespace Vital.Data.Models
{
    public partial class Consignee : Repository.EntityBase
    {
        public Consignee()
        {
            this.ConsigneeCustomers = new List<ConsigneeCustomer>();
            this.ShipmentRequests = new List<ShipmentRequest>();
        }

        public System.Guid Id { get; set; }
        public string AddressBookName { get; set; }
        public string ConsigneeName { get; set; }
        public string ConsigneeAddress1 { get; set; }
        public string ConsigneeAddress2 { get; set; }
        public string ConsigneeAddress3 { get; set; }
        public string ConsigneeCity { get; set; }
        public string ConsigneeStateOrProvince { get; set; }
        public string COnsigneePostalOrZip { get; set; }
        public string ConsigneeCountry { get; set; }
        public string ConsigneeContactPerson { get; set; }
        public string ConsigneePhone { get; set; }
        public string ConsigneePhoneExt { get; set; }
        public string ConsigneeEmail { get; set; }
        public Nullable<bool> ConsigneeIsResidential { get; set; }
        public string UPSId { get; set; }
        public virtual ICollection<ConsigneeCustomer> ConsigneeCustomers { get; set; }
        public virtual ICollection<ShipmentRequest> ShipmentRequests { get; set; }
    }
}
