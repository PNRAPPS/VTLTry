using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Vital.Model
{

    [XmlType("TimeInTransitResponse")]
    public class TNTResponse
    {
        public Response Response { get; set; }
        public TransitResponse TransitResponse { get; set; }
    }

    public class TransitResponse
    {
        public string MaximumListSize { get; set; }
        public string Disclaimer { get; set; }
        public InvoiceLineTotal InvoiceLineTotal { get; set; }
        public ShipmentWeight ShipmentWeight { get; set; }
        public string PickupDate { get; set; }
        public TransitFrom TransitFrom { get; set; }
        public TransitTo TransitTo { get; set; }

        [XmlElement("ServiceSummary")]
        public List<ServiceSummary> ServiceSummary { get; set; }

        public TransitResponse()
        {
            ServiceSummary = new List<ServiceSummary>();
        }
    }

    public class Guaranteed
    {
        public string Code { get; set; }
    }

    public class EstimatedArrival
    {
        public string BusinessTransitDays { get; set; }
        public string Time { get; set; }
        public string PickupDate { get; set; }
        public string PickupTime { get; set; }
        public string HolidayCount { get; set; }
        public string DelayCount { get; set; }
        public string Date { get; set; }
        public string DayOfWeek { get; set; }
        public string TotalTransitDays { get; set; }
        public string CustomerCenterCutoff { get; set; }
        public string RestDays { get; set; }
    }

    public class ServiceSummary
    {
        public Service Service { get; set; }
        public Guaranteed Guaranteed { get; set; }
        public EstimatedArrival EstimatedArrival { get; set; }
    }
}

