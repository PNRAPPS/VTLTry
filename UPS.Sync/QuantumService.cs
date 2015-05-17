using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Vital.Model;

namespace UPS.Sync
{
    public class QuantumService
    {

        private static IQueryable<QVSubscriptionFile> GetSubscriptionFileEntities()
        {
            var db = new VITALDB_TESTEntities();
            return db.QVSubscriptionFiles;
        }

        private static IQueryable<QVSyncSummary> GetSyncSummaryEntities()
        {
            var db = new VITALDB_TESTEntities();
            return db.QVSyncSummaries;
        }

        private static IQueryable<QVShipmentDetail> GetShipmentDetailEntities()
        {
            var db = new VITALDB_TESTEntities();
            return db.QVShipmentDetails;
        }

        public static QuantumViewResponse GetQuantumData(string subscriptionName)
        {
            WebRequest req = null;
            WebResponse rsp = null;
            try
            {
                string uri = "https://onlinetools.ups.com/ups.app/xml/QVEvents";
                req = WebRequest.Create(uri);
                //req.Proxy = WebProxy.GetDefaultProxy(); // Enable if using proxy
                req.Credentials = new NetworkCredential("myusername", "mypassword");
                req.Method = "POST";        // Post method
                req.ContentType = "text/xml";     // content type
                StreamWriter writer = new StreamWriter(req.GetRequestStream());
                // Write the XML text into the stream

                AccessRequestModel arModel = new AccessRequestModel();
                arModel.AccessLicenseNumber = "8CA6E5A96EF68803";
                arModel.UserId = "qvm.rhenson3";
                arModel.Password = "Ah7pH987";

                MemoryStream arStream = new MemoryStream();
                XmlSerializer arSerializer = new XmlSerializer(arModel.GetType());
                arSerializer.Serialize(arStream, arModel);

                string arString = new string(Encoding.UTF8.GetChars(arStream.GetBuffer()));

                QuantumViewRequestModel qvModel = new QuantumViewRequestModel();
                qvModel.Request.RequestAction = "QVEvents";
                qvModel.SubscriptionRequest.Name = subscriptionName;
                qvModel.SubscriptionRequest.DateTimeRange.BeginDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(-6).ToString("yyyyMMdd") + "010000";
                qvModel.SubscriptionRequest.DateTimeRange.EndDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(-1).ToString("yyyyMMdd") + "010000";

                MemoryStream qvStream = new MemoryStream();
                XmlSerializer qvSerializer = new XmlSerializer(qvModel.GetType());
                qvSerializer.Serialize(qvStream, qvModel);

                string qvString = new string(Encoding.UTF8.GetChars(qvStream.GetBuffer()));

                string requestString = arString + qvString;

                writer.WriteLine(requestString);
                writer.Close();

                rsp = req.GetResponse(); //I am getting error over here
                StreamReader sr = new StreamReader(rsp.GetResponseStream());

                XmlSerializer serializer = new XmlSerializer(typeof(QuantumViewResponse));
                QuantumViewResponse model = (QuantumViewResponse)serializer.Deserialize(sr);

                Console.WriteLine("{0}: {1}", DateTime.Now.ToString(), "Saving Data...");
                var db = new VITALDB_TESTEntities();
                QVSyncSummary SyncModel = new QVSyncSummary()
                {
                    CreatedBy = "SyncJob",
                    CreatedDate = DateTime.Now,
                    QVEventName = subscriptionName,
                    QVSyncDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()).AddHours(DateTime.Now.Hour),
                    QVSyncStatusCode = model.Response.Error != null ? model.Response.Error.ErrorCode : model.Response.ResponseStatusCode,
                    QVSyncStatusDescription = model.Response.Error != null ? model.Response.Error.ErrorDescription : model.Response.ResponseStatusDescription
                };

                db.QVSyncSummaries.Add(SyncModel);
                db.SaveChanges();

                SaveSubscriptionData(model, SyncModel.QVSyncId, subscriptionName);

                sr.Close();

                return model;

            }
            catch (WebException webEx)
            {
                Console.WriteLine(webEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (req != null) req.GetRequestStream().Close();
                if (rsp != null) rsp.GetResponseStream().Close();
            }

            return new QuantumViewResponse();
        }

