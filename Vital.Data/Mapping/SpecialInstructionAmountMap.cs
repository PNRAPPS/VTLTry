using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vital.Data.Models.Mapping
{
    public class SpecialInstructionAmountMap : EntityTypeConfiguration<SpecialInstructionAmount>
    {
        public SpecialInstructionAmountMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("SpecialInstructionAmounts");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CarrierAmount).HasColumnName("CarrierAmount");
            this.Property(t => t.CarrierId).HasColumnName("CarrierId");
            this.Property(t => t.SpecialInstructionId).HasColumnName("SpecialInstructionId");

            // Relationships
            this.HasRequired(t => t.Carrier)
                .WithMany(t => t.SpecialInstructionAmounts)
                .HasForeignKey(d => d.CarrierId);
            this.HasRequired(t => t.SpecialInstruction)
                .WithMany(t => t.SpecialInstructionAmounts)
                .HasForeignKey(d => d.SpecialInstructionId);

        }
    }
}
