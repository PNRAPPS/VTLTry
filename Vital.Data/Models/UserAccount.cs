using System;
using System.Collections.Generic;

namespace Vital.Data.Models
{
    public partial class UserAccount
    {
        public System.Guid Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
    }
}
