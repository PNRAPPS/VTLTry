using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vital.Data.Models.Mapping
{
    public class CustomerSpInstructionAmountMap : EntityTypeConfiguration<CustomerSpInstructionAmount>
    {
        public CustomerSpInstructionAmountMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("CustomerSpInstructionAmounts");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CustomerAmount).HasColumnName("CustomerAmount");
            this.Property(t => t.CustomerId).HasColumnName("CustomerId");
            this.Property(t => t.SpecialInstructionId).HasColumnName("SpecialInstructionId");

            // Relationships
            this.HasRequired(t => t.Customer)
                .WithMany(t => t.CustomerSpInstructionAmounts)
                .HasForeignKey(d => d.CustomerId);
            this.HasRequired(t => t.SpecialInstruction)
                .WithMany(t => t.CustomerSpInstructionAmounts)
                .HasForeignKey(d => d.SpecialInstructionId);

        }
    }
}
