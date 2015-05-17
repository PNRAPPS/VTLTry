using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vital.Data.Models.Mapping
{
    public class TaxMap : EntityTypeConfiguration<Tax>
    {
        public TaxMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.TaxName)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.TaxStateAbbreviation)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.TaxState)
                .IsRequired()
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("Taxes");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TaxName).HasColumnName("TaxName");
            this.Property(t => t.TaxStateAbbreviation).HasColumnName("TaxStateAbbreviation");
            this.Property(t => t.TaxState).HasColumnName("TaxState");
            this.Property(t => t.TaxPercent).HasColumnName("TaxPercent");
        }
    }
}
