using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vital.Data.Models.Mapping
{
    public class scope_config_dssMap : EntityTypeConfiguration<scope_config_dss>
    {
        public scope_config_dssMap()
        {
            // Primary Key
            this.HasKey(t => t.config_id);

            // Properties
            this.Property(t => t.config_data)
                .IsRequired();

            this.Property(t => t.scope_status)
                .IsFixedLength()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("scope_config_dss", "DataSync");
            this.Property(t => t.config_id).HasColumnName("config_id");
            this.Property(t => t.config_data).HasColumnName("config_data");
            this.Property(t => t.scope_status).HasColumnName("scope_status");
        }
    }
}
