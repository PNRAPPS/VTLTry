using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vital.Data.Models.Mapping
{
    public class ZoneRateMap : EntityTypeConfiguration<ZoneRate>
    {
        public ZoneRateMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Type)
                .IsRequired()
                .HasMaxLength(5);

            // Table & Column Mappings
            this.ToTable("ZoneRates");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Minimum).HasColumnName("Minimum");
            this.Property(t => t.Rate).HasColumnName("Rate");
            this.Property(t => t.RateYear).HasColumnName("RateYear");
            this.Property(t => t.ZoneId).HasColumnName("ZoneId");
            this.Property(t => t.WeightId).HasColumnName("WeightId");

            // Relationships
            this.HasRequired(t => t.Weight)
                .WithMany(t => t.ZoneRates)
                .HasForeignKey(d => d.WeightId);
            this.HasRequired(t => t.Zone)
                .WithMany(t => t.ZoneRates)
                .HasForeignKey(d => d.ZoneId);

        }
    }
}
