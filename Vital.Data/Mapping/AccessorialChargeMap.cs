using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vital.Data.Models.Mapping
{
    public class AccessorialChargeMap : EntityTypeConfiguration<AccessorialCharge>
    {
        public AccessorialChargeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.AccessorialChargeName)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("AccessorialCharges");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AccessorialChargeName).HasColumnName("AccessorialChargeName");
        }
    }
}
