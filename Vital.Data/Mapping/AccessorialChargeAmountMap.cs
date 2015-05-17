using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vital.Data.Models.Mapping
{
    public class AccessorialChargeAmountMap : EntityTypeConfiguration<AccessorialChargeAmount>
    {
        public AccessorialChargeAmountMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Remarks)
                .HasMaxLength(20);

            this.Property(t => t.CustomerAccountId)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("AccessorialChargeAmounts");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Content).HasColumnName("Content");
            this.Property(t => t.Remarks).HasColumnName("Remarks");
            this.Property(t => t.AccessorialChargeId).HasColumnName("AccessorialChargeId");
            this.Property(t => t.CustomerAccountId).HasColumnName("CustomerAccountId");

            // Relationships
            this.HasRequired(t => t.AccessorialCharge)
                .WithMany(t => t.AccessorialChargeAmounts)
                .HasForeignKey(d => d.AccessorialChargeId);
            this.HasRequired(t => t.CustomerAccount)
                .WithMany(t => t.AccessorialChargeAmounts)
                .HasForeignKey(d => d.CustomerAccountId);

        }
    }
}
