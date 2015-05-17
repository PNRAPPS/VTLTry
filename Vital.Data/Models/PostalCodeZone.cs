using System;
using System.Collections.Generic;

namespace Vital.Data.Models
{
    public partial class PostalCodeZone
    {
        public System.Guid Id { get; set; }
        public System.Guid PostalCodeId { get; set; }
        public System.Guid ShippingTypeId { get; set; }
        public int ZoneId { get; set; }
        public virtual PostalCode PostalCode { get; set; }
        public virtual ShippingType ShippingType { get; set; }
        public virtual Zone Zone { get; set; }
    }
}
