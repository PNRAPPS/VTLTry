using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vital.Data.Models.Mapping
{
    public class QVShipmentDetailMap : EntityTypeConfiguration<QVShipmentDetail>
    {
        public QVShipmentDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.QVShipmentDetailId);

            // Properties
            // Table & Column Mappings
            this.ToTable("QVShipmentDetails");
            this.Property(t => t.Images).HasColumnName("Images");
            this.Property(t => t.ManifestDate).HasColumnName("ManifestDate");
            this.Property(t => t.QVShipmentDetailId).HasColumnName("QVShipmentDetailId");
            this.Property(t => t.ReferenceNumber).HasColumnName("ReferenceNumber");
            this.Property(t => t.ShipperNumber).HasColumnName("ShipperNumber");
            this.Property(t => t.ShipTo).HasColumnName("ShipTo");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Service).HasColumnName("Service");
            this.Property(t => t.SubscriptionFieldId).HasColumnName("SubscriptionFileId");
            this.Property(t => t.TrackingNumber).HasColumnName("TrackingNumber");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.DeliveryDate).HasColumnName("DeliveryDate");

            this.Property(t => t.ShipmentEvent).HasColumnName("ShipmentEvent");
            this.Property(t => t.SignedBy).HasColumnName("SignedBy");
            this.Property(t => t.ShipToAttention).HasColumnName("ShipToAttention");
            this.Property(t => t.ShipToName).HasColumnName("ShipToName");

            this.Property(t => t.ShipToAddressLine1).HasColumnName("ShipToAddressLine1");
            this.Property(t => t.ShipToAddressLine2).HasColumnName("ShipToAddressLine2");
            this.Property(t => t.ShipToTelephoneNumber).HasColumnName("ShipToTelephoneNumber");

            this.Property(t => t.ShipToCity).HasColumnName("ShipToCity");
            this.Property(t => t.ShipToStateProvince).HasColumnName("ShipToStateProvince");
            this.Property(t => t.ShipToPostalCode).HasColumnName("ShipToPostalCode");

            this.Property(t => t.ShipToCountry).HasColumnName("ShipToCountry");
            this.Property(t => t.ExceptionDescription).HasColumnName("ExceptionDescription");

        }
    }
}
