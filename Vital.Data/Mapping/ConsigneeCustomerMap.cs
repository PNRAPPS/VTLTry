using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vital.Data.Models.Mapping
{
    public class ConsigneeCustomerMap : EntityTypeConfiguration<ConsigneeCustomer>
    {
        public ConsigneeCustomerMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Consignee_Id, t.Customer_Id });

            //// Properties
            //this.Property(t => t.field1)
            //    .IsFixedLength()
            //    .HasMaxLength(10);

            //this.Property(t => t.field2)
            //    .IsFixedLength()
            //    .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("ConsigneeCustomers");
            this.Property(t => t.Consignee_Id).HasColumnName("Consignee_Id");
            this.Property(t => t.Customer_Id).HasColumnName("Customer_Id");
            //this.Property(t => t.field1).HasColumnName("field1");
            //this.Property(t => t.field2).HasColumnName("field2");

            // Relationships
            this.HasRequired(t => t.Consignee)
                .WithMany(t => t.ConsigneeCustomers)
                .HasForeignKey(d => d.Consignee_Id);
            this.HasRequired(t => t.Customer)
                .WithMany(t => t.ConsigneeCustomers)
                .HasForeignKey(d => d.Customer_Id);

        }
    }
}
