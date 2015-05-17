using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vital.Model;

namespace UPS.Service
{
    using UPS.Service.PickupService;

    public partial class ShipmentPickupService : UPS.Service.IPickupService
    {

        public ShipmentModel SchedulePickup(Vital.Model.ShipmentModel model)
        {
            try
            {
                PickupService.PickupService pickupService = new PickupService.PickupService();

                PickupCreationRequest pickupCreationRequest = new PickupCreationRequest();
                RequestType request = new RequestType();
                String[] requestOption = { " " };
                request.RequestOption = requestOption;
                pickupCreationRequest.Request = request;
                pickupCreationRequest.RatePickupIndicator = "N";

                ShipperType shipper = new ShipperType();
                AccountType account = new AccountType();
                account.AccountCountryCode = "US";
                account.AccountNumber = "0596VE";
                shipper.Account = account;
                pickupCreationRequest.Shipper = shipper;

                PickupDateInfoType pickupDateInfo = new PickupDateInfoType();
                pickupDateInfo.CloseTime = model.latestPickupTimeHour + model.latestPickupTimeMinute;
                pickupDateInfo.PickupDate = model.collectionDate;
                pickupDateInfo.ReadyTime = model.earliestPickupTimeHour + model.earliestPickupTimeMinute;
                pickupCreationRequest.PickupDateInfo = pickupDateInfo;

                PickupAddressType pickupAddress = new PickupAddressType();
                String[] addressLine = { model.ConsignorAddress1 };
                pickupAddress.AddressLine = addressLine;
                pickupAddress.City = model.ConsignorCity;
                pickupAddress.CompanyName = model.ConsignorCompanyName;
                pickupAddress.ContactName = model.contactName;
                pickupAddress.CountryCode = model.ConsignorCountry;
                pickupAddress.Floor = model.floor;
                pickupAddress.StateProvince = model.ConsignorProvince;

                PhoneType phoneType = new PhoneType();
                phoneType.Extension = model.extension;
                phoneType.Number = model.telephone;
                pickupAddress.Phone = phoneType;
                pickupAddress.PostalCode = model.ConsignorPostalCode;
                pickupAddress.PickupPoint = model.pickupLocation;
                pickupAddress.ResidentialIndicator = model.IsResidential ? "Y" : "N";

                pickupCreationRequest.PickupAddress = pickupAddress;
                pickupCreationRequest.AlternateAddressIndicator = "N";

                PickupPieceType[] pickupPiece = new PickupPieceType[1];
                PickupPieceType pickupType = new PickupPieceType();
                pickupType.ContainerCode = "01";
                pickupType.DestinationCountryCode = "US";
                pickupType.Quantity = "27";
                pickupType.ServiceCode = "002";
                pickupPiece[0] = pickupType;
                pickupCreationRequest.PickupPiece = pickupPiece;

                WeightType totalWeight = new WeightType();
                totalWeight.UnitOfMeasurement = model.UnitOfMeasurement == "2" ? "KGS" : "LBS";
                totalWeight.Weight = model.Weight;

                pickupCreationRequest.TotalWeight = totalWeight;
                pickupCreationRequest.OverweightIndicator = "N";

                //String[] returnTrackingNumber = { "Your return tracking number 1", "Your return tracking number 2", "Your return tracking number 3" };
                //String[] returnTrackingNumber = { "1Z12345E8791315413" };
                //pickupCreationRequest.ReturnTrackingNumber = returnTrackingNumber;

                pickupCreationRequest.PaymentMethod = "01";
                pickupCreationRequest.SpecialInstruction = ".Net Sample code for Pickup Client";

                UPSSecurity upss = new UPSSecurity();
                UPSSecurityServiceAccessToken upssSvcAccessToken = new UPSSecurityServiceAccessToken();
                upssSvcAccessToken.AccessLicenseNumber = "5CB665A949CE652A";
                upss.ServiceAccessToken = upssSvcAccessToken;
                UPSSecurityUsernameToken upssUsrNameToken = new UPSSecurityUsernameToken();
                upssUsrNameToken.Username = "qvm.rhenson";
                upssUsrNameToken.Password = "Vital@123";
                upss.UsernameToken = upssUsrNameToken;
                pickupService.UPSSecurityValue = upss;

                System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
                Console.WriteLine(pickupCreationRequest);
                PickupCreationResponse pickupCreationResponse = pickupService.ProcessPickupCreation(pickupCreationRequest);
                
                model.pickupIdentificationNumber = pickupCreationResponse.PRN;
                model.Result += Environment.NewLine + "The Pickup Request Confirmation Number is  : " + pickupCreationResponse.PRN + ". ";
                
                Console.WriteLine("The transaction was a " + pickupCreationResponse.Response.ResponseStatus.Description);
            }
            catch (System.Web.Services.Protocols.SoapException ex)
            {
                Console.WriteLine("");
                Console.WriteLine("---------Pickup Web Service returns error----------------");
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
                Console.WriteLine(" General Exception= " + ex.Message);
                Console.WriteLine(" General Exception-StackTrace= " + ex.StackTrace);
                Console.WriteLine("-------------------------");

            }

            return model;
        }
    }
}
