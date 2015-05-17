using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vital.Data.Models.Mapping
{
    public class CustomerShipmentMap : EntityTypeConfiguration<CustomerShipment>
    {
        public CustomerShipmentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.trackingNumber)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.pickupNumber)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.status)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CustomerShipment");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.customerId).HasColumnName("customerId");
            this.Property(t => t.trackingNumber).HasColumnName("trackingNumber");
            this.Property(t => t.pickupNumber).HasColumnName("pickupNumber");
            this.Property(t => t.createdDate).HasColumnName("createdDate");
            this.Property(t => t.modifiedDate).HasColumnName("modifiedDate");
            this.Property(t => t.status).HasColumnName("status");
            this.Property(t => t.shipmentLabel).HasColumnName("shipmentLabel");

            // Relationships
            this.HasRequired(t => t.Customer)
                .WithMany(t => t.CustomerShipments)
                .HasForeignKey(d => d.customerId);

        }
    }
}
