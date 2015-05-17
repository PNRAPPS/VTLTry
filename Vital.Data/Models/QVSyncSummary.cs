using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vital.Data.Models
{
    public class QVSyncSummary : Repository.EntityBase
    {
        public int QVSyncId { get; set; }
        public DateTime QVSyncDate { get; set; }
        public string QVSyncStatusCode { get; set; }
        public string QVSyncStatusDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string QVEventName { get; set; }
    }
}
