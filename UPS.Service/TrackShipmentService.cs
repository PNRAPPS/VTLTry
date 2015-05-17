using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vital.Model;
using UPS.Service.TrackService;

namespace UPS.Service
{
    public class TrackShipmentService : UPS.Service.ITrackShipmentService
    {



        public TrackShipmentService()
        {

        }

        public List<TrackingResultModel> Search(string trackingNumbers)
        {
            trackingNumbers = trackingNumbers.Trim();
            var trackingNumberList = trackingNumbers.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            var results = new List<TrackingResultModel>();
            foreach (var trackingNumber in trackingNumberList)
            {
                var result = new TrackingResultModel();
                try
                {
                    UPS.Service.TrackService.TrackService track = new TrackService.TrackService();
                    TrackRequest tr = new TrackRequest();
                    UPSSecurity upss = GetUPSAuthentication();
                    track.UPSSecurityValue = upss;
                    RequestType requestType = new RequestType();
                    String[] requestOption = { "15" };
                    requestType.RequestOption = requestOption;
                    tr.Request = requestType;
                    tr.InquiryNumber = "1Z12345E0390515214";
                    System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
                    TrackResponse trackResponse = track.ProcessTrack(tr);
                    result.TrackingNumber = trackingNumber;
                    result.Description = trackResponse.Shipment[0].Service.Description;
                    result.Status = DeliveryStatus(trackResponse.Shipment[0].Package[0].Activity[0].Status.Type);
                    results.Add(result);

                }
                catch (System.Web.Services.Protocols.SoapException ex)
                {
                    result.TrackingNumber = trackingNumber;
                    result.Status = "No tracking information available";//ex.Detail.LastChild.InnerText;
                    results.Add(result);
                }

            }
            return results;
        }

        public TrackingResultModel SearchInquiry(string trackingNumbers)
        {
            trackingNumbers = trackingNumbers.Trim();
            var result = new TrackingResultModel();
                
                try
                {
                    UPS.Service.TrackService.TrackService track = new TrackService.TrackService();
                    TrackRequest tr = new TrackRequest();
                    UPSSecurity upss = GetUPSAuthentication();
                    track.UPSSecurityValue = upss;
                    RequestType requestType = new RequestType();
                    String[] requestOption = { "15" };
                    requestType.RequestOption = requestOption;
                    tr.Request = requestType;
                    tr.InquiryNumber = trackingNumbers;
                    System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
                    TrackResponse trackResponse = track.ProcessTrack(tr);
                    result.TrackingNumber = trackingNumbers;
                    result.Description = trackResponse.Shipment[0].Service.Description;
                    result.Status = DeliveryStatus(trackResponse.Shipment[0].Package[0].Activity[0].Status.Type);
                    
                }
                catch (System.Web.Services.Protocols.SoapException ex)
                {
                    result.TrackingNumber = trackingNumbers;
                    result.Status = "No tracking information available";//ex.Detail.LastChild.InnerText;
                    
                }

            
            return result;
        }

