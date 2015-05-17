using System;
using System.Collections.Generic;

namespace Vital.Data.Models
{
    public partial class ShippingType
    {
        public ShippingType()
        {
            this.PostalCodeZones = new List<PostalCodeZone>();
        }

        public System.Guid Id { get; set; }
        public string Content { get; set; }
        public string Service { get; set; }
        public virtual ICollection<PostalCodeZone> PostalCodeZones { get; set; }
    }
}
