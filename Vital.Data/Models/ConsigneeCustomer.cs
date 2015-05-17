using System;
using System.Collections.Generic;

namespace Vital.Data.Models
{
    public partial class ConsigneeCustomer : Repository.EntityBase
    {
        public System.Guid Consignee_Id { get; set; }
        public System.Guid Customer_Id { get; set; }
        public virtual Consignee Consignee { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
