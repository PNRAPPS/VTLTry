using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vital.Data.Models.Mapping
{
    public class CustomerMarkupMap : EntityTypeConfiguration<CustomerMarkup>
    {
        public CustomerMarkupMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("CustomerMarkups");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MarkupPercentage).HasColumnName("MarkupPercentage");
            this.Property(t => t.CustomerId).HasColumnName("CustomerId");

            // Relationships
            this.HasRequired(t => t.Customer)
                .WithMany(t => t.CustomerMarkups)
                .HasForeignKey(d => d.CustomerId);

        }
    }
}
