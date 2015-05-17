using System;
using System.Collections.Generic;

namespace Vital.Data.Models
{
    public partial class AdminUser : Repository.EntityBase
    {

        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public System.DateTime CreatedDate { get; set; }

    }
}
