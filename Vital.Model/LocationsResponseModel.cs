using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vital.Model
{
    public class LocationResponseSearchResults
    {
        public string ConsigneeName { get; set; }
        public string AddressLine { get; set; }
        public string PoliticalDivision1 { get; set; }
        public string PoliticalDivision2 { get; set; }
        public string PostCodePrimaryLow { get; set; }
        public string CountryCode { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal Distance { get; set; }
    }

    public class LocationResponseModel
    {
        public string ResponseStatusCode { get; set; }
        public string ResponseMessage { get; set; }
        public List<LocationResponseSearchResults> SearchResults { get; set; }
    }
}
