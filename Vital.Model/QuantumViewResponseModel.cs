using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Vital.Model
{
    public class QuantumViewResponse
    {
        public Response Response { get; set; }
        public QuantumViewEvents QuantumViewEvents { get; set; }
    }

    public class Response
    {
        public string TransactionReference { get; set; }
        public string ResponseStatusCode { get; set; }
        public string ResponseStatusDescription { get; set; }
        public Error Error { get; set; }
    }

    public class Error
    {
        public string ErrorSeverity { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
    }

    public class SubscriptionStatus
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }

    public class QuantumViewEvents
    {
        public string SubscriberID { get; set; }

        [XmlElement("SubscriptionEvents")]
        public List<SubscriptionEvents> SubscriptionEvents { get; set; }

        public QuantumViewEvents()
        {
            SubscriptionEvents = new List<SubscriptionEvents>();
        }
    }

    public class SubscriptionEvents
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public SubscriptionStatus SubscriptionStatus { get; set; }

        [XmlElement("SubscriptionFile")]
        public List<SubscriptionFile> SubscriptionFile { get; set; }

        public SubscriptionEvents()
        {

            SubscriptionFile = new List<SubscriptionFile>();
        }
    }

    public class SubscriptionFile
    {
        public string FileName { get; set; }
        public SubscriptionStatus StatusType { get; set; }

        [XmlElement("Delivery")]
        public List<Delivery> Delivery { get; set; }

        [XmlElement("Manifest")]
        public List<Manifest> Manifest { get; set; }

        [XmlElement("Exception")]
        public List<QVException> Exception { get; set; }

        public SubscriptionFile()
        {
            Delivery = new List<Delivery>();
            Manifest = new List<Manifest>();
            Exception = new List<QVException>();
        }
    }

    public class Origin
    {
        public string ShipperNumer { get; set; }
        public string TrackingNumber { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }

    public class ActivityLocation
    {
        public AddressArtifactFormat AddressArtifactFormat { get; set; }
    }
    public class AddressArtifactFormat
    {
        public string StreetNumberLow { get; set; }
        public string StreetName { get; set; }
        public string StreetType { get; set; }
        public string PoliticalDivision2 { get; set; }
        public string PoliticalDivision1 { get; set; }
        public string CountryCode { get; set; }
        public string PostcodePrimaryLow { get; set; }
        public string ResidentialAddressIndicator { get; set; }
    }

    public class Delivery
    {
        public string ShipperNumber { get; set; }
        public string TrackingNumber { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public ActivityLocation ActivityLocation { get; set; }
        public DeliveryLocation DeliveryLocation { get; set; }
        public string COD { get; set; }
    }

    public class DeliveryLocation
    {
        public AddressArtifactFormat AddressArtifactFormat { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string SignedForByName { get; set; }
    }

    public class Manifest
    {
        public Shipper Shipper { get; set; }
        public Shipper ShipTo { get; set; }
        public Service Service { get; set; }
        public string PickupDate { get; set; }
        public string ScheduledDeliveryDate { get; set; }
        public string ScheduledDeliveryTime { get; set; }
        public Package Package { get; set; }
    }

    public class QVException
    {
        public string ShipperNumber { get; set; }
        public string TrackingNumber { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string ReasonCode { get; set; }
        public string ReasonDescription { get; set; }
        public ActivityLocation ActivityLocation { get; set; }
        public BillToAccount BillToAccount { get; set; }
    }

    public class Shipper
    {
        public string Name { get; set; }
        public string ShipperNumber { get; set; }
        public Address Address { get; set; }
    }

    public class Address
    {
        public string ConsigneeName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string StateProvinceCode { get; set; }
        public string PostalCode { get; set; }
        public string CountryCode { get; set; }
    }

    public class Service
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }

    public class Package
    {
        public Activity Activity { get; set; }
        public string TrackingNumber { get; set; }
        public PackageServiceOptions PackageServiceOptions { get; set; }
        public BillToAccount BillToAccount { get; set; }
    }

    public class PackageServiceOptions
    {
        public string COD { get; set; }
    }

    public class Activity
    {
        public string Date { get; set; }
        public string Time { get; set; }
    }

    public class BillToAccount
    {
        public string Option { get; set; }
        public string Number { get; set; }
    }

}
