using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vital.Data.Models
{
    public partial class LookupTable : Repository.EntityBase
    {
        public int LookupId { get; set; }
        public string LookupCode { get; set; }
        public string LookupValue { get; set; }
        public string LookupText { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
