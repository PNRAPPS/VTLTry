using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vital.Model
{
    public class AddressInformation
    {
        public Guid Id { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Address3 { get; set; }

        public string City { get; set; }

        public string StateOrProvince { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string PostalOrZip { get; set; }

        public string PhoneExt { get; set; }

        public string ContactName { get; set; }

        public string Email { get; set; }

        public string CompanyName { get; set; }
    }
}
