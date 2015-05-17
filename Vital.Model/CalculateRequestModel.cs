using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vital.Model
{
    public class CalculateRequestModel
    {
        public string FromCity { get; set; }

        [Required]
        public string FromCountryCode { get; set; }

        [Required]
        public string FromPostalCode { get; set; }

        public string ToCity { get; set; }

        [Required]
        public string ToCountryCode { get; set; }

        [Required]
        public string ToPostalCode { get; set; }

        [Required]
        public string PickUpDate { get; set; }

        public List<CustomerAccountModel> Accounts { get; set; }

        public string SelectedAccount { get; set; }

        //Shipment Information
        public decimal? Length { get; set; }

        public decimal? Width { get; set; }

        public decimal? Height { get; set; }

        public decimal? Weight { get; set; }

        public int? NumberOfPackages { get; set; }

        public decimal? DeclaredValue { get; set; }

        public string CurrencyCode { get; set; }

        public int MonetaryValue { get; set; }

        public string PackageType { get; set; }

        //Service Summary
        public List<ServiceSummaryModel> ServiceSummaries { get; set; }
    }
}
