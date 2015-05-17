using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vital.Model;

namespace UPS.Service
{
    using System.Threading;
    using UPS.Service.ShipService;
    public partial class ShippingService : UPS.Service.IShippingService
    {
        private const int NumberOfRetries = 3;
        private const int DelayOnRetry = 1000;

        public ShipmentModel ProcessShipment(ShipmentModel model)
        {
            model.IsSuccess = false;

            for (int i = 1; i <= NumberOfRetries; i++)
            {
                try
                {
                    UPS.Service.ShipService.ShipService shpSvc = new ShipService.ShipService();
                    ShipmentRequest shipmentRequest = new ShipmentRequest();
                    UPSSecurity upss = GetUPSSecurity("qvm.rhenson", "Vital@123");
                    shpSvc.UPSSecurityValue = upss;
                    RequestType request = new RequestType();
                    String[] requestOption = { "nonvalidate" };
                    request.RequestOption = requestOption;
                    shipmentRequest.Request = request;

                    ShipmentType shipment = new ShipmentType()
                    {
                        Description = "Ship Webservice",

                    };
                    //ShipmentRequest/Shipment/ShipmentServiceOptions/InternationalForms /CN22Form /CN22Content/CN22ContentWeight/UnitOfMeasurement

                    ShipperType shipper = new ShipperType() { 
                        ShipperNumber = "0596VE",
                        Name = "Vital Logistics Ltd."
                    };

                    PaymentInfoType paymentInfo = new PaymentInfoType();
                    ShipmentChargeType shpmentCharge = new ShipmentChargeType();
                    BillShipperType billShipper = new BillShipperType();
                    billShipper.AccountNumber = "0596VE"; //Shipper's Account 
                    shpmentCharge.BillShipper = billShipper;
                    shpmentCharge.Type = "01";
                    ShipmentChargeType[] shpmentChargeArray = { shpmentCharge };
                    paymentInfo.ShipmentCharge = shpmentChargeArray;
                    shipment.PaymentInformation = paymentInfo;
                    ShipAddressType shipperAddress = new ShipAddressType();
                    String[] addressLine = { model.ConsignorAddress1 };
                    
                    shipperAddress.AddressLine = addressLine;
                    shipperAddress.City = model.ConsignorCity;
                    shipperAddress.PostalCode = model.ConsignorPostalCode;
                    shipperAddress.StateProvinceCode = model.ConsignorProvince;
                    shipperAddress.CountryCode = model.ConsignorCountry;
                    shipperAddress.AddressLine = addressLine;
                    shipper.Address = shipperAddress;
                    shipper.Name = model.ConsignorCompanyName;
                    shipper.AttentionName = model.ConsignorContactName;
                    ShipPhoneType shipperPhone = new ShipPhoneType();
                    shipperPhone.Number = model.ConsignorTelephone;
                    shipper.Phone = shipperPhone;
                    shipment.Shipper = shipper;
                    ShipFromType shipFrom = new ShipFromType();

                    ShipAddressType shipFromAddress = new ShipAddressType();
                    String[] shipFromAddressLine = { model.ConsignorAddress1 };
                    shipFromAddress.AddressLine = addressLine;
                    shipFromAddress.City = model.ConsignorCity;
                    shipFromAddress.PostalCode = model.ConsignorPostalCode;
                    shipFromAddress.StateProvinceCode = model.ConsignorProvince;
                    shipFromAddress.CountryCode = model.ConsignorCountry;
                    shipFrom.Address = shipFromAddress;
                    shipFrom.AttentionName = model.ConsignorContactName;
                    shipFrom.Name = model.ConsignorCompanyName;
                    shipment.ShipFrom = shipFrom;
                    ShipToType shipTo = new ShipToType();
                    ShipToAddressType shipToAddress = new ShipToAddressType();
                    String[] addressLine1 = { model.ConsigneeAddress1 };
                    shipToAddress.AddressLine = addressLine1;
                    shipToAddress.City = model.ConsigneeCity;
                    shipToAddress.PostalCode = model.ConsigneePostalCode;
                    shipToAddress.StateProvinceCode = model.ConsigneeProvince;
                    shipToAddress.CountryCode = model.ConsigneeCountry;
                    shipTo.Address = shipToAddress;
                    shipTo.AttentionName = model.ConsigneeCompanyName;
                    shipTo.Name = model.ConsigneeContactName ?? model.ConsigneeCompanyName;
                    ShipPhoneType shipToPhone = new ShipPhoneType();
                    shipToPhone.Number = model.ConsigneeTelephone;
                    shipTo.Phone = shipToPhone;
                    shipment.ShipTo = shipTo;
                    ServiceType service = new ServiceType()
                    {
                        Code = model.ServiceType,
                    };

                    shipment.Service = service;

                    PackageType package = new PackageType()
                    {
                        PackageWeight = new PackageWeightType()
                        {
                            Weight = model.Weight,
                            UnitOfMeasurement = new ShipUnitOfMeasurementType()
                            {
                                Code = (model.UnitOfMeasurement == "2" ? "KGS" : "LBS")
                            }
                        },
                        Packaging = new PackagingType()
                        {
                            Code = model.PackagingType
                        },
                        ReferenceNumber = new ReferenceNumberType[] { }
                    };

                    //Package dimensions measurement code.
                    //Codes are:
                    //  IN = Inches,
                    //  CM = Centimeters,
                    //  00 = Metric Units Of Measurement,
                    //  01 = English Units of Measurement.
                    if (model.PackagingType != "-99")
                    {
                        switch (PackagingTypeEnumExtension.GetEnumByValue(model.PackagingType))
                        {
                            case PackagingTypeEnum.Tube:
                            case PackagingTypeEnum.ExpressBox:
                            case PackagingTypeEnum.OtherPackaging:
                                package.Dimensions = new DimensionsType()
                                {
                                    Width = model.PackageDimensionsWidth,
                                    Height = model.PackageDimensionsHeight,
                                    Length = model.PackageDimensionsLength,
                                    UnitOfMeasurement = new ShipUnitOfMeasurementType()
                                    {
                                        Code = (model.UnitOfMeasurement == "2" ? "CM" : "IN")
                                    }
                                };
                                break;
                            default:
                                break;
                        }
                    }

                    if (!string.IsNullOrEmpty(model.PackageDeclaredValueCAD))
                    {
                        package.PackageServiceOptions = new PackageServiceOptionsType()
                        {
                            DeclaredValue = new PackageDeclaredValueType()
                            {
                                CurrencyCode = "CAD",
                                MonetaryValue = model.PackageDeclaredValueCAD,
                                Type = new DeclaredValueType() { Code = "01", Description = "EVS" }
                            }
                        };
                    }

                    PackageType[] pkgArray = { package };
                    shipment.Package = pkgArray;

                    List<ReferenceNumberType> refNums = new List<ReferenceNumberType>();

                    if (!string.IsNullOrEmpty(model.ReferenceNumber1))
                        refNums.Add(new ReferenceNumberType() { Value = model.ReferenceNumber1 });
                    if (!string.IsNullOrEmpty(model.ReferenceNumber2))
                        refNums.Add(new ReferenceNumberType() { Value = model.ReferenceNumber2 });
                    if (!string.IsNullOrEmpty(model.ReferenceNumber3))
                        refNums.Add(new ReferenceNumberType() { Value = model.ReferenceNumber3 });

                    if (refNums.Any())
                    {
                        shipment.ReferenceNumber = refNums.ToArray();
                    }

                    LabelSpecificationType labelSpec = new LabelSpecificationType();
                    LabelStockSizeType labelStockSize = new LabelStockSizeType();
                    labelStockSize.Height = "6";
                    labelStockSize.Width = "4";
                    labelSpec.LabelStockSize = labelStockSize;
                    LabelImageFormatType labelImageFormat = new LabelImageFormatType();
                    labelImageFormat.Code = "SPL";
                    labelSpec.LabelImageFormat = labelImageFormat;
                    shipmentRequest.LabelSpecification = labelSpec;
                    shipmentRequest.Shipment = shipment;
                    //Console.WriteLine(shipmentRequest);
                    System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
                    ShipmentResponse shipmentResponse = shpSvc.ProcessShipment(shipmentRequest);

                    model.Result = "The transaction was a " + shipmentResponse.Response.ResponseStatus.Description;
                    model.Result += Environment.NewLine + "The 1Z number of the new shipment is " + shipmentResponse.ShipmentResults.ShipmentIdentificationNumber + ".";

                    model.IsSuccess = true;
                    model.ResultMessage = "Success";
                    model.ShipmentIdentificationNumber = shipmentResponse.ShipmentResults.ShipmentIdentificationNumber;
                    return model;
                }
                catch (System.Web.Services.Protocols.SoapException ex)
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("");
                    sb.AppendLine("---------Ship Web Service returns error----------------");
                    sb.AppendLine("---------\"Hard\" is user error \"Transient\" is system error----------------");
                    sb.AppendLine("SoapException Message= " + ex.Message);
                    sb.AppendLine("");
                    sb.AppendLine("SoapException Category:Code:Message= " + ex.Detail.LastChild.InnerText);
                    sb.AppendLine("");
                    sb.AppendLine("SoapException XML String for all= " + ex.Detail.LastChild.OuterXml);
                    sb.AppendLine("");
                    sb.AppendLine("SoapException StackTrace= " + ex.StackTrace);
                    sb.AppendLine("-------------------------");
                    sb.AppendLine("");
                    model.Result = sb.ToString();
                    model.ResultMessage = ex.Message; //ex.Detail.LastChild.InnerText;
                }
                catch (System.ServiceModel.CommunicationException ex)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("");
                    sb.AppendLine("--------------------");
                    sb.AppendLine("CommunicationException= " + ex.Message);
                    sb.AppendLine("CommunicationException-StackTrace= " + ex.StackTrace);
                    sb.AppendLine("-------------------------");
                    sb.AppendLine("");
                    model.Result = sb.ToString();
                    model.ResultMessage = ex.StackTrace;
                }
                catch (Exception ex)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("");
                    sb.AppendLine("-------------------------");
                    sb.AppendLine(" General Exception= " + ex.Message);
                    sb.AppendLine(" General Exception-StackTrace= " + ex.StackTrace);
                    sb.AppendLine("-------------------------");
                    model.Result = sb.ToString();
                    model.ResultMessage = ex.StackTrace;
                }

