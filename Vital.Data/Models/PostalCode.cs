using System;
using System.Collections.Generic;

namespace Vital.Data.Models
{
    public partial class PostalCode
    {
        public PostalCode()
        {
            this.PostalCodeZones = new List<PostalCodeZone>();
        }

        public System.Guid Id { get; set; }
        public string OriginCountry { get; set; }
        public string OriginPostalCodeMin { get; set; }
        public string OriginPostalCodeMax { get; set; }
        public string DestinationCountry { get; set; }
        public string DestinationPostalCodeMin { get; set; }
        public string DestinationPostalCodeMax { get; set; }
        public virtual ICollection<PostalCodeZone> PostalCodeZones { get; set; }
    }
}
