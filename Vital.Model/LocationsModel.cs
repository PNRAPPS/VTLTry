using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vital.Model
{
    public class LocationsModel
    {
        [DisplayName("Address")]
        public string CurrentLocation { get; set; }

        [DisplayName("Country")]
        public string Country { get; set; }

        [DisplayName("Find a dropoff location")]
        public bool IsFindDropOff { get; set; }

        [DisplayName("Pay for a UPS Shipping Label")]
        public bool IsPayForAUPSLabel { get; set; }

        [DisplayName("Help with packaging my shipment")]
        public bool IsHelpWithPackagingShipment { get; set; }

        [DisplayName("UPS Worldwide Express Freight Center")]
        public bool IsFilterByUPSWorldwide { get; set; }

        [DisplayName("UPS Store")]
        public bool IsUPSStore { get; set; }
        [DisplayName("UPS Access Point")]
        public bool IsUPSAccessPoint { get; set; }
        [DisplayName("UPS Drop Box")]
        public bool IsUPSDropbox { get; set; }
        [DisplayName("Retail Chains")]
        public bool IsRetailChains { get; set; }
        [DisplayName("UPS Customer Center")]
        public bool IsUPSCustomerCenter { get; set; }
        [DisplayName("UPS Authorized Shipping Outlet")]
        public bool IsAuthorizedShippingOutlet { get; set; }
        [DisplayName("UPS Authorized Service Provider")]
        public bool IsAuthorizedServiceProvider { get; set; }

        [DisplayName("Purchasing and Packaging Supplies")]
        public bool IsPurchasePackagingSupplies { get; set; }
        [DisplayName("Office Supplies")]
        public bool IsOfficeSupplies { get; set; }
        [DisplayName("Copying")]
        public bool IsCopying { get; set; }
        [DisplayName("Mailbox")]
        public bool IsMailbox { get; set; }
        [DisplayName("Notary Service")]
        public bool IsNotaryService { get; set; }
        [DisplayName("Crafting")]
        public bool IsCrating { get; set; }
        [DisplayName("UPS Returns")]
        public bool IsUPSReturns { get; set; }

        [DisplayName("Packing and Shipping Guarantee")]
        public bool IsPackShipGuarantee { get; set; }

        [DisplayName("International Shipping Expert")]
        public bool IsInternationalShippingExpert { get; set; }

        [DisplayName("Apple Returns")]
        public bool IsAppleReturn { get; set; }

        [DisplayName("Only Show Locations Within")]
        public bool IsOnlyShowLocationWithin { get; set; }
        [DisplayName("Distance")]
        public string LocationDistance { get; set; }

        [DisplayName("Only show locations with pickup time after")]
        public bool IsOnlyShowLocationWithPickupTimeWithin { get; set; }
        public int ServiceType { get; set; }
        public string PickupDay { get; set; }
        public string PickupTime { get; set; }

        [DisplayName("Only show locations open")]
        public bool IsOnlyShowLocationsOpen { get; set; }
        
        public string OpenDay { get; set; }
        public string OpenFrom { get; set; }
        public string OpenTo { get; set; }

    }
}
