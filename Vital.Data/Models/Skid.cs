using System;
using System.Collections.Generic;

namespace Vital.Data.Models
{
    public partial class Skid
    {
        public int Id { get; set; }
        public string SkidDescription { get; set; }
        public double ItemLength { get; set; }
        public double ItemWidth { get; set; }
        public double ItemHeight { get; set; }
        public double SkidVolume { get; set; }
        public double SkidWeight { get; set; }
        public string UnitOfMeasurement { get; set; }
        public string QuotationId { get; set; }
    }
}
