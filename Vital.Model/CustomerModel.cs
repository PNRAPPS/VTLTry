using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vital.Model
{
    public class CustomerModel
    {
        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string ContactPerson { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Compare("Email")]
        public string VerifyEmail { get; set; }

        [Required]
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Zip { get; set; }

        [Required]
        public string Country { get; set; }

        public string Phone { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string VerifyPassword { get; set; }

        public string PhoneExt { get; set; }

        public string UPSUsername { get; set; }

        public string UPSPassword { get; set; }
    }
}
