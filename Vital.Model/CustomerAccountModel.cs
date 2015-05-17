using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vital.Model
{
    public class CustomerAccountModel
    {

        [Required]
        [DisplayName("Account Number")]
        public string Id { get; set; }

        [Required]
        [DisplayName("Rate Year")]
        public int RateYear { get; set; }

        public string TermName { get; set; }

        [DisplayName("UPS Enabled")]
        public bool UPSEnabled { get; set; }

        [Required]
        public Guid termId { get; set; }
    }
}
