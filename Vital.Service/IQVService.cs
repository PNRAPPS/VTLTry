using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vital.Service
{
    public interface IQVService
    {
        IEnumerable<Vital.Model.QuantumViewShipmentDetail> GetShipmentData(string eventName, string status, string shipperNumber, string filter, string tag, string fromDate, string toDate);
    }
}
