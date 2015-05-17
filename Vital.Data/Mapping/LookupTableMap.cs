using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vital.Data.Models.Mapping
{
    public class LookupTableMap : EntityTypeConfiguration<LookupTable>
    {
        public LookupTableMap()
        {
            // Primary Key
            this.HasKey(t => t.LookupId);

            // Table & Column Mappings
            this.ToTable("LookupTable");
            this.Property(t => t.LookupId).HasColumnName("LookupId");
            this.Property(t => t.LookupCode).HasColumnName("LookupCode");
            this.Property(t => t.LookupValue).HasColumnName("LookupValue");
            this.Property(t => t.LookupText).HasColumnName("LookupText");
            this.Property(t => t.DateAdded).HasColumnName("DateAdded");

        }
    }
}
