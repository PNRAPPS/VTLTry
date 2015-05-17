
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Vital.Model;

namespace UPS.Service
{
    public class QuantumConstants
    {
        public const string Inbound = "IVS";
        public const string Outbound = "OVS";
    }

    public class QuantumService : IQuantumService
    {

        #region Outbound

        public IEnumerable<string> GetOutboundCustomViews()
        {
            yield return "Default Custom View";
        }

        public IEnumerable<string> GetOutboundSearchFilters()
        {
            yield return "Select One";
            yield return "Reference Number(s)";
            yield return "Ship To Name";
            yield return "Ship To Postal Code";
            yield return "Ship To State/Province";
            yield return "Tracking Number";
        }

        #endregion

        public Vital.Model.QuantumViewResponse GetQuantumData()
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
                //qvModel.SubscriptionRequest.Name = "InboundFull";
                qvModel.SubscriptionRequest.DateTimeRange.BeginDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(-7).ToString("yyyyMMdd") + "010000";
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

        public string GetTextFromXMLFile(string file)
        {
            StreamReader reader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("UPS.Service." + file));
            string ret = reader.ReadToEnd();
            reader.Close();
            return ret;
        }

        public QuantumViewModel ProcessData(QuantumViewResponse Response)
        {
            QuantumViewModel model = new QuantumViewModel();
            QuantumViewOutbound outboundModel = new QuantumViewOutbound();

            List<QuantumViewOutboundShipment> outboundShipmentModel = new List<QuantumViewOutboundShipment>();

            var outboundData = Response.QuantumViewEvents.SubscriptionEvents.Where(r => r.Name.Equals(QuantumConstants.Outbound));

            foreach (var subscriptionfile in outboundData)
            {
                var subscriptionData = subscriptionfile.SubscriptionFile.ToList();

                foreach (var item in subscriptionData)
                {
                    outboundShipmentModel.AddRange(item.Delivery.Select(r => new QuantumViewOutboundShipment()
                    {
                        TrackingNumber = r.TrackingNumber,

                    }));
                }
            }

            return model;
        }

        public List<QuantumViewShipmentDetail> GetSubscriptionEventData(QuantumViewResponse dataResponse, string nameCollection)
        {

            List<QuantumViewShipmentDetail> ShipmentData = new List<QuantumViewShipmentDetail>();

            foreach (var name in nameCollection.Split(','))
            {

                var data = dataResponse.QuantumViewEvents.SubscriptionEvents.Where(r => r.Name == name);

                string trackingNumbers = string.Empty;

                foreach (var SubscriptionData in data)
                {
                    foreach (var SubscriptionFile in SubscriptionData.SubscriptionFile)
                    {
                        foreach (var DeliveryItem in SubscriptionFile.Delivery)
                        {
                            trackingNumbers += DeliveryItem.TrackingNumber + Environment.NewLine;

                            QuantumViewShipmentDetail model = new QuantumViewShipmentDetail();

                            model.Type = name;
                            model.TrackingNumber = DeliveryItem.TrackingNumber;

                            if (DeliveryItem.DeliveryLocation.AddressArtifactFormat != null)
                            {
                                model.ShipTo = string.Format("{0} {1} {2}, {3}",
                                    string.IsNullOrEmpty(DeliveryItem.DeliveryLocation.AddressArtifactFormat.StreetName) ? string.Empty : DeliveryItem.DeliveryLocation.AddressArtifactFormat.StreetName,
                                    string.IsNullOrEmpty(DeliveryItem.DeliveryLocation.AddressArtifactFormat.PoliticalDivision2) ? string.Empty : DeliveryItem.DeliveryLocation.AddressArtifactFormat.PoliticalDivision2,
                                    string.IsNullOrEmpty(DeliveryItem.DeliveryLocation.AddressArtifactFormat.PoliticalDivision1) ? string.Empty : DeliveryItem.DeliveryLocation.AddressArtifactFormat.PoliticalDivision1,
                                    string.IsNullOrEmpty(DeliveryItem.DeliveryLocation.AddressArtifactFormat.CountryCode) ? string.Empty : DeliveryItem.DeliveryLocation.AddressArtifactFormat.CountryCode);
                            }

                            model.ShipperNumber = DeliveryItem.ShipperNumber;
                            model.Service = string.Empty;
                            model.ScheduledDelivery = DeliveryItem.Date + DeliveryItem.Time;
                            model.ReferenceNumber = string.Empty;
                            model.ManifestDate = string.Empty;
                            model.Status = string.Empty;

                            ShipmentData.Add(model);
                        }
                    }
                }
            }

            return ShipmentData;

        }

        public List<QuantumViewSummary> GetSubscriptionSummary(List<QuantumViewShipmentDetail> data, string name)
        {
            List<QuantumViewSummary> ShipmentSummary = new List<QuantumViewSummary>();

            ShipmentSummary = data.GroupBy(r => r.ShipperNumber).Select(r => new QuantumViewSummary()
            {
                UPSAccount = r.Key,
                Delivered = r.Where(x => x.Status.Equals("Delivered")).Count(),
                Exception = r.Where(x => x.Status.Equals("Exception")).Count(),
                InTransit = r.Where(x => x.Status.Equals("In Transit")).Count(),
                Manifest = r.Where(x => x.Status.Equals("Manifest")).Count(),
                OutOfDeliver = r.Where(x => x.Status.Equals("Out of Deliver")).Count(),
                ReadyForPickup = r.Where(x => x.Status.Equals("Ready for Pickup")).Count(),
                Total = r.Where(x => x.Status.Equals("Delivered")).Count(),
                Void = r.Where(x => x.Status.Equals("Void")).Count()
            }).ToList();

            return ShipmentSummary;
        }

    }
}