        public List<TrackingModel> GetInformation(string trackingNumbers)
        {
            try
            {
                trackingNumbers = trackingNumbers.Trim();
                var trackingNumberList = trackingNumbers.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                var tracked = new List<TrackingModel>() { };
                foreach (var trackingNumber in trackingNumberList)
                {
                    var data = new TrackingModel();
                    try
                    {
                        UPS.Service.TrackService.TrackService track = new TrackService.TrackService();
                        TrackRequest tr = new TrackRequest();
                        UPSSecurity upss = GetUPSAuthentication();
                        track.UPSSecurityValue = upss;
                        RequestType request = new RequestType();
                        String[] requestOption = { "7" };
                        request.RequestOption = requestOption;
                        tr.Request = request;

                        tr.InquiryNumber = trackingNumber;
                        System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
                        TrackResponse trackResponse = track.ProcessTrack(tr);
                        data.TrackingNumber = trackingNumber;
                        data.Description = trackResponse.Shipment[0].Service.Description;
                        data.Status = DeliveryStatus(trackResponse.Shipment[0].Package[0].Activity[0].Status.Type);

                        //Additional fields

                        if (trackResponse.Shipment[0].ShipmentAddress != null)
                        {
                            data.ShipperNumber = trackResponse.Shipment[0].ShipperNumber;
                            int addressCount = trackResponse.Shipment[0].ShipmentAddress.Count();
                            string Address = string.Concat(
                                                    trackResponse.Shipment[0].ShipmentAddress[addressCount - 1].Address.City, ", ",
                                                    trackResponse.Shipment[0].ShipmentAddress[addressCount - 1].Address.CountryCode);
                            data.DeliveredTo = Address;
                        }

                        if (trackResponse.Shipment[0].Manifest != null)
                        {
                            data.ManifestDate = DateTime.ParseExact(trackResponse.Shipment[0].Manifest.Date, "yyyyMMdd", null).ToString("MMMM dd, yyyy");
                        }

                        string signedBy = "no details";
                        if (trackResponse.Shipment[0].Package[0].Activity[0].ActivityLocation.SignedForByName != null)
                        {
                            signedBy = trackResponse.Shipment[0].Package[0].Activity[0].ActivityLocation.SignedForByName;
                        }
                        data.SignedBy = signedBy;

                        //result.ReferenceNumber = trackResponse.Shipment[0].Package[0].ReferenceNumber[0].Code;

                        string billDate = "No dates loaded";
                        if (trackResponse.Shipment[0].PickupDate != null)
                        {
                            billDate = DateTime.ParseExact(trackResponse.Shipment[0].PickupDate, "yyyyMMdd", null).ToString("MM/dd/yyyy");
                        }
                        data.BillingDate = billDate; //shows error
                        data.PackageType = "Package"; //On further exploration

                        /*result.ActivityName = trackResponse.Shipment[0].Package[0].Activity[0].Status.Description;
                        //result.ActivityTime = trackResponse.Shipment[0].Package[0].Activity[0].Time; */

                        data.ActivityTime = DateTime.ParseExact(trackResponse.Shipment[0].Package[0].Activity[0].Time, "HHmmss", null).ToString("h:mm tt");
                        data.ActivityDate = DateTime.ParseExact(trackResponse.Shipment[0].Package[0].Activity[0].Date, "yyyyMMdd", null).ToString("MMMM dd, yyyy");
                        data.DeliveryDate = DateTime.ParseExact(data.ActivityDate, "MMMM dd, yyyy", null).ToString("dddd") + ", " + DateTime.ParseExact(data.ActivityDate, "MMMM dd, yyyy", null).ToString("MM/dd/yyyy") + " at " + data.ActivityTime;

                        string Location = string.Concat(
                                                trackResponse.Shipment[0].Package[0].Activity[0].ActivityLocation.Address.City, " ",
                                                trackResponse.Shipment[0].Package[0].Activity[0].ActivityLocation.Address.StateProvinceCode, " ",
                                                trackResponse.Shipment[0].Package[0].Activity[0].ActivityLocation.Address.PostalCode, " ",
                                                trackResponse.Shipment[0].Package[0].Activity[0].ActivityLocation.Address.CountryCode);

                        data.ActivityLocation = Location;

                        //List for Shipment Progress
                        foreach (var item in trackResponse.Shipment[0].Package[0].Activity.ToList())
                        {
                            if (item.ActivityLocation == null)
                                continue;

                            var prog = new ShipmentProgress();
                            if (item.ActivityLocation.Address.City == null && item.ActivityLocation.Address.StateProvinceCode != null)
                            {
                                prog.Location = item.ActivityLocation.Address.StateProvinceCode + ", " + item.ActivityLocation.Address.CountryCode;
                            }
                            else if (item.ActivityLocation.Address.StateProvinceCode == null)
                            {
                                prog.Location = item.ActivityLocation.Address.CountryCode;
                            }
                            else
                            {
                                prog.Location = item.ActivityLocation.Address.City + ", " + item.ActivityLocation.Address.StateProvinceCode + ", " + item.ActivityLocation.Address.CountryCode;
                            }

                            prog.Date = DateTime.ParseExact(item.Date, "yyyyMMdd", null).ToString("MM/dd/yyyy");
                            prog.LocalTime = DateTime.ParseExact(item.Time, "HHmmss", null).ToString("h:mm tt");
                            prog.Activity = item.Status.Description;
                            data.ShipmentProgress.Add(prog);
                        }

                        //List for Shipment Packages

                        if (trackResponse.Shipment[0].Package.ToList().Count > 1)
                        {
                            data.PackageCount = trackResponse.Shipment[0].Package.Count();
                        }
                        else
                        {
                            data.PackageCount = 0;
                        }

                        if (data.PackageCount > 1)
                        {
                            foreach (var item in trackResponse.Shipment[0].Package.ToList())
                            {
                                var package = new ShipmentPackages();
                                package.TrackingNumber = item.TrackingNumber;
                                if (item.ReferenceNumber != null)
                                {
                                    package.Reference = item.ReferenceNumber[0].Value;
                                }
                                else { package.Reference = ""; }

                                package.Status = DeliveryStatus(item.Activity[0].Status.Type);
                                package.ShippedDate = data.BillingDate;

                                package.ScheduledDate = DateTime.ParseExact(item.Activity[0].Date, "yyyyMMdd", null).ToString("MM/dd/yyyy");

                                package.Weight = item.PackageWeight.Weight + " LBS";
                                //package.Service = result.Description;
                                data.Weight = package.Weight;
                                data.ShipmentPackage.Add(package);
                            }
                        }

                        tracked.Add(data);
                    }
                    catch (System.Web.Services.Protocols.SoapException ex)
                    {
                        data.TrackingNumber = trackingNumber;
                        data.Status = ex.Detail.LastChild.InnerText;
                        tracked.Add(data);
                    }
                }
                return tracked;
            }
            catch
            {
                throw;
            }
        }


        #region Common

        private static UPSSecurity GetUPSAuthentication()
        {
            UPSSecurity upss = new UPSSecurity();
            UPSSecurityServiceAccessToken upssSvcAccessToken = new UPSSecurityServiceAccessToken();
            upssSvcAccessToken.AccessLicenseNumber = "8CA6E5A96EF68803";
            upss.ServiceAccessToken = upssSvcAccessToken;

            UPSSecurityUsernameToken upssUsrNameToken = new UPSSecurityUsernameToken();
            upssUsrNameToken.Username = "cs.angai";
            upssUsrNameToken.Password = "Angai2012";
            upss.UsernameToken = upssUsrNameToken;
            return upss;
        }

        private static string DeliveryStatus(string StatusType)
        {
            switch (StatusType.Trim())
            {
                case "D":
                    return "Delivered";
                case "I":
                    return "In Transit";
                case "P":
                    return "Pickup";
                case "M":
                    return "Billing Information Received";
                case "MV":
                    return "Billing Information Voided";
                case "RS":
                    return "Returned to Shipper";
                case "X":
                    return "Exception";
                default:
                    break;
            }
            return string.Empty;
        }

        #endregion

    }
}
