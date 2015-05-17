using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vital.Model
{

    public class ConsigneeModel
    {

        public System.Guid Id { get; set; }
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
        public bool ConsigneeIsResidential { get; set; }
        public string UPSId { get; set; }

        public string AddressBookName { get; set; }
    }

}
