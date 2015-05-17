using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vital.Data.Models.Mapping
{
    public class QVSyncSummaryMap : EntityTypeConfiguration<QVSyncSummary>
    {
        public QVSyncSummaryMap()
        {
            // Primary Key
            this.HasKey(t => t.QVSyncId);

            // Properties
            // Table & Column Mappings
            this.ToTable("QVSyncSummary");
            this.Property(t => t.QVSyncId).HasColumnName("QVSyncId");
            this.Property(t => t.QVSyncStatusCode).HasColumnName("QVSyncStatusCode");
            this.Property(t => t.QVSyncStatusDescription).HasColumnName("QVSyncStatusDescription");
            this.Property(t => t.QVEventName).HasColumnName("QVEventName");
            this.Property(t => t.QVSyncDate).HasColumnName("QVSyncDate");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            
        }
    }
}
