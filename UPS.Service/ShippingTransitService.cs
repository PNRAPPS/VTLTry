using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPS.Service.TimeInTransitService;
using Vital.Model;

namespace UPS.Service
{
    public class ShippingTransitService : UPS.Service.IShippingTransitService
    {
        public CalculateRequestModel Calculate(CalculateRequestModel model)
        {
            TimeInTransitService.TimeInTransitService tntService = new TimeInTransitService.TimeInTransitService();
            TimeInTransitRequest tntRequest = new TimeInTransitRequest();
            RequestType request = new RequestType();
            String[] requestOption = { "TNT" };
            request.RequestOption = requestOption;
            tntRequest.Request = request;

            RequestShipFromType shipFrom = new RequestShipFromType();
            RequestShipFromAddressType addressFrom = new RequestShipFromAddressType();
            addressFrom.City = model.FromCity;
            addressFrom.CountryCode = model.FromCountryCode;
            addressFrom.PostalCode = model.FromPostalCode;
            //addressFrom.StateProvinceCode = "ShipFrom state province code";
            shipFrom.Address = addressFrom;
            tntRequest.ShipFrom = shipFrom;

            RequestShipToType shipTo = new RequestShipToType();
            RequestShipToAddressType addressTo = new RequestShipToAddressType();
            addressTo.City = model.ToCity;
            addressTo.CountryCode = model.ToCountryCode;
            addressTo.PostalCode = model.ToPostalCode;
            //addressTo.StateProvinceCode = "ShipTo state province code";
            shipTo.Address = addressTo;
            tntRequest.ShipTo = shipTo;

            PickupType pickup = new PickupType();
            pickup.Date = model.PickUpDate.Remove(4, 1).Remove(6, 1);
            tntRequest.Pickup = pickup;

            //Below code uses dummy data for reference. Please update as required.
            ShipmentWeightType shipmentWeight = new ShipmentWeightType();
            shipmentWeight.Weight = "10";
            CodeDescriptionType unitOfMeasurement = new CodeDescriptionType();
            unitOfMeasurement.Code = "KGS";
            unitOfMeasurement.Description = "Kilograms";
            shipmentWeight.UnitOfMeasurement = unitOfMeasurement;
            tntRequest.ShipmentWeight = shipmentWeight;

            tntRequest.TotalPackagesInShipment = "1";
            InvoiceLineTotalType invoiceLineTotal = new InvoiceLineTotalType();
            invoiceLineTotal.CurrencyCode = "CAD";
            invoiceLineTotal.MonetaryValue = "10";
            tntRequest.InvoiceLineTotal = invoiceLineTotal;
            tntRequest.MaximumListSize = "1";

            UPSSecurity upss = GetUPSSecurity();

            tntService.UPSSecurityValue = upss;
            var result = tntService.ProcessTimeInTransit(tntRequest);

            if (result.Response.ResponseStatus.Description == "Success")
            {
                if ((result.Item as TransitResponseType).ServiceSummary.Any())
                {
                    model.ServiceSummaries = new List<ServiceSummaryModel>();
                    foreach (var item in (result.Item as TransitResponseType).ServiceSummary.ToList())
                    {
                        var summary = new ServiceSummaryModel();
                        summary.Description = item.Service.Description;
                        summary.PickUpDate = DateTime.ParseExact(
                                item.EstimatedArrival.Pickup.Date + " " +
                                item.EstimatedArrival.Pickup.Time, "yyyyMMdd HHmmss", null)
                                    .ToString(CultureInfo.InvariantCulture);
                        summary.ArrivalDate = DateTime.ParseExact(
                                item.EstimatedArrival.Arrival.Date + " " +
                                item.EstimatedArrival.Arrival.Time, "yyyyMMdd HHmmss", null)
                                    .ToString(CultureInfo.InvariantCulture);
                        summary.Rate = "Not Available";
                        string arawArrival = DateTime.Parse(summary.ArrivalDate.ToString()).ToString("dddd");
                        if (arawArrival.ToLower() == "saturday")
                        {
                            summary.ArrivalDate += " (Saturday)";
                        }
                        try
                        {
                            if (
                                model.PackageType == "My Packaging"
                                || model.PackageType == "UPS Express Box"
                                || model.PackageType == "UPS PAK"
                                || model.PackageType == "UPS Tube"
                                || model.PackageType == "UPS Express Envelope")
                            {
                                using (var context = new Vital.Data.Models.VitalContext())
                                {
                                    var databaseType = GetDatabaseType(summary.Description);
                                    if (!string.IsNullOrEmpty(databaseType))
                                    {
                                        var postalCode =
                                            context.PostalCodes.FirstOrDefault(
                                                c =>
                                                (model.FromPostalCode.CompareTo(c.OriginPostalCodeMin) >= 0 && model.FromPostalCode.CompareTo(c.OriginPostalCodeMax) <= 0)
                                                &&
                                                (model.ToPostalCode.CompareTo(c.DestinationPostalCodeMin) >= 0 && model.ToPostalCode.CompareTo(c.DestinationPostalCodeMax) <= 0)
                                                );
                                        var shippingType = context.ShippingTypes.FirstOrDefault(
                                                c => c.Content == databaseType);
                                        var zone =
                                            context.PostalCodeZones.FirstOrDefault(
                                                c =>
                                                c.PostalCodeId == postalCode.Id &&
                                                c.ShippingTypeId == shippingType.Id);
                                        var inputWeight = model.Weight ?? 0;
                                        var dimensionWeight = (model.Length != null && model.Width != null && model.Height != null)
                                                                ? (decimal)((model.Length * model.Width * model.Height) / 139)
                                                                : 0;
                                        var actualWeight = inputWeight > dimensionWeight
                                                               ? inputWeight
                                                               : dimensionWeight;
                                        var weight =
                                            context.Weights.FirstOrDefault(
                                                c => actualWeight >= c.Low && actualWeight <= c.High);
                                        var account =
                                            context.CustomerAccounts.FirstOrDefault(
                                                c => c.Id == model.SelectedAccount);

                                        decimal rate = 0;

                                        if (model.PackageType == "UPS PAK")
                                        {
                                            var zoneRate = context.ZoneRates.FirstOrDefault(
                                                    c => c.ZoneId == zone.ZoneId && c.WeightId == weight.Id && c.RateYear == account.RateYear && c.Type == "PAK");
                                            rate = (decimal)zoneRate.Rate;
                                        }
                                        else if (model.PackageType == "UPS Express Envelope")
                                        {
                                            var zoneRate = context.ZoneRates.FirstOrDefault(
                                                    c => c.ZoneId == zone.ZoneId && c.WeightId == weight.Id && c.RateYear == account.RateYear && c.Type == "LTR");
                                            rate = (decimal)zoneRate.Rate;
                                        }
                                        else
                                        {
                                            var zoneRate = context.ZoneRates.FirstOrDefault(
                                                    c => c.ZoneId == zone.ZoneId && c.WeightId == weight.Id && c.RateYear == account.RateYear);

                                            if (actualWeight >= 151)
                                            {
                                                if (((decimal)zoneRate.Rate * actualWeight) > (decimal)zoneRate.Minimum)
                                                {
                                                    rate = ((decimal)zoneRate.Rate * actualWeight);
                                                }
                                                else
                                                {
                                                    rate = (decimal)zoneRate.Minimum;
                                                }
                                            }
                                            else
                                            {
                                                rate = (decimal)zoneRate.Rate;
                                            }
                                        }

                                        var discount = context.ZoneDiscountPercentages.FirstOrDefault(c => c.CustomerAccountId == account.Id && c.ZoneId == zone.ZoneId);
                                        if (discount != null)
                                        {
                                            if (model.PackageType == "UPS PAK")
                                            {
                                                rate = rate - (rate * (decimal)discount.PAKDiscountPercentage);
                                            }
                                            else if (model.PackageType == "UPS Express Envelope")
                                            {
                                                rate = rate - (rate * (decimal)discount.LTRDiscountPercentage);
                                            }
                                            else
                                            {
                                                rate = rate - (rate * (decimal)discount.Content);
                                            }
                                        }

                                        rate = rate * (decimal)(model.NumberOfPackages ?? 0);
                                        summary.Rate = rate.ToString("F");
                                    }
                                }
                            }
                        }
                        catch
                        {
                            summary.Rate = "Not Available";
                        }

                        model.ServiceSummaries.Add(summary);
                    }
                }
            }

            return model;

        }

