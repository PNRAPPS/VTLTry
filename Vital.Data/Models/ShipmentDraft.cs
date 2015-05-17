using System;
using System.Collections.Generic;

namespace Vital.Data.Models
{
    public partial class ShipmentDraft : Repository.EntityBase
    {

        public Guid ShipmentDraftId { get; set; }
        public string Username { get; set; }
        public bool IsForReview { get; set; }
        public string ShipperNumber { get; set; }
        public string AccountNumber { get; set; }
        public string Status { get; set; }
        public DateTime DateModified { get; set; }

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
        
        public int NoOfPackage { get; set; }
        public string Weight { get; set; }
        public string UnitOfMeasurement { get; set; }
        public string PackagingType { get; set; }
        public string PackageDimensionsLength { get; set; }

        public string PackageDimensionsWidth { get; set; }
        public string PackageDimensionsHeight { get; set; }
        public string PackageDeclaredValueCAD { get; set; }
        public bool LargePackage { get; set; }
        public bool AdditionalHandling { get; set; }
        public string ServiceType { get; set; }
        public bool SendEmailNotification { get; set; }
        public bool ReceiveConfirmationofDelivery { get; set; }

        public bool DeliverOnSaturday { get; set; }
        public bool COD { get; set; }
        public string ReferenceNumber1 { get; set; }
        public string ReferenceNumber2 { get; set; }
        public string ReferenceNumber3 { get; set; }

        public string AccountId { get; set; }
        public bool IsScheduledPickup { get; set; }

        public string collectionDate { get; set; }
        public string latestPickupTimeHour { get; set; }
        public string latestPickupTimeMinute { get; set; }
        public string earliestPickupTimeHour { get; set; }
        public string earliestPickupTimeMinute { get; set; }
        public string ampm { get; set; }

        public string contactName { get; set; }
        public string telephone { get; set; }
        public string extension { get; set; }
        public string room { get; set; }
        public string floor { get; set; }
        public string pickupLocation { get; set; }

        public bool IsResidential { get; set; }
        public string pickupIdentificationNumber { get; set; }

        public string UPS_Username { get; set; }
        public string UPS_Password { get; set; }

    }
}
