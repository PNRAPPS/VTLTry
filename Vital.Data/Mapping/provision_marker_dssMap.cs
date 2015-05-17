using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vital.Data.Models.Mapping
{
    public class provision_marker_dssMap : EntityTypeConfiguration<provision_marker_dss>
    {
        public provision_marker_dssMap()
        {
            // Primary Key
            this.HasKey(t => new { t.object_id, t.owner_scope_local_id });

            // Properties
            this.Property(t => t.object_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.owner_scope_local_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.version)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();

            // Table & Column Mappings
            this.ToTable("provision_marker_dss", "DataSync");
            this.Property(t => t.object_id).HasColumnName("object_id");
            this.Property(t => t.owner_scope_local_id).HasColumnName("owner_scope_local_id");
            this.Property(t => t.provision_scope_local_id).HasColumnName("provision_scope_local_id");
            this.Property(t => t.provision_timestamp).HasColumnName("provision_timestamp");
            this.Property(t => t.provision_local_peer_key).HasColumnName("provision_local_peer_key");
            this.Property(t => t.provision_scope_peer_key).HasColumnName("provision_scope_peer_key");
            this.Property(t => t.provision_scope_peer_timestamp).HasColumnName("provision_scope_peer_timestamp");
            this.Property(t => t.provision_datetime).HasColumnName("provision_datetime");
            this.Property(t => t.state).HasColumnName("state");
            this.Property(t => t.version).HasColumnName("version");
        }
    }
}