        private static UPSSecurity GetUPSSecurity()
        {
            UPSSecurity upss = new UPSSecurity();
            UPSSecurityServiceAccessToken upsSvcToken = new UPSSecurityServiceAccessToken();
            upsSvcToken.AccessLicenseNumber = "8CA6E5A96EF68803";
            upss.ServiceAccessToken = upsSvcToken;
            UPSSecurityUsernameToken upsSecUsrnameToken = new UPSSecurityUsernameToken();
            upsSecUsrnameToken.Username = "cs.angai";
            upsSecUsrnameToken.Password = "Angai2012";
            upss.UsernameToken = upsSecUsrnameToken;

            System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
            return upss;
        }

        private class ShippingTypeMapping
        {
            public string UPSType { get; set; }

            public string DatabaseType { get; set; }
        }

        public static string GetDatabaseType(string type)
        {
            var shippingTypes = new List<ShippingTypeMapping>
            {
                new ShippingTypeMapping { UPSType = "UPS Express", DatabaseType = "DOM Early AM" },
                new ShippingTypeMapping { UPSType = "UPS Express Plus", DatabaseType = "DOM Express" },
                new ShippingTypeMapping { UPSType = "UPS Expedited", DatabaseType = "DOM Expedited" },
                new ShippingTypeMapping { UPSType = "UPS Next Day Air Early A.M.", DatabaseType = "Economy" },
                new ShippingTypeMapping { UPSType = "UPS Next Day Air", DatabaseType = "Economy" },
                new ShippingTypeMapping { UPSType = "UPS Worldwide Express Plus", DatabaseType = "XDM" },
                new ShippingTypeMapping { UPSType = "UPS Worldwide Express Plus", DatabaseType = "Import US Express" },
                new ShippingTypeMapping { UPSType = "UPS Worldwide Express Plus", DatabaseType = "Import WW Express" },
                new ShippingTypeMapping { UPSType = "UPS Worldwide Express", DatabaseType = "US Express" },
                new ShippingTypeMapping { UPSType = "UPS Worldwide Express", DatabaseType = "Import US Express" },
                new ShippingTypeMapping { UPSType = "UPS Worldwide Express", DatabaseType = "Import WW Express" },
                new ShippingTypeMapping { UPSType = "UPS Worldwide Express", DatabaseType = "WW Express" },
                new ShippingTypeMapping { UPSType = "UPS Express Saver", DatabaseType = "DOM Saver" },
                new ShippingTypeMapping { UPSType = "UPS Express Saver", DatabaseType = "US Saver" },
                new ShippingTypeMapping { UPSType = "UPS Express Saver", DatabaseType = "WW Saver" },
                new ShippingTypeMapping { UPSType = "UPS Express Saver", DatabaseType = "Import WW Saver" },
                new ShippingTypeMapping { UPSType = "UPS Worldwide Expedited", DatabaseType = "US Expedited" },
                new ShippingTypeMapping { UPSType = "UPS Worldwide Expedited", DatabaseType = "Import US Expedited" },
                new ShippingTypeMapping { UPSType = "UPS Worldwide Expedited", DatabaseType = "Import WW Expedited" },
                new ShippingTypeMapping { UPSType = "UPS Worldwide Expedited", DatabaseType = "WW Expedited" },
                new ShippingTypeMapping { UPSType = "UPS Standard", DatabaseType = "DOM Standard" },
                new ShippingTypeMapping { UPSType = "UPS Standard", DatabaseType = "US Ground" },
                new ShippingTypeMapping { UPSType = "UPS Standard", DatabaseType = "Import US Ground" },
                new ShippingTypeMapping { UPSType = "UPS 3 Day Select", DatabaseType = "US 3 Day" },
                new ShippingTypeMapping { UPSType = "UPS Worldwide Saver", DatabaseType = "Import US Saver" },
            };

            var databaseType = string.Empty;
            foreach (var shippingTypeMapping in shippingTypes)
            {
                if (shippingTypeMapping.UPSType == type)
                {
                    databaseType = shippingTypeMapping.DatabaseType;
                    break;
                }
            }
            return databaseType;
        }

    }
}
