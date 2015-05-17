using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vital.Data.Models.Mapping
{
    public class SkidMap : EntityTypeConfiguration<Skid>
    {
        public SkidMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.SkidDescription)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.UnitOfMeasurement)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(t => t.QuotationId)
                .IsRequired()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Skids");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.SkidDescription).HasColumnName("SkidDescription");
            this.Property(t => t.ItemLength).HasColumnName("ItemLength");
            this.Property(t => t.ItemWidth).HasColumnName("ItemWidth");
            this.Property(t => t.ItemHeight).HasColumnName("ItemHeight");
            this.Property(t => t.SkidVolume).HasColumnName("SkidVolume");
            this.Property(t => t.SkidWeight).HasColumnName("SkidWeight");
            this.Property(t => t.UnitOfMeasurement).HasColumnName("UnitOfMeasurement");
            this.Property(t => t.QuotationId).HasColumnName("QuotationId");
        }
    }
}
