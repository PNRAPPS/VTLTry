using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vital.Data.Models.Mapping
{
    public class scope_info_dssMap : EntityTypeConfiguration<scope_info_dss>
    {
        public scope_info_dssMap()
        {
            // Primary Key
            this.HasKey(t => t.sync_scope_name);

            // Properties
            this.Property(t => t.scope_local_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.sync_scope_name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.scope_timestamp)
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();

            // Table & Column Mappings
            this.ToTable("scope_info_dss", "DataSync");
            this.Property(t => t.scope_local_id).HasColumnName("scope_local_id");
            this.Property(t => t.scope_id).HasColumnName("scope_id");
            this.Property(t => t.sync_scope_name).HasColumnName("sync_scope_name");
            this.Property(t => t.scope_sync_knowledge).HasColumnName("scope_sync_knowledge");
            this.Property(t => t.scope_tombstone_cleanup_knowledge).HasColumnName("scope_tombstone_cleanup_knowledge");
            this.Property(t => t.scope_timestamp).HasColumnName("scope_timestamp");
            this.Property(t => t.scope_config_id).HasColumnName("scope_config_id");
            this.Property(t => t.scope_restore_count).HasColumnName("scope_restore_count");
            this.Property(t => t.scope_user_comment).HasColumnName("scope_user_comment");
        }
    }
}
