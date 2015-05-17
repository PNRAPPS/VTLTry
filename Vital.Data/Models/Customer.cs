using System;
using System.Collections.Generic;

namespace Vital.Data.Models
{
    public partial class Customer : Repository.EntityBase
    {
        public Customer()
        {
            this.AddressBookInfoes = new List<AddressBookInfo>();
            this.ConsigneeCustomers = new List<ConsigneeCustomer>();
            this.CustomerAccounts = new List<CustomerAccount>();
            this.CustomerMarkups = new List<CustomerMarkup>();
            this.CustomerSpInstructionAmounts = new List<CustomerSpInstructionAmount>();
            this.ShipmentRequests = new List<ShipmentRequest>();
            this.Roles = new List<Role>();
            this.CustomerShipments = new List<CustomerShipment>();
        }

        public System.Guid Id { get; set; }
        public string CustomerName { get; set; }
        public string ContactPerson { get; set; }
        public string Phone { get; set; }
        public string PhoneExt { get; set; }
        public string Fax { get; set; }
        public string AltPhone { get; set; }
        public string AltContactPerson { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string SalesRepresentative { get; set; }
        public decimal CommissionRate { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UPSPassword { get; set; }
        public string UPSUsername { get; set; }

        public virtual ICollection<AddressBookInfo> AddressBookInfoes { get; set; }
        public virtual ICollection<ConsigneeCustomer> ConsigneeCustomers { get; set; }
        public virtual ICollection<CustomerAccount> CustomerAccounts { get; set; }
        public virtual ICollection<CustomerMarkup> CustomerMarkups { get; set; }
        public virtual ICollection<CustomerSpInstructionAmount> CustomerSpInstructionAmounts { get; set; }
        public virtual ICollection<ShipmentRequest> ShipmentRequests { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<CustomerShipment> CustomerShipments { get; set; }
    }
}
