using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vital.Data.Models.Mapping
{
    public class ShipmentDraftMap : EntityTypeConfiguration<ShipmentDraft>
    {
        public ShipmentDraftMap()
        {
            // Primary Key
            this.HasKey(t => t.ShipmentDraftId);

            // Table & Column Mappings
            this.ToTable("ShipmentDraft");
            this.Property(t => t.ShipmentDraftId).HasColumnName("ShipmentDraftId");

            this.Property(t => t.Username).HasColumnName("Username");
            this.Property(t => t.IsForReview).HasColumnName("IsForReview");
            this.Property(t => t.ShipperNumber).HasColumnName("ShipperNumber");
            this.Property(t => t.AccountNumber).HasColumnName("AccountNumber");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.DateModified).HasColumnName("DateModified");

            this.Property(t => t.UPS_Password).HasColumnName("UPS_Password");
            this.Property(t => t.UPS_Username).HasColumnName("UPS_Username");

            this.Property(t => t.ConsigneeIsEditMode).HasColumnName("ConsigneeIsEditMode");
            this.Property(t => t.ConsigneeAddressBookId).HasColumnName("ConsigneeAddressBookId");
            this.Property(t => t.ConsigneeCompanyName).HasColumnName("ConsigneeCompanyName");
            this.Property(t => t.ConsigneeContactName).HasColumnName("ConsigneeContactName");
            this.Property(t => t.ConsigneeCountry).HasColumnName("ConsigneeCountry");
            this.Property(t => t.ConsigneeAddress1).HasColumnName("ConsigneeAddress1");
            this.Property(t => t.ConsigneeAddress2).HasColumnName("ConsigneeAddress2");
            this.Property(t => t.ConsigneeAddress3).HasColumnName("ConsigneeAddress3");

            this.Property(t => t.ConsigneeCity).HasColumnName("ConsigneeCity");
            this.Property(t => t.ConsigneeProvince).HasColumnName("ConsigneeProvince");
            this.Property(t => t.ConsigneePostalCode).HasColumnName("ConsigneePostalCode");
            this.Property(t => t.ConsigneeTelephone).HasColumnName("ConsigneeTelephone");
            this.Property(t => t.ConsigneeTelephoneExt).HasColumnName("ConsigneeTelephoneExt");
            this.Property(t => t.ConsigneeEmail).HasColumnName("ConsigneeEmail");
            this.Property(t => t.ConsigneeIsResidential).HasColumnName("ConsigneeIsResidential");

            this.Property(t => t.ConsigneeSaveOptionForAddress).HasColumnName("ConsigneeSaveOptionForAddress");
            this.Property(t => t.ConsigneeSaveAddressBookAs).HasColumnName("ConsigneeSaveAddressBookAs");
            this.Property(t => t.ConsignorReturnAddressQuestion).HasColumnName("ConsignorReturnAddressQuestion");
            this.Property(t => t.ConsignorCompanyName).HasColumnName("ConsignorCompanyName");
            this.Property(t => t.ConsignorContactName).HasColumnName("ConsignorContactName");
            this.Property(t => t.ConsignorCountry).HasColumnName("ConsignorCountry");
            this.Property(t => t.ConsignorAddress1).HasColumnName("ConsignorAddress1");
            this.Property(t => t.ConsignorAddress2).HasColumnName("ConsignorAddress2");
            this.Property(t => t.ConsignorAddress3).HasColumnName("ConsignorAddress3");
            this.Property(t => t.ConsignorCity).HasColumnName("ConsignorCity");
            this.Property(t => t.ConsignorProvince).HasColumnName("ConsignorProvince");
            this.Property(t => t.ConsignorPostalCode).HasColumnName("ConsignorPostalCode");
            this.Property(t => t.ConsignorTelephone).HasColumnName("ConsignorTelephone");
            this.Property(t => t.ConsignorTelephoneExt).HasColumnName("ConsignorTelephoneExt");
            this.Property(t => t.ConsignorEmail).HasColumnName("ConsignorEmail");
            this.Property(t => t.ConsignorIsResidential).HasColumnName("ConsignorIsResidential");

            this.Property(t => t.ConsignorSaveOptionForAddress).HasColumnName("ConsignorSaveOptionForAddress");
            this.Property(t => t.ConsignorSaveAddressBookAs).HasColumnName("ConsignorSaveAddressBookAs");
            this.Property(t => t.ConsignorSaveOptionForCorporateAddress).HasColumnName("ConsignorSaveOptionForCorporateAddress");
            this.Property(t => t.ConsignorSaveCorporateAddressBookAs).HasColumnName("ConsignorSaveCorporateAddressBookAs");

            this.Property(t => t.NoOfPackage).HasColumnName("NoOfPackage");
            this.Property(t => t.Weight).HasColumnName("Weight");
            this.Property(t => t.UnitOfMeasurement).HasColumnName("UnitOfMeasurement");
            this.Property(t => t.PackagingType).HasColumnName("PackagingType");
            this.Property(t => t.PackageDimensionsLength).HasColumnName("PackageDimensionsLength");

            this.Property(t => t.PackageDimensionsWidth).HasColumnName("PackageDimensionsWidth");
            this.Property(t => t.PackageDimensionsHeight).HasColumnName("PackageDimensionsHeight");
            this.Property(t => t.PackageDeclaredValueCAD).HasColumnName("PackageDeclaredValueCAD");
            this.Property(t => t.LargePackage).HasColumnName("LargePackage");
            this.Property(t => t.AdditionalHandling).HasColumnName("AdditionalHandling");
            this.Property(t => t.ServiceType).HasColumnName("ServiceType");
            this.Property(t => t.SendEmailNotification).HasColumnName("SendEmailNotification");
            this.Property(t => t.ReceiveConfirmationofDelivery).HasColumnName("ReceiveConfirmationofDelivery");

            this.Property(t => t.DeliverOnSaturday).HasColumnName("DeliverOnSaturday");
            this.Property(t => t.COD).HasColumnName("COD");
            this.Property(t => t.ReferenceNumber1).HasColumnName("ReferenceNumber1");
            this.Property(t => t.ReferenceNumber2).HasColumnName("ReferenceNumber2");
            this.Property(t => t.ReferenceNumber3).HasColumnName("ReferenceNumber3");

            this.Property(t => t.AccountId).HasColumnName("AccountId");
            this.Property(t => t.IsScheduledPickup).HasColumnName("IsScheduledPickup");

            this.Property(t => t.collectionDate).HasColumnName("collectionDate");
            this.Property(t => t.latestPickupTimeHour).HasColumnName("latestPickupTimeHour");
            this.Property(t => t.latestPickupTimeMinute).HasColumnName("latestPickupTimeMinute");
            this.Property(t => t.earliestPickupTimeHour).HasColumnName("earliestPickupTimeHour");
            this.Property(t => t.earliestPickupTimeMinute).HasColumnName("earliestPickupTimeMinute");
            this.Property(t => t.ampm).HasColumnName("ampm");

            this.Property(t => t.contactName).HasColumnName("contactName");
            this.Property(t => t.telephone).HasColumnName("telephone");
            this.Property(t => t.extension).HasColumnName("extension");
            this.Property(t => t.room).HasColumnName("room");
            this.Property(t => t.floor).HasColumnName("floor");
            this.Property(t => t.pickupLocation).HasColumnName("pickupLocation");

            this.Property(t => t.IsResidential).HasColumnName("IsResidential");
            this.Property(t => t.pickupIdentificationNumber).HasColumnName("pickupIdentificationNumber");

        }
    }
}
