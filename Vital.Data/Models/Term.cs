using System;
using System.Collections.Generic;

namespace Vital.Data.Models
{
    public partial class Term : Repository.EntityBase
    {
        public Term()
        {
            this.CustomerAccounts = new List<CustomerAccount>();
        }

        public System.Guid Id { get; set; }
        public string TermName { get; set; }
        public virtual ICollection<CustomerAccount> CustomerAccounts { get; set; }
    }
}
