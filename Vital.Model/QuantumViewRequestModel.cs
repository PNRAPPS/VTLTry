using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Vital.Model
{
    [XmlType("QuantumViewRequest")]
    public class QuantumViewRequestModel
    {
        public RequestModel Request { get; set; }
        public SubscriptionRequest SubscriptionRequest { get; set; }

        public QuantumViewRequestModel()
        {
            Request = new RequestModel();
            SubscriptionRequest = new SubscriptionRequest();
        }

    }

    [XmlType("Request")]
    public class RequestModel
    {
        public string RequestAction { get; set; }
    }

    public class SubscriptionRequest
    {
        public string Name { get; set; }
        public DateTimeRange DateTimeRange { get; set; }

        public SubscriptionRequest()
        {
            DateTimeRange = new DateTimeRange();
        }
    }

    public class DateTimeRange
    {
        public string BeginDateTime { get; set; }
        public string EndDateTime { get; set; }
    }
}
