using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vital.Data.Models.Mapping
{
    public class SpecialInstructionMap : EntityTypeConfiguration<SpecialInstruction>
    {
        public SpecialInstructionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.SpecialInstructionName)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("SpecialInstructions");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.SpecialInstructionName).HasColumnName("SpecialInstructionName");
        }
    }
}
