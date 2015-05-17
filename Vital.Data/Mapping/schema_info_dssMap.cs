using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vital.Data.Models.Mapping
{
    public class schema_info_dssMap : EntityTypeConfiguration<schema_info_dss>
    {
        public schema_info_dssMap()
        {
            // Primary Key
            this.HasKey(t => new { t.schema_major_version, t.schema_minor_version });

            // Properties
            this.Property(t => t.schema_major_version)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.schema_minor_version)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.schema_extended_info)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("schema_info_dss", "DataSync");
            this.Property(t => t.schema_major_version).HasColumnName("schema_major_version");
            this.Property(t => t.schema_minor_version).HasColumnName("schema_minor_version");
            this.Property(t => t.schema_extended_info).HasColumnName("schema_extended_info");
        }
    }
}
