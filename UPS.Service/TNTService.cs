using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Vital.Model;

namespace UPS.Service
{
    public class TNTService : ITimeInTransitService
    {
        WebRequest req = null;
        WebResponse rsp = null;

        private const int NumberOfRetries = 3;
        private const int DelayOnRetry = 1000;

        public TNTResponse GetTimeInTransit(ShipmentModel data)
        {

            TNTResponse model = new TNTResponse();

            for (int i = 1; i <= NumberOfRetries; i++)
            {
                try
                {
                    string uri = "https://onlinetools.ups.com/ups.app/xml/TimeInTransit";
                    req = WebRequest.Create(uri);
                    //req.Proxy = WebProxy.GetDefaultProxy(); // Enable if using proxy
                    req.Credentials = new NetworkCredential("myusername", "mypassword");
                    req.Method = "POST";        // Post method
                    req.ContentType = "text/xml";     // content type
                    StreamWriter writer = new StreamWriter(req.GetRequestStream());

                    AccessRequest arModel = new AccessRequest();
                    arModel.AccessLicenseNumber = "8CA6E5A96EF68803";
                    arModel.UserId = "qvm.rhenson";
                    arModel.Password = "Vital@123";

                    MemoryStream arStream = new MemoryStream();
                    XmlSerializer arSerializer = new XmlSerializer(arModel.GetType());
                    arSerializer.Serialize(arStream, arModel);

                    string arString = new string(Encoding.UTF8.GetChars(arStream.GetBuffer()));

                    TNTRequest tntRequest = new TNTRequest();
                    tntRequest.Request.RequestAction = "TimeInTransit";

                    tntRequest.TransitFrom.AddressArtifactFormat.PoliticalDivision2 = data.ConsigneeCity;
                    tntRequest.TransitFrom.AddressArtifactFormat.PoliticalDivision1 = data.ConsignorProvince;
                    tntRequest.TransitFrom.AddressArtifactFormat.PostcodePrimaryLow = data.ConsignorPostalCode;
                    tntRequest.TransitFrom.AddressArtifactFormat.CountryCode = data.ConsignorCountry;

                    tntRequest.TransitTo.AddressArtifactFormat.PoliticalDivision2 = data.ConsigneeCity;
                    tntRequest.TransitTo.AddressArtifactFormat.PoliticalDivision1 = data.ConsigneeProvince;
                    tntRequest.TransitTo.AddressArtifactFormat.PostcodePrimaryLow = data.ConsigneePostalCode;
                    tntRequest.TransitTo.AddressArtifactFormat.CountryCode = data.ConsigneeCountry;

                    tntRequest.PickupDate = DateTime.Now.ToString("yyyyMMdd");
                    tntRequest.MaximumListSize = "5";

                    tntRequest.InvoiceLineTotal.CurrencyCode = "CAD";
                    tntRequest.InvoiceLineTotal.MonetaryValue = data.PackageDeclaredValueCAD;

                    tntRequest.ShipmentWeight.UnitOfMeasurement.Code = data.UnitOfMeasurement.Equals("1") ? "LBS" : "KGS";

                    switch (tntRequest.ShipmentWeight.UnitOfMeasurement.Code.ToLower())
                    {
                        case "lbs":
                            tntRequest.ShipmentWeight.UnitOfMeasurement.Description = "Pounds";
                            break;
                        default:
                            tntRequest.ShipmentWeight.UnitOfMeasurement.Description = "Kilograms";
                            break;
                    }

                    tntRequest.ShipmentWeight.Weight = data.Weight;

                    MemoryStream tntStream = new MemoryStream();
                    XmlSerializer tntSerializer = new XmlSerializer(tntRequest.GetType());
                    tntSerializer.Serialize(tntStream, tntRequest);

                    string tntString = new string(Encoding.UTF8.GetChars(tntStream.GetBuffer()));
                    string requestString = arString + tntString;

                    Console.WriteLine(requestString);

                    writer.WriteLine(requestString);
                    writer.Close();

                    rsp = req.GetResponse(); //I am getting error over here
                    StreamReader sr = new StreamReader(rsp.GetResponseStream());

                    XmlSerializer serializer = new XmlSerializer(typeof(TNTResponse));
                    model = (TNTResponse)serializer.Deserialize(sr);
                }
                catch (Exception ex)
                {
                    Thread.Sleep(DelayOnRetry);
                }
            }



            return model;

        }
    }
}