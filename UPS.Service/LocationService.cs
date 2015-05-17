using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Vital.Model;

namespace UPS.Service
{
    public class LocationService : ILocationService
    {
        public LocationResponseModel SearchLocation(Vital.Model.LocationsModel model)
        {
            WebRequest req = null;
            WebResponse rsp = null;
            try
            {
                string uri = "https://wwwcie.ups.com/ups.app/xml/Locator";
                // string uri = "https://www.ups.com/ups.app/xml/Locator";
                req = WebRequest.Create(uri);
                //req.Proxy = WebProxy.GetDefaultProxy(); // Enable if using proxy
                req.Credentials = new NetworkCredential("myusername", "mypassword");
                req.Method = "POST";        // Post method
                req.ContentType = "text/xml";     // content type
                // Wrap the request stream with a text-based writer
                StreamWriter writer = new StreamWriter(req.GetRequestStream());
                // Write the XML text into the stream

                AccessRequestModel arModel = new Vital.Model.AccessRequestModel();

                arModel.AccessLicenseNumber = "8CA6E5A96EF68803";
                arModel.UserId = "qvm.rhenson";
                arModel.Password = "Vital@123";

                MemoryStream arstream = new MemoryStream();
                XmlSerializer arSerializer = new XmlSerializer(arModel.GetType());
                arSerializer.Serialize(arstream, arModel);

                string test = new string(Encoding.UTF8.GetChars(arstream.GetBuffer()));

                LocatorRequestModel locModel = new LocatorRequestModel();

                locModel.Request = new Request()
                {
                    RequestAction = "Locator",
                    RequestOption = 1
                };

                locModel.Translate.LanguageCode = "ENG";
                locModel.UnitOfMeasurement.Code = "MI";
                locModel.OriginAddress.AddressKeyFormat = new AddressKeyFormat()
                {

                    AddressLine = "911-207 West Hastings",
                    CountryCode = model.Country,
                    PoliticalDivision1 = model.Country.Equals("CA") ? "ON" : "GA",
                    PoliticalDivision2 = model.Country.Equals("CA") ? "Toronto" : "Atlanta",
                    PostcodePrimaryLow = "V6B1H7"

                };

                List<OptionType> SearchOptionType1 = new List<OptionType>();
                SearchOptionType1.Add(new OptionType() { Code = "02" });

                List<OptionCode> SearchOptionCode1 = new List<OptionCode>();
                SearchOptionCode1.Add(new OptionCode() { Code = "01" });
                SearchOptionCode1.Add(new OptionCode() { Code = "03" });
                SearchOptionCode1.Add(new OptionCode() { Code = "04" });
                SearchOptionCode1.Add(new OptionCode() { Code = "05" });

                List<OptionType> SearchOptionType2 = new List<OptionType>();
                SearchOptionType2.Add(new OptionType() { Code = "03" });

                List<OptionCode> SearchOptionCode2 = new List<OptionCode>();
                SearchOptionCode2.Add(new OptionCode() { Code = "002" });

                SearchOptions SearchOption1 = new SearchOptions();
                SearchOption1.OptionCode = SearchOptionCode1;
                SearchOption1.OptionType = SearchOptionType1;

                SearchOptions SearchOption2 = new SearchOptions();
                SearchOption2.OptionCode = SearchOptionCode2;
                SearchOption2.OptionType = SearchOptionType2;

                locModel.LocationSearchCriteria.SearchOption.Add(SearchOption1);
                locModel.LocationSearchCriteria.SearchOption.Add(SearchOption2);

                MemoryStream locstream = new MemoryStream();
                XmlSerializer locSerializer = new XmlSerializer(locModel.GetType());
                locSerializer.Serialize(locstream, locModel);

                string loctest = new string(Encoding.UTF8.GetChars(locstream.GetBuffer()));

                //var file = Assembly.GetExecutingAssembly().GetManifestResourceStream("UPS.Service.UPSLocation_SampleRequest.xml");

                string locationValue = test + loctest;//GetTextFromXMLFile(file);

                writer.WriteLine(locationValue);
                writer.Close();

                Console.WriteLine(locationValue);
                // Send the data to the webserver
                rsp = req.GetResponse(); //I am getting error over here
                StreamReader sr = new StreamReader(rsp.GetResponseStream());
                string result = sr.ReadToEnd();
                sr.Close();

                var returndata = ProcessResponse(result);
                Console.WriteLine(result);

                return returndata;

            }
            catch (WebException webEx)
            {
                Console.WriteLine(webEx.Message);
                return new LocationResponseModel() { ResponseStatusCode = "0", ResponseMessage = webEx.Message };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new LocationResponseModel() { ResponseStatusCode = "0", ResponseMessage = ex.Message };
            }
            finally
            {
                if (req != null) req.GetRequestStream().Close();
                if (rsp != null) rsp.GetResponseStream().Close();
            }
        }