        public static void SaveSubscriptionData(QuantumViewResponse model, int syncId, string eventName)
        {
            var db = new VITALDB_TESTEntities();
            var data = model.QuantumViewEvents.SubscriptionEvents;

            foreach (var item in data)
            {
                SaveShipmentData(item.SubscriptionFile, syncId, eventName);
            }
        }

        public static void SaveShipmentData(List<SubscriptionFile> data, int syncId, string eventName)
        {
            var db = new VITALDB_TESTEntities();

            foreach (var file in data)
            {

                if (GetSubscriptionFileEntities().Any(r => r.SubscriptionFileName == file.FileName))
                    continue;

                Console.WriteLine("{0}: Saving Subscription {1}", DateTime.Now.ToString(), file.FileName);

                QVSubscriptionFile QVFile = new QVSubscriptionFile()
                {
                    SyncId = syncId,
                    SubscriptionNumber = "0",
                    Status = file.StatusType.Description,
                    SubscriptionFileName = file.FileName,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "SyncJob"
                };

                db.QVSubscriptionFiles.Add(QVFile);
                db.SaveChanges();

                List<QVShipmentDetail> ShipmentData = new List<QVShipmentDetail>();

                foreach (var item in file.Delivery)
                {

                    Console.WriteLine("{0}: Saving Delivery Tracking Number {1}", DateTime.Now.ToString(), item.TrackingNumber);

                    QVShipmentDetail model = new QVShipmentDetail();

                    model.SubscriptionFileId = QVFile.SubscriptionFileId;
                    model.TrackingNumber = item.TrackingNumber;
                    model.ShipmentEvent = eventName;

                    if (item.DeliveryLocation.AddressArtifactFormat != null)
                    {
                        model.ShipTo = string.Format("{0} {1} {2}, {3}",
                            string.IsNullOrEmpty(item.DeliveryLocation.AddressArtifactFormat.StreetName) ? string.Empty : item.DeliveryLocation.AddressArtifactFormat.StreetName,
                            string.IsNullOrEmpty(item.DeliveryLocation.AddressArtifactFormat.PoliticalDivision2) ? string.Empty : item.DeliveryLocation.AddressArtifactFormat.PoliticalDivision2,
                            string.IsNullOrEmpty(item.DeliveryLocation.AddressArtifactFormat.PoliticalDivision1) ? string.Empty : item.DeliveryLocation.AddressArtifactFormat.PoliticalDivision1,
                            string.IsNullOrEmpty(item.DeliveryLocation.AddressArtifactFormat.CountryCode) ? string.Empty : item.DeliveryLocation.AddressArtifactFormat.CountryCode);
                    }

                    model.ShipperNumber = item.ShipperNumber;

                    var shipmentData = TrackShipmentService.GetInformation(model.TrackingNumber).First();

                    model.DeliveryDate = new DateTime(
                        Convert.ToInt32(item.Date.Substring(0, 4)),
                        Convert.ToInt32(item.Date.Substring(4, 2)),
                        Convert.ToInt32(item.Date.Substring(6, 2)),
                        Convert.ToInt32(item.Time.Substring(0, 2)),
                        Convert.ToInt32(item.Time.Substring(2, 2)),
                        Convert.ToInt32(item.Time.Substring(4, 2))
                        );

                    model.Service = shipmentData.Description;
                    
                    

                    if (shipmentData.ManifestDate != null)
                    {
                        model.ManifestDate = Convert.ToDateTime(shipmentData.ManifestDate);
                    }

                    model.Status = shipmentData.Status;
                    model.CreatedBy = "SyncJob";
                    model.CreatedDate = DateTime.Now;

                    model.ExceptionDescription = "N/A";
                    model.ShipToAddressLine1 = "N/A";
                    model.ShipToAddressLine2 = "N/A";
                    model.ShipToAttention = "N/A";
                    model.ShipToCity = item.DeliveryLocation.AddressArtifactFormat.PoliticalDivision2 ?? string.Empty;
                    model.ShipToCountry = item.DeliveryLocation.AddressArtifactFormat.CountryCode ?? string.Empty;
                    model.ShipToName = item.DeliveryLocation.Description ?? string.Empty;
                    model.ShipToPostalCode = "N/A";
                    model.ShipToStateProvince = item.DeliveryLocation.AddressArtifactFormat.PoliticalDivision1 ?? string.Empty;
                    model.ShipToTelephoneNumber = "N/A";
                    model.SignedBy = item.DeliveryLocation.SignedForByName ?? string.Empty;

                    int count = 0;
                    foreach (var shipment in shipmentData.ShipmentPackage)
                    {
                        if (shipment.Reference.Trim() == "")
                        {
                            count++;
                            continue;
                        }

                        model.ReferenceNumber += shipment.Reference;
                        count++;

                        if (count < shipmentData.ShipmentPackage.Count)
                        {
                            model.ReferenceNumber += ",";
                        }
                    }

                    ShipmentData.Add(model);
                }

                foreach (var item in file.Exception)
                {
                    Console.WriteLine("{0}: Saving Exception Tracking Number {1}", DateTime.Now.ToString(), item.TrackingNumber);

                    QVShipmentDetail model = new QVShipmentDetail();

                    model.SubscriptionFileId = QVFile.SubscriptionFileId;
                    model.TrackingNumber = item.TrackingNumber;
                    model.ShipmentEvent = eventName;

                    if (item.ActivityLocation.AddressArtifactFormat != null)
                    {
                        model.ShipTo = string.Format("{0} {1} {2}, {3}",
                            string.IsNullOrEmpty(item.ActivityLocation.AddressArtifactFormat.StreetName) ? string.Empty : item.ActivityLocation.AddressArtifactFormat.StreetName,
                            string.IsNullOrEmpty(item.ActivityLocation.AddressArtifactFormat.PoliticalDivision2) ? string.Empty : item.ActivityLocation.AddressArtifactFormat.PoliticalDivision2,
                            string.IsNullOrEmpty(item.ActivityLocation.AddressArtifactFormat.PoliticalDivision1) ? string.Empty : item.ActivityLocation.AddressArtifactFormat.PoliticalDivision1,
                            string.IsNullOrEmpty(item.ActivityLocation.AddressArtifactFormat.CountryCode) ? string.Empty : item.ActivityLocation.AddressArtifactFormat.CountryCode);
                    }

                    model.ShipperNumber = item.ShipperNumber;

                    var shipmentData = TrackShipmentService.GetInformation(model.TrackingNumber).First();

                    model.DeliveryDate = new DateTime(
                        Convert.ToInt32(item.Date.Substring(0, 4)),
                        Convert.ToInt32(item.Date.Substring(4, 2)),
                        Convert.ToInt32(item.Date.Substring(6, 2)),
                        Convert.ToInt32(item.Time.Substring(0, 2)),
                        Convert.ToInt32(item.Time.Substring(2, 2)),
                        Convert.ToInt32(item.Time.Substring(4, 2))
                        );

                    model.Service = shipmentData.Description;

                    if (shipmentData.ManifestDate != null)
                    {
                        model.ManifestDate = Convert.ToDateTime(shipmentData.ManifestDate);
                    }

                    model.Status = shipmentData.Status;
                    model.CreatedBy = "SyncJob";
                    model.CreatedDate = DateTime.Now;

                    model.ExceptionDescription = item.ReasonDescription;
                    model.ShipToAddressLine1 = "N/A";
                    model.ShipToAddressLine2 = "N/A";
                    model.ShipToAttention = "N/A";
                    model.ShipToCity = item.ActivityLocation.AddressArtifactFormat.PoliticalDivision2 ?? string.Empty;
                    model.ShipToCountry = item.ActivityLocation.AddressArtifactFormat.CountryCode ?? string.Empty;
                    model.ShipToName = "N/A";
                    model.ShipToPostalCode = "N/A";
                    model.ShipToStateProvince = item.ActivityLocation.AddressArtifactFormat.PoliticalDivision1 ?? string.Empty;
                    model.ShipToTelephoneNumber = "N/A";
                    model.SignedBy = "N/A";

                    int count = 0;
                    foreach (var shipment in shipmentData.ShipmentPackage)
                    {
                        if (shipment.Reference.Trim() == "")
                        {
                            count++;
                            continue;
                        }

                        model.ReferenceNumber += shipment.Reference;
                        count++;

                        if (count < shipmentData.ShipmentPackage.Count)
                        {
                            model.ReferenceNumber += ",";
                        }
                    }

                    ShipmentData.Add(model);

                }

                foreach (var item in file.Manifest)
                {
                    Console.WriteLine("{0}: Saving Manifest Tracking Number {1}", DateTime.Now.ToString(), item.Package.TrackingNumber);

                    QVShipmentDetail model = new QVShipmentDetail();

                    model.SubscriptionFileId = QVFile.SubscriptionFileId;
                    model.TrackingNumber = item.Package.TrackingNumber;
                    model.ShipmentEvent = eventName;

                    if (item.ShipTo.Address != null)
                    {
                        model.ShipTo = string.Format("{0} {1} {2} {3}, {4}",
                            string.IsNullOrEmpty(item.ShipTo.Address.AddressLine1) ? string.Empty : item.ShipTo.Address.AddressLine1,
                            string.IsNullOrEmpty(item.ShipTo.Address.AddressLine2) ? string.Empty : item.ShipTo.Address.AddressLine2,
                            string.IsNullOrEmpty(item.ShipTo.Address.City) ? string.Empty : item.ShipTo.Address.City,
                            string.IsNullOrEmpty(item.ShipTo.Address.StateProvinceCode) ? string.Empty : item.ShipTo.Address.StateProvinceCode
                            , item.ShipTo.Address.CountryCode
                            );
                    }

                    model.ShipperNumber = item.Shipper.ShipperNumber;

                    var shipmentData = TrackShipmentService.GetInformation(model.TrackingNumber).First();

                    model.DeliveryDate = new DateTime(
                        Convert.ToInt32(item.ScheduledDeliveryDate.Substring(0, 4)),
                        Convert.ToInt32(item.ScheduledDeliveryDate.Substring(4, 2)),
                        Convert.ToInt32(item.ScheduledDeliveryDate.Substring(6, 2)),
                        Convert.ToInt32(item.ScheduledDeliveryTime.Substring(0, 2)),
                        Convert.ToInt32(item.ScheduledDeliveryTime.Substring(2, 2)),
                        Convert.ToInt32(item.ScheduledDeliveryTime.Substring(4, 2))
                        );

                    model.Service = shipmentData.Description;

                    if (shipmentData.ManifestDate != null)
                    {
                        model.ManifestDate = Convert.ToDateTime(shipmentData.ManifestDate);
                    }

                    model.Status = shipmentData.Status;
                    model.CreatedBy = "SyncJob";
                    model.CreatedDate = DateTime.Now;

                    model.ExceptionDescription = "N/A";
                    model.ShipToAddressLine1 = item.ShipTo.Address.AddressLine1;
                    model.ShipToAddressLine2 = item.ShipTo.Address.AddressLine2;
                    model.ShipToAttention = item.ShipTo.Address.ConsigneeName;
                    model.ShipToCity = item.ShipTo.Address.City;
                    model.ShipToCountry = item.ShipTo.Address.CountryCode;
                    model.ShipToName = item.ShipTo.Name;
                    model.ShipToPostalCode = item.ShipTo.Address.PostalCode;
                    model.ShipToStateProvince = item.ShipTo.Address.StateProvinceCode;
                    model.ShipToTelephoneNumber = "N/A";
                    model.SignedBy = "N/A";

                    int count = 0;
                    foreach (var shipment in shipmentData.ShipmentPackage)
                    {
                        if (shipment.Reference.Trim() == "")
                        {
                            count++;
                            continue;
                        }

                        model.ReferenceNumber += shipment.Reference;
                        count++;

                        if (count < shipmentData.ShipmentPackage.Count)
                        {
                            model.ReferenceNumber += ",";
                        }
                    }

                    ShipmentData.Add(model);
                }

                db.QVShipmentDetails.AddRange(ShipmentData);
                db.SaveChanges();

            }
        }
    }
}
