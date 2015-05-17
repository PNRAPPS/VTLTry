using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Vital.Model
{
    [XmlType("LocatorRequest")]
    public class LocatorRequestModel
    {
        public Request Request { get; set; }
        public OriginAddress OriginAddress { get; set; }
        public LocationSearchCriteria LocationSearchCriteria { get; set; }
        public Translate Translate { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
        public LocationID LocationID { get; set; }

        public LocatorRequestModel()
        {
            Request = new Request();
            OriginAddress = new OriginAddress();
            LocationSearchCriteria = new LocationSearchCriteria();
            Translate = new Translate();
            UnitOfMeasurement = new UnitOfMeasurement();
            LocationID = new LocationID();
        }
    }

    public class Request
    {
        public string RequestAction { get; set; }
        public int RequestOption { get; set; }
        public TransactionReference TransactionReference { get; set; }

        public Request()
        {
            TransactionReference = new TransactionReference();
        }
    }

    public class TransactionReference
    {
        public string CustomerContext { get; set; }
        public string XpciVersion { get; set; }
    }

    public class OriginAddress
    {
        public PhoneNumber PhoneNumber { get; set; }
        public AddressKeyFormat AddressKeyFormat { get; set; }
        public int MaximumListSize { get; set; }

        public OriginAddress()
        {
            PhoneNumber = new PhoneNumber();
            AddressKeyFormat = new AddressKeyFormat();
        }
    }

    public class StructuredPhoneNumber
    {
        public string PhoneDialPlanNumber { get; set; }
        public string PhoneLineNumber { get; set; }
    }

    public class PhoneNumber
    {
        public StructuredPhoneNumber StructuredPhoneNumber { get; set; }

        public PhoneNumber()
        {
            StructuredPhoneNumber = new StructuredPhoneNumber();
        }
    }

    public class AddressKeyFormat
    {
        public string AddressLine { get; set; }
        public string PoliticalDivision1 { get; set; }
        public string PoliticalDivision2 { get; set; }
        public string PostcodePrimaryLow { get; set; }
        public string CountryCode { get; set; }
    }

    public class Translate
    {
        public string LanguageCode { get; set; }
    }

    public class UnitOfMeasurement
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }

    public class LocationID { 
    }

    public class LocationSearchCriteria
    {
        [XmlElement("SearchOption")]
        public List<SearchOptions> SearchOption { get; set; }
        public string MaximumListSize { get; set; }
        public string SearchRadius { get; set; }

        public LocationSearchCriteria()
        {
            SearchOption = new List<SearchOptions>();
        }
    }

    public class SearchOptions
    {
        [XmlElement("OptionType")]
        public List<OptionType> OptionType { get; set; }

        [XmlElement("OptionCode")]
        public List<OptionCode> OptionCode { get; set; }

        public SearchOptions()
        {
            OptionType = new List<OptionType>();
            OptionCode = new List<OptionCode>();
        }
    }

    public class OptionType
    {
        public string Code { get; set; }
    }

    public class OptionCode
    {
        public string Code { get; set; }
    }
}
