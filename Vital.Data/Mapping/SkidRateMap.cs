using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vital.Data.Models.Mapping
{
    public class SkidRateMap : EntityTypeConfiguration<SkidRate>
    {
        public SkidRateMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.OriginCity)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.OriginState)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.OriginAbbreviation)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.OriginCountry)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.DestinationCity)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.DestinationState)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.DestinationAbbreviation)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.DestinationCountry)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.Type)
                .IsRequired()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("SkidRates");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.SkidPieces).HasColumnName("SkidPieces");
            this.Property(t => t.OriginCity).HasColumnName("OriginCity");
            this.Property(t => t.OriginState).HasColumnName("OriginState");
            this.Property(t => t.OriginAbbreviation).HasColumnName("OriginAbbreviation");
            this.Property(t => t.OriginCountry).HasColumnName("OriginCountry");
            this.Property(t => t.DestinationCity).HasColumnName("DestinationCity");
            this.Property(t => t.DestinationState).HasColumnName("DestinationState");
            this.Property(t => t.DestinationAbbreviation).HasColumnName("DestinationAbbreviation");
            this.Property(t => t.DestinationCountry).HasColumnName("DestinationCountry");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Rate).HasColumnName("Rate");
            this.Property(t => t.CarrierId).HasColumnName("CarrierId");
            this.Property(t => t.SkidWeightId).HasColumnName("SkidWeightId");

            // Relationships
            this.HasRequired(t => t.Carrier)
                .WithMany(t => t.SkidRates)
                .HasForeignKey(d => d.CarrierId);
            this.HasRequired(t => t.SkidWeight)
                .WithMany(t => t.SkidRates)
                .HasForeignKey(d => d.SkidWeightId);

        }
    }
}
