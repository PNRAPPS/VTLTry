using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vital.Model
{
    public class SkidRatesModel
    {
        public int Id { get; set; }
        public int SkidPieces { get; set; }
        public string OriginCity { get; set; }
        public string OriginState { get; set; }
        public string OriginAbbreviation { get; set; }
        public string OriginCountry { get; set; }
        public string DestinationCity { get; set; }
        public string DestinationState { get; set; }
        public string DestinationAbbreviation { get; set; }
        public string DestinationCountry { get; set; }
        public string Type { get; set; }
        public decimal Rate { get; set; }
        public System.Guid CarrierId { get; set; }
        public int SkidWeightId { get; set; }
      

    }
}
