using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vital.Data.Models.Mapping
{
    public class WeightMap : EntityTypeConfiguration<Weight>
    {
        public WeightMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Weights");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Low).HasColumnName("Low");
            this.Property(t => t.High).HasColumnName("High");
        }
    }
}
