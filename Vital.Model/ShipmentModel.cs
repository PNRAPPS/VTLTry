using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vital.Model
{

    public class ShipmentModel
    {

        public const string New = "New";
        public const string Void = "Void";

        public ShipmentModel()
        {
            UnitOfMeasurement = "1";
        }

        public string DraftId { get; set; }
        public string UPS_Username { get; set; }
        public string UPS_Password { get; set; }
        public string ShipperNumber { get; set; }

        [DisplayName("Bill Shipping Charges to")]
        public string AccountNumber { get; set; }

        #region Consignee Field
        public string ConsigneeIsEditMode { get; set; }
        public string ConsigneeAddressBookId { get; set; }
        public string ConsigneeCompanyName { get; set; }
        public string ConsigneeContactName { get; set; }
        public string ConsigneeCountry { get; set; }
        public string ConsigneeAddress1 { get; set; }
        public string ConsigneeAddress2 { get; set; }
        public string ConsigneeAddress3 { get; set; }

        public string ConsigneeCity { get; set; }
        public string ConsigneeProvince { get; set; }
        public string ConsigneePostalCode { get; set; }
        public string ConsigneeTelephone { get; set; }
        public string ConsigneeTelephoneExt { get; set; }
        public string ConsigneeEmail { get; set; }
        public bool ConsigneeIsResidential { get; set; }

        public int ConsigneeSaveOptionForAddress { get; set; }
        public string ConsigneeSaveAddressBookAs { get; set; }
        //public int ConsigneeSaveOptionForCorporateAddress { get; set; }
        //public string ConsigneeSaveCorporateAddressBookAs { get; set; }
        #endregion

        #region Consignor Field
        public string ConsignorReturnAddressQuestion { get; set; }
        public string ConsignorCompanyName { get; set; }
        public string ConsignorContactName { get; set; }
        public string ConsignorCountry { get; set; }
        public string ConsignorAddress1 { get; set; }
        public string ConsignorAddress2 { get; set; }
        public string ConsignorAddress3 { get; set; }
        public string ConsignorCity { get; set; }
        public string ConsignorProvince { get; set; }
        public string ConsignorPostalCode { get; set; }
        public string ConsignorTelephone { get; set; }
        public string ConsignorTelephoneExt { get; set; }
        public string ConsignorEmail { get; set; }
        public bool ConsignorIsResidential { get; set; }

        public int ConsignorSaveOptionForAddress { get; set; }
        public string ConsignorSaveAddressBookAs { get; set; }
        public int ConsignorSaveOptionForCorporateAddress { get; set; }
        public string ConsignorSaveCorporateAddressBookAs { get; set; }
        #endregion

        #region What are you shipping?

        [Required]
        [DisplayName("No Of Package")]
        [Range(1, int.MaxValue, ErrorMessage = "No Of Package must be greater than zero.")]
        public int NoOfPackage { get; set; }

        [DisplayName("Weight")]
        public string Weight { get; set; }

        [DisplayName("Unit of Measurement")]
        public string UnitOfMeasurement { get; set; }

        [DisplayName("Packaging Type")]
        public string PackagingType { get; set; }

        [DisplayName("Length")]
        public string PackageDimensionsLength { get; set; }

        [DisplayName("Width")]
        public string PackageDimensionsWidth { get; set; }

        [DisplayName("Height")]
        public string PackageDimensionsHeight { get; set; }

        [DisplayName("Package Declared Value")]
        public string PackageDeclaredValueCAD { get; set; }

        [DisplayName("Large Package")]
        public bool LargePackage { get; set; }

        [DisplayName("Additional Handling")]
        public bool AdditionalHandling { get; set; }

        #endregion

        #region How would you like to ship?

        [DisplayName("Service")]
        public string ServiceType { get; set; }

        [DisplayName("Send E-mail Notifications")]
        public bool SendEmailNotification { get; set; }

        [DisplayName("Receive Confirmation of Delivery")]
        public bool ReceiveConfirmationofDelivery { get; set; }

        [DisplayName("Deliver On Saturday")]
        public bool DeliverOnSaturday { get; set; }

        [DisplayName("C.O.D.")]
        public bool COD { get; set; }

        #endregion

        #region Would you like to add reference numbers to this shipment?

        [DisplayName("Reference # 1")]
        public string ReferenceNumber1 { get; set; }

        [DisplayName("Reference # 2")]
        public string ReferenceNumber2 { get; set; }

        [DisplayName("Reference # 3")]
        public string ReferenceNumber3 { get; set; }

        #endregion

        #region Payment
        public string AccountId { get; set; }
        #endregion

        #region Would you like to schedule a pickup?

        public bool IsScheduledPickup { get; set; }

        [DisplayName("Collection Date")]
        public string collectionDate { get; set; }
        public string latestPickupTimeHour { get; set; }
        public string latestPickupTimeMinute { get; set; }
        public string earliestPickupTimeHour { get; set; }
        public string earliestPickupTimeMinute { get; set; }
        public string ampm { get; set; }

        [DisplayName("Contact Name")]
        public string contactName { get; set; }

        [DisplayName("Telephone")]
        public string telephone { get; set; }

        [DisplayName("Extension")]
        public string extension { get; set; }

        [DisplayName("Room/Area")]
        public string room { get; set; }

        [DisplayName("Floor")]
        public string floor { get; set; }

        [DisplayName("Preferred Pickup Location")]
        public string pickupLocation { get; set; }

        [DisplayName("Residential Area?")]
        public bool IsResidential { get; set; }
        public string pickupIdentificationNumber { get; set; }
        #endregion

        public string Result { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsForReview { get; set; }

        public string ResultMessage { get; set; }
        public string ReviewServiceName { get; set; }

        public string ShipmentIdentificationNumber { get; set; }
        public byte[] ShipmentLabel { get; set; }
        public string LabelGenerate { get; set; }
    }
}
