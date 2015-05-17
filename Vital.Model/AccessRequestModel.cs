using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Vital.Model
{
    [XmlType("AccessRequest")]
    public class AccessRequestModel
    {
        public string AccessLicenseNumber { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}
