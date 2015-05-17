using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Vital.Model
{

    public class AccessRequest
    {
        public string AccessLicenseNumber { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
    }

    [XmlType("TimeInTransitRequest")]
    public class TNTRequest
    {
        public Request Request { get; set; }
        public TransitFrom TransitFrom { get; set; }
        public TransitTo TransitTo { get; set; }
        public string PickupDate { get; set; }
        public string MaximumListSize { get; set; }
        public InvoiceLineTotal InvoiceLineTotal { get; set; }
        public ShipmentWeight ShipmentWeight { get; set; }

        public TNTRequest()
        {
            Request = new Request();
            TransitFrom = new TransitFrom();
            TransitTo = new TransitTo();
            InvoiceLineTotal = new InvoiceLineTotal();
            ShipmentWeight = new ShipmentWeight();
        }
    }

    public class TransitFrom
    {
        public AddressArtifactFormat AddressArtifactFormat { get; set; }

        public TransitFrom()
        {

            AddressArtifactFormat = new AddressArtifactFormat();

        }
    }

    public class TransitTo
    {
        public AddressArtifactFormat AddressArtifactFormat { get; set; }

        public TransitTo()
        {

            AddressArtifactFormat = new AddressArtifactFormat();

        }

    }

    public class InvoiceLineTotal
    {
        public string CurrencyCode { get; set; }
        public string MonetaryValue { get; set; }
    }

    public class ShipmentWeight
    {
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
        public string Weight { get; set; }

        public ShipmentWeight()
        {
            UnitOfMeasurement = new UnitOfMeasurement();
        }
    }
}