                Thread.Sleep(DelayOnRetry);
                
            }

            return model;

        }

        private static UPSSecurity GetUPSSecurity(string username, string password)
        {
            UPSSecurity upss = new UPSSecurity();
            UPSSecurityServiceAccessToken upssSvcAccessToken = new UPSSecurityServiceAccessToken();
            upssSvcAccessToken.AccessLicenseNumber = "8CA6E5A96EF68803";
            upss.ServiceAccessToken = upssSvcAccessToken;
            UPSSecurityUsernameToken upssUsrNameToken = new UPSSecurityUsernameToken();
            upssUsrNameToken.Username = username;
            upssUsrNameToken.Password = password;
            upss.UsernameToken = upssUsrNameToken;
            return upss;
        }
    }
}

namespace UPS.Service
{
    using UPS.Service.VoidService;
    public partial class ShippingService : UPS.Service.IShippingService
    {
        public void Void(string shipmentIdentificationNumber, string username, string password, out string message)
        {
            try
            {
                VoidService.VoidService voidService = new VoidService.VoidService();
                VoidShipmentRequest voidRequest = new VoidShipmentRequest();
                RequestType request = new RequestType();
                String[] requestOption = { "1" };
                request.RequestOption = requestOption;
                voidRequest.Request = request;
                VoidShipmentRequestVoidShipment voidShipment = new VoidShipmentRequestVoidShipment();
                voidShipment.ShipmentIdentificationNumber = "1Z2220060290602143";
                voidRequest.VoidShipment = voidShipment;

                voidService.UPSSecurityValue = GetUPSSecurityVoid(username, password);

                System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
                Console.WriteLine(voidRequest);
                VoidShipmentResponse voidResponse = voidService.ProcessVoid(voidRequest);
                Console.WriteLine("The transaction was a " + voidResponse.Response.ResponseStatus.Description);
                Console.WriteLine("The shipment has been   : " + voidResponse.SummaryResult.Status.Description);
                message = "The shipment has been   : " + voidResponse.SummaryResult.Status.Description;
            }
            catch (System.Web.Services.Protocols.SoapException ex)
            {
                Console.WriteLine("");
                Console.WriteLine("---------Void Web Service returns error----------------");
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
                throw ex;
            }
            catch (System.ServiceModel.CommunicationException ex)
            {
                Console.WriteLine("");
                Console.WriteLine("--------------------");
                Console.WriteLine("CommunicationException= " + ex.Message);
                Console.WriteLine("CommunicationException-StackTrace= " + ex.StackTrace);
                Console.WriteLine("-------------------------");
                Console.WriteLine("");
                throw ex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("");
                Console.WriteLine("-------------------------");
                Console.WriteLine(" Generaal Exception= " + ex.Message);
                Console.WriteLine(" Generaal Exception-StackTrace= " + ex.StackTrace);
                Console.WriteLine("-------------------------");
                throw ex;
            }
        }

        private static UPSSecurity GetUPSSecurityVoid(string username, string password)
        {
            UPSSecurity upss = new UPSSecurity();

            UPSSecurityServiceAccessToken upssSvcAccessToken = new UPSSecurityServiceAccessToken();
            upssSvcAccessToken.AccessLicenseNumber = "8CA6E5A96EF68803";
            upss.ServiceAccessToken = upssSvcAccessToken;

            UPSSecurityUsernameToken upssUsrNameToken = new UPSSecurityUsernameToken();
            upssUsrNameToken.Username = username;
            upssUsrNameToken.Password = password;
            upss.UsernameToken = upssUsrNameToken;

            return upss;
        }
    }
}