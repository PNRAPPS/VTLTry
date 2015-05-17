using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vital.Data.Models.Mapping
{
    public class CustomerAccountMap : EntityTypeConfiguration<CustomerAccount>
    {
        public CustomerAccountMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("CustomerAccounts");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.RateYear).HasColumnName("RateYear");
            this.Property(t => t.UPSEnabled).HasColumnName("UPSEnabled");
            this.Property(t => t.TermId).HasColumnName("TermId");
            this.Property(t => t.CustomerId).HasColumnName("CustomerId");

            // Relationships
            this.HasRequired(t => t.Customer)
                .WithMany(t => t.CustomerAccounts)
                .HasForeignKey(d => d.CustomerId);
            this.HasRequired(t => t.Term)
                .WithMany(t => t.CustomerAccounts)
                .HasForeignKey(d => d.TermId);

        }
    }
}
