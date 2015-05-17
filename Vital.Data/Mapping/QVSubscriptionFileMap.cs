using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vital.Data.Models.Mapping
{
    public class QVSubscriptionFileMap : EntityTypeConfiguration<QVSubscriptionFile>
    {
        public QVSubscriptionFileMap()
        {
            // Primary Key
            this.HasKey(t => t.SubscriptionFileId);

            // Properties
            // Table & Column Mappings
            this.ToTable("QVSubscriptionFile");
            this.Property(t => t.SubscriptionFileId).HasColumnName("SubscriptionFileId");
            this.Property(t => t.SubscriptionFileName).HasColumnName("SubscriptionFileName");
            this.Property(t => t.SubscriptionNumber).HasColumnName("SubscriptionNumber");
            this.Property(t => t.SyncId).HasColumnName("SyncId");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.Status).HasColumnName("Status");

        }
    }
}
