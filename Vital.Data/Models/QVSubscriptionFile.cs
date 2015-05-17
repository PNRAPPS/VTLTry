using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vital.Data.Models
{
    public class QVSubscriptionFile : Repository.EntityBase
    {
        public int SubscriptionFileId { get; set; }
        public int SyncId { get; set; }
        public string SubscriptionFileName { get; set; }
        public string SubscriptionNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string Status { get; set; }
    }
}
