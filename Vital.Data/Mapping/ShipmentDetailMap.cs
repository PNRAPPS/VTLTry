using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vital.Data.Models.Mapping
{
    public class ShipmentDetailMap : EntityTypeConfiguration<ShipmentDetail>
    {
        public ShipmentDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.AccountNumber)
                .HasMaxLength(100);

            this.Property(t => t.ShipmentReferenceNumber)
                .HasMaxLength(100);

            this.Property(t => t.TrackingNumber)
                .HasMaxLength(100);

            this.Property(t => t.EnteredWeightUnitOfMeasure)
                .HasMaxLength(100);

            this.Property(t => t.BilledWeightUnitOfMeasure)
                .HasMaxLength(100);

            this.Property(t => t.ContainerType)
                .HasMaxLength(100);

            this.Property(t => t.ChargeClassificationCode)
                .HasMaxLength(100);

            this.Property(t => t.ChargeDescription)
                .HasMaxLength(100);

            this.Property(t => t.InvoiceCurrencyCode)
                .HasMaxLength(100);

            this.Property(t => t.SenderName)
                .HasMaxLength(100);

            this.Property(t => t.SenderCompanyName)
                .HasMaxLength(100);

            this.Property(t => t.SenderAddressLine1)
                .HasMaxLength(100);

            this.Property(t => t.SenderAddressLine2)
                .HasMaxLength(100);

            this.Property(t => t.SenderCity)
                .HasMaxLength(100);

            this.Property(t => t.SenderState)
                .HasMaxLength(6);

            this.Property(t => t.SenderPostal)
                .HasMaxLength(100);

            this.Property(t => t.SenderCountry)
                .HasMaxLength(100);

            this.Property(t => t.ReceiverName)
                .HasMaxLength(100);

            this.Property(t => t.ReceiverCompanyName)
                .HasMaxLength(100);

            this.Property(t => t.ReceiverAddressLine1)
                .HasMaxLength(100);

            this.Property(t => t.ReceiverAddressLine2)
                .HasMaxLength(100);

            this.Property(t => t.ReceiverCity)
                .HasMaxLength(100);

            this.Property(t => t.ReceiverState)
                .HasMaxLength(6);

            this.Property(t => t.ReceiverPostal)
                .HasMaxLength(100);

            this.Property(t => t.ReceiverCountry)
                .HasMaxLength(100);

            this.Property(t => t.SoldToCompanyName)
                .HasMaxLength(100);

            this.Property(t => t.SoldToAddressLine1)
                .HasMaxLength(100);

            this.Property(t => t.SoldToAddressLine2)
                .HasMaxLength(100);

            this.Property(t => t.SoldToCity)
                .HasMaxLength(100);

            this.Property(t => t.SoldToState)
                .HasMaxLength(6);

            this.Property(t => t.SoldToPostal)
                .HasMaxLength(100);

            this.Property(t => t.SoldToCountry)
                .HasMaxLength(100);

            this.Property(t => t.LeadShipmentNumber)
                .HasMaxLength(100);

            this.Property(t => t.WorldEaseNumber)
                .HasMaxLength(100);

            this.Property(t => t.ServiceCode)
                .HasMaxLength(100);

            this.Property(t => t.ReferenceNumber1)
                .HasMaxLength(100);

            this.Property(t => t.ReferenceNumber2)
                .HasMaxLength(100);

            this.Property(t => t.ReferenceNumber3)
                .HasMaxLength(100);

            this.Property(t => t.BillShippingChargesTo)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("ShipmentDetails");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.InvoiceDate).HasColumnName("InvoiceDate");
            this.Property(t => t.InvoiceNumber).HasColumnName("InvoiceNumber");
            this.Property(t => t.AccountNumber).HasColumnName("AccountNumber");
            this.Property(t => t.TransactionDate).HasColumnName("TransactionDate");
            this.Property(t => t.ShipmentReferenceNumber).HasColumnName("ShipmentReferenceNumber");
            this.Property(t => t.PackageQuantity).HasColumnName("PackageQuantity");
            this.Property(t => t.TrackingNumber).HasColumnName("TrackingNumber");
            this.Property(t => t.EnteredWeight).HasColumnName("EnteredWeight");
            this.Property(t => t.EnteredWeightUnitOfMeasure).HasColumnName("EnteredWeightUnitOfMeasure");
            this.Property(t => t.BilledWeight).HasColumnName("BilledWeight");
            this.Property(t => t.BilledWeightUnitOfMeasure).HasColumnName("BilledWeightUnitOfMeasure");
            this.Property(t => t.ContainerType).HasColumnName("ContainerType");
            this.Property(t => t.Zone).HasColumnName("Zone");
            this.Property(t => t.ChargeClassificationCode).HasColumnName("ChargeClassificationCode");
            this.Property(t => t.ChargeDescription).HasColumnName("ChargeDescription");
            this.Property(t => t.InvoiceCurrencyCode).HasColumnName("InvoiceCurrencyCode");
            this.Property(t => t.FreightCharge).HasColumnName("FreightCharge");
            this.Property(t => t.Fuel).HasColumnName("Fuel");
            this.Property(t => t.SalesTax).HasColumnName("SalesTax");
            this.Property(t => t.Total).HasColumnName("Total");
            this.Property(t => t.SenderName).HasColumnName("SenderName");
            this.Property(t => t.SenderCompanyName).HasColumnName("SenderCompanyName");
            this.Property(t => t.SenderAddressLine1).HasColumnName("SenderAddressLine1");
            this.Property(t => t.SenderAddressLine2).HasColumnName("SenderAddressLine2");
            this.Property(t => t.SenderCity).HasColumnName("SenderCity");
            this.Property(t => t.SenderState).HasColumnName("SenderState");
            this.Property(t => t.SenderPostal).HasColumnName("SenderPostal");
            this.Property(t => t.SenderCountry).HasColumnName("SenderCountry");
            this.Property(t => t.ReceiverName).HasColumnName("ReceiverName");
            this.Property(t => t.ReceiverCompanyName).HasColumnName("ReceiverCompanyName");
            this.Property(t => t.ReceiverAddressLine1).HasColumnName("ReceiverAddressLine1");
            this.Property(t => t.ReceiverAddressLine2).HasColumnName("ReceiverAddressLine2");
            this.Property(t => t.ReceiverCity).HasColumnName("ReceiverCity");
            this.Property(t => t.ReceiverState).HasColumnName("ReceiverState");
            this.Property(t => t.ReceiverPostal).HasColumnName("ReceiverPostal");
            this.Property(t => t.ReceiverCountry).HasColumnName("ReceiverCountry");
            this.Property(t => t.SoldToCompanyName).HasColumnName("SoldToCompanyName");
            this.Property(t => t.SoldToAddressLine1).HasColumnName("SoldToAddressLine1");
            this.Property(t => t.SoldToAddressLine2).HasColumnName("SoldToAddressLine2");
            this.Property(t => t.SoldToCity).HasColumnName("SoldToCity");
            this.Property(t => t.SoldToState).HasColumnName("SoldToState");
            this.Property(t => t.SoldToPostal).HasColumnName("SoldToPostal");
            this.Property(t => t.SoldToCountry).HasColumnName("SoldToCountry");
            this.Property(t => t.LeadShipmentNumber).HasColumnName("LeadShipmentNumber");
            this.Property(t => t.WorldEaseNumber).HasColumnName("WorldEaseNumber");
            this.Property(t => t.EnteredHeight).HasColumnName("EnteredHeight");
            this.Property(t => t.EnteredWidth).HasColumnName("EnteredWidth");
            this.Property(t => t.EnteredLength).HasColumnName("EnteredLength");
            this.Property(t => t.IsLargePackage).HasColumnName("IsLargePackage");
            this.Property(t => t.IsAdditionalHandling).HasColumnName("IsAdditionalHandling");
            this.Property(t => t.PackageDeclaredValue).HasColumnName("PackageDeclaredValue");
            this.Property(t => t.ServiceCode).HasColumnName("ServiceCode");
            this.Property(t => t.SendEmailNotificationFlag).HasColumnName("SendEmailNotificationFlag");
            this.Property(t => t.ReceiveConfirmationAndDeliveryFlag).HasColumnName("ReceiveConfirmationAndDeliveryFlag");
            this.Property(t => t.DeliveryOnSundayFlag).HasColumnName("DeliveryOnSundayFlag");
            this.Property(t => t.CODFlag).HasColumnName("CODFlag");
            this.Property(t => t.ReferenceNumber1).HasColumnName("ReferenceNumber1");
            this.Property(t => t.ReferenceNumber2).HasColumnName("ReferenceNumber2");
            this.Property(t => t.ReferenceNumber3).HasColumnName("ReferenceNumber3");
            this.Property(t => t.BillShippingChargesTo).HasColumnName("BillShippingChargesTo");
        }
    }
}
