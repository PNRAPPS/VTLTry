using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vital.Data.Models.Mapping
{
    public class ZoneDiscountPercentageMap : EntityTypeConfiguration<ZoneDiscountPercentage>
    {
        public ZoneDiscountPercentageMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.CustomerAccountId)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("ZoneDiscountPercentages");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Content).HasColumnName("Content");
            this.Property(t => t.PAKDiscountPercentage).HasColumnName("PAKDiscountPercentage");
            this.Property(t => t.LTRDiscountPercentage).HasColumnName("LTRDiscountPercentage");
            this.Property(t => t.CustomerAccountId).HasColumnName("CustomerAccountId");
            this.Property(t => t.ZoneId).HasColumnName("ZoneId");

            // Relationships
            this.HasRequired(t => t.CustomerAccount)
                .WithMany(t => t.ZoneDiscountPercentages)
                .HasForeignKey(d => d.CustomerAccountId);
            this.HasRequired(t => t.Zone)
                .WithMany(t => t.ZoneDiscountPercentages)
                .HasForeignKey(d => d.ZoneId);

        }
    }
}
