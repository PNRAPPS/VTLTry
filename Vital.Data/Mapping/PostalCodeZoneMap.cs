using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vital.Data.Models.Mapping
{
    public class PostalCodeZoneMap : EntityTypeConfiguration<PostalCodeZone>
    {
        public PostalCodeZoneMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("PostalCodeZones");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.PostalCodeId).HasColumnName("PostalCodeId");
            this.Property(t => t.ShippingTypeId).HasColumnName("ShippingTypeId");
            this.Property(t => t.ZoneId).HasColumnName("ZoneId");

            // Relationships
            this.HasRequired(t => t.PostalCode)
                .WithMany(t => t.PostalCodeZones)
                .HasForeignKey(d => d.PostalCodeId);
            this.HasRequired(t => t.ShippingType)
                .WithMany(t => t.PostalCodeZones)
                .HasForeignKey(d => d.ShippingTypeId);
            this.HasRequired(t => t.Zone)
                .WithMany(t => t.PostalCodeZones)
                .HasForeignKey(d => d.ZoneId);

        }
    }
}
