using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using UPS.Service.LabelRecoveryService;
using System.IO;
using System.Threading;

namespace UPS.Service
{

    public class LabelService : UPS.Service.ILabelRecoveryService
    {
        private const int NumberOfRetries = 3;
        private const int DelayOnRetry = 1000;

        public Vital.Model.ShipmentModel CreateProcessLabel(Vital.Model.ShipmentModel model)
        {

            for (int i = 1; i <= NumberOfRetries; i++)
            {
                try
                {
                    LBRecovery lb_recovery = new LBRecovery();
                    LabelRecoveryRequest label_recovery_request = new LabelRecoveryRequest();
                    UPSSecurity upss = new UPSSecurity();
                    UPSSecurityServiceAccessToken upssSvcAccessToken = new UPSSecurityServiceAccessToken();
                    upssSvcAccessToken.AccessLicenseNumber = "5CB665A949CE652A";

                    upss.ServiceAccessToken = upssSvcAccessToken;
                    UPSSecurityUsernameToken upssUsrNameToken = new UPSSecurityUsernameToken();

                    upssUsrNameToken.Username = "qvm.rhenson";
                    upssUsrNameToken.Password = "Vital@123";

                    upss.UsernameToken = upssUsrNameToken;
                    lb_recovery.UPSSecurityValue = upss;
                    RequestType request = new RequestType();

                    label_recovery_request.Request = request;
                    label_recovery_request.TrackingNumber = "1Z12345E8791315413"; // model.ShipmentIdentificationNumber;
                    //label_recovery_request.ReferenceValues = new ReferenceValuesType()
                    //{
                    //    ShipperNumber = "0596VE"
                    //};

                    //label_recovery_request.ReferenceValues.ReferenceNumber = new ReferenceNumberType()
                    //{
                    //    Value = model.ReferenceNumber1 ?? string.Empty
                    //};
                    
                    LabelRecoveryResponse label_recovery_response = lb_recovery.ProcessLabelRecovery(label_recovery_request);
                    //LabelImageType image1=(LabelImageType)label_recovery_response.Items[0];
                    LabelResultsType image = (LabelResultsType)label_recovery_response.Items[0];
                    byte[] bytes = Convert.FromBase64String(image.LabelImage.GraphicImage);

                    MemoryStream ms = new MemoryStream(bytes);

                    using (System.Drawing.Image img = System.Drawing.Image.FromStream(ms))
                    {
                        MemoryStream finalMs = new MemoryStream(0);
                        img.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipNone);
                        img.Save(finalMs, System.Drawing.Imaging.ImageFormat.Jpeg);
                        model.ShipmentLabel = finalMs.ToArray();
                    }

                    return model;

                }
                catch (System.Web.Services.Protocols.SoapException ex)
                {
                    Console.WriteLine("");
                    Console.WriteLine("---------LBRecovery Web Service returns error----------------");
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
                catch (Exception ex)
                {
                    Console.WriteLine("");
                    Console.WriteLine("-------------------------");
                    Console.WriteLine(" General Exception= " + ex.Message);
                    Console.WriteLine(" General Exception-StackTrace= " + ex.StackTrace);
                    Console.WriteLine("-------------------------");

                }

                Thread.Sleep(DelayOnRetry);

            }

            return model;

        }


        public string GetImageFromStream(byte[] imageBytes)
        {
            MemoryStream memoryStream = new MemoryStream(imageBytes);
            return "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray(), 0, memoryStream.ToArray().Length);
        }
    }
}