        private static string GetTextFromXMLFile(Stream file)
        {
            StreamReader reader = new StreamReader(file);
            string ret = reader.ReadToEnd();
            reader.Close();
            return ret;
        }

        private static LocationResponseModel ProcessResponse(string responseXml)
        {

            var xmlValue = XDocument.Parse(responseXml);
            var model = new LocationResponseModel();

            var responseData = xmlValue.Root.Element("Response");

            model.ResponseStatusCode = responseData.Element("ResponseStatusCode").Value;
            model.ResponseMessage = responseData.Element("ResponseStatusDescription").Value;

            Console.WriteLine("Response Code: {0}", responseData.Element("ResponseStatusCode").Value);
            Console.WriteLine("Response Message: {0}", responseData.Element("ResponseStatusDescription").Value);

            if (model.ResponseStatusCode != "1")
                return model;

            var searchResults = xmlValue.Root.Element("SearchResults").Elements("DropLocation");

            model.SearchResults = new List<LocationResponseSearchResults>();
            foreach (var item in searchResults)
            {
                //var droplocation = item.Element("DropLocation");

                var addressData = new LocationResponseSearchResults();

                var address = item.Element("AddressKeyFormat");
                var geocode = item.Element("Geocode");
                var distance = item.Element("Distance");

                addressData.ConsigneeName = address.Element("ConsigneeName") != null ? address.Element("ConsigneeName").Value : "No Name";
                addressData.AddressLine = address.Element("AddressLine") != null ? address.Element("AddressLine").Value : "No Address";
                addressData.PoliticalDivision2 = address.Element("PoliticalDivision2") != null ? address.Element("PoliticalDivision2").Value : "No PD2";
                addressData.PoliticalDivision1 = address.Element("PoliticalDivision1") != null ? address.Element("PoliticalDivision1").Value : "No PD1";
                addressData.PostCodePrimaryLow = address.Element("PostcodePrimaryLow") != null ? address.Element("PostcodePrimaryLow").Value : "No PPL";
                addressData.CountryCode = address.Element("CountryCode") != null ? address.Element("CountryCode").Value : "No Country Code";

                Console.WriteLine("Consignee Name: {0}", (address.Element("ConsigneeName") != null ? address.Element("ConsigneeName").Value : "No Name"));
                Console.WriteLine("Address: {0}", (address.Element("AddressLine") != null ? address.Element("AddressLine").Value : "No Address"));
                Console.WriteLine("PoliticalDivision2: {0}", (address.Element("PoliticalDivision2") != null ? address.Element("PoliticalDivision2").Value : "No PD2"));
                Console.WriteLine("PoliticalDivision1: {0}", (address.Element("PoliticalDivision1") != null ? address.Element("PoliticalDivision1").Value : "No PD1"));
                Console.WriteLine("PostcodePrimaryLow: {0}", (address.Element("PostcodePrimaryLow") != null ? address.Element("PostcodePrimaryLow").Value : "No PPL"));
                Console.WriteLine("CountryCode: {0}", (address.Element("CountryCode") != null ? address.Element("CountryCode").Value : "No Country Code"));

                addressData.Latitude = geocode.Element("Latitude") != null ? Convert.ToDecimal(geocode.Element("Latitude").Value) : -1;
                addressData.Longitude = geocode.Element("Longitude") != null ? Convert.ToDecimal(geocode.Element("Longitude").Value) : -1;

                Console.WriteLine("Latitude: {0}", (geocode.Element("Latitude") != null ? geocode.Element("Latitude").Value : "No Country Code"));
                Console.WriteLine("Longitude: {0}", (geocode.Element("Longitude") != null ? geocode.Element("Longitude").Value : "No Country Code"));

                addressData.Distance = Convert.ToDecimal(distance.Element("Value").Value);

                Console.WriteLine("Distance: {0}", distance.Element("Value").Value);
                Console.WriteLine("=====================");

                model.SearchResults.Add(addressData);
            }

            return model;

        }
    }
}
