using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPS.Service.RateWebService;
using Vital.Model;

namespace UPS.Service
{
    public class RateService : IRateService
    {
        public RateResponse GetRate(ShipmentModel model)
        {
            return GetRate(model, model.ServiceType);
        }

        public RateResponse GetRate(ShipmentModel model, string ServiceCode)
        {
            
            try
            {

                UPS.Service.RateWebService.RateService rate = new UPS.Service.RateWebService.RateService();
                RateRequest rateRequest = new RateRequest();
                UPSSecurity upss = new UPSSecurity();
                UPSSecurityServiceAccessToken upssSvcAccessToken = new UPSSecurityServiceAccessToken();
                upssSvcAccessToken.AccessLicenseNumber = "8CA6E5A96EF68803";
                upss.ServiceAccessToken = upssSvcAccessToken;
                UPSSecurityUsernameToken upssUsrNameToken = new UPSSecurityUsernameToken();
                upssUsrNameToken.Username = "qvm.rhenson";
                upssUsrNameToken.Password = "Vital@123";
                upss.UsernameToken = upssUsrNameToken;
                rate.UPSSecurityValue = upss;
                RequestType request = new RequestType();
                String[] requestOption = { "Rate" };
                request.RequestOption = requestOption;
                rateRequest.Request = request;
                ShipmentType shipment = new ShipmentType();
                ShipperType shipper = new ShipperType();
                shipper.ShipperNumber = model.ShipperNumber;
                UPS.Service.RateWebService.AddressType shipperAddress = new UPS.Service.RateWebService.AddressType();
                String[] addressLine = { "5555 main", "4 Case Cour", "Apt 3B" };
                shipperAddress.AddressLine = addressLine;
                shipperAddress.City = model.ConsignorCity;
                shipperAddress.PostalCode = model.ConsignorPostalCode;
                shipperAddress.StateProvinceCode = model.ConsignorProvince;
                shipperAddress.CountryCode = model.ConsignorCountry;
                shipperAddress.AddressLine = addressLine;
                shipper.Address = shipperAddress;
                shipment.Shipper = shipper;
                ShipFromType shipFrom = new ShipFromType();
                UPS.Service.RateWebService.AddressType shipFromAddress = new UPS.Service.RateWebService.AddressType();
                shipFromAddress.AddressLine = addressLine;
                shipFromAddress.City = model.ConsignorCity;
                shipFromAddress.PostalCode = model.ConsignorPostalCode;
                shipFromAddress.StateProvinceCode = model.ConsignorProvince;
                shipFromAddress.CountryCode = model.ConsignorCountry;
                shipFrom.Address = shipFromAddress;
                shipment.ShipFrom = shipFrom;
                ShipToType shipTo = new ShipToType();
                ShipToAddressType shipToAddress = new ShipToAddressType();
                String[] addressLine1 = { "10 E. Ritchie Way", "2", "Apt 3B" };
                shipToAddress.AddressLine = addressLine1;
                shipToAddress.City = model.ConsigneeCity;
                shipToAddress.PostalCode = model.ConsigneePostalCode;
                shipToAddress.StateProvinceCode = model.ConsigneeProvince;
                shipToAddress.CountryCode = model.ConsigneeCountry;
                shipTo.Address = shipToAddress;
                shipment.ShipTo = shipTo;
                CodeDescriptionType service = new CodeDescriptionType();

                //Below code uses dummy date for reference. Please udpate as required.
                service.Code = ServiceCode;
                shipment.Service = service;
                PackageType package = new PackageType();
                PackageWeightType packageWeight = new PackageWeightType();
                packageWeight.Weight = model.Weight;
                CodeDescriptionType uom = new CodeDescriptionType();
                uom.Code = model.UnitOfMeasurement.Equals("1") ? "LBS" : "KGS";

                switch (uom.Code.ToLower())
                {
                    case "lbs":
                        uom.Description = "Pounds";
                        break;
                    default:
                        uom.Description = "Kilograms";
                        break;
                }

                packageWeight.UnitOfMeasurement = uom;
                package.PackageWeight = packageWeight;
                CodeDescriptionType packType = new CodeDescriptionType();
                packType.Code = model.PackagingType;
                package.PackagingType = packType;
                PackageType[] pkgArray = { package };
                shipment.Package = pkgArray;
                rateRequest.Shipment = shipment;
                System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
                Console.WriteLine(rateRequest);
                RateResponse rateResponse = rate.ProcessRate(rateRequest);
                Console.WriteLine("The transaction was a " + rateResponse.Response.ResponseStatus.Description);
                return rateResponse;
            }
            catch (System.Web.Services.Protocols.SoapException ex)
            {
                Console.WriteLine("");
                Console.WriteLine("---------Rate Web Service returns error----------------");
                Console.WriteLine("---------\"Hard\" is user error \"Transient\" is system error----------------");
                Console.WriteLine("SoapException Message= " + ex.Message);
                Console.WriteLine("");
                Console.WriteLine("SoapException Category:Code:Message= " + ex.Detail.LastChild.InnerText);
                Console.WriteLine("");
                Console.WriteLine("SoapException XML String for all= " + ex.Detail.LastChild.OuterXml);
                Console.WriteLine("");
                Console.WriteLine("SoapException StackTrace= " + ex.StackTrace);
                Console.WriteLine("-------------------------");
                Console.WriteLine("");
            }
            catch (System.ServiceModel.CommunicationException ex)
            {
                Console.WriteLine("");
                Console.WriteLine("--------------------");
                Console.WriteLine("CommunicationException= " + ex.Message);
                Console.WriteLine("CommunicationException-StackTrace= " + ex.StackTrace);
                Console.WriteLine("-------------------------");
                Console.WriteLine("");

            }
            catch (Exception ex)
            {
                Console.WriteLine("");
                Console.WriteLine("-------------------------");
                Console.WriteLine(" Generaal Exception= " + ex.Message);
                Console.WriteLine(" Generaal Exception-StackTrace= " + ex.StackTrace);
                Console.WriteLine("-------------------------");

            }
            finally
            {
            }

            return null;
        }
    }
}
