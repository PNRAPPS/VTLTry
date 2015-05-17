using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vital.Data.Models.Mapping
{
    public class SkidWeightMap : EntityTypeConfiguration<SkidWeight>
    {
        public SkidWeightMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Label)
                .IsRequired()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("SkidWeights");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Label).HasColumnName("Label");
            this.Property(t => t.Low).HasColumnName("Low");
            this.Property(t => t.High).HasColumnName("High");
        }
    }
}
