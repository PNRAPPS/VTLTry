using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vital.Data.Models.Mapping
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.CustomerName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ContactPerson)
                .HasMaxLength(50);

            this.Property(t => t.Phone)
                .HasMaxLength(30);

            this.Property(t => t.PhoneExt)
                .HasMaxLength(30);

            this.Property(t => t.Fax)
                .HasMaxLength(30);

            this.Property(t => t.AltPhone)
                .HasMaxLength(30);

            this.Property(t => t.AltContactPerson)
                .HasMaxLength(50);

            this.Property(t => t.Email1)
                .HasMaxLength(50);

            this.Property(t => t.Email2)
                .HasMaxLength(50);

            this.Property(t => t.Address1)
                .HasMaxLength(50);

            this.Property(t => t.Address2)
                .HasMaxLength(50);

            this.Property(t => t.City)
                .HasMaxLength(50);

            this.Property(t => t.Province)
                .HasMaxLength(50);

            this.Property(t => t.PostalCode)
                .HasMaxLength(50);

            this.Property(t => t.Country)
                .HasMaxLength(15);

            this.Property(t => t.SalesRepresentative)
                .HasMaxLength(50);

            this.Property(t => t.UserName)
                .HasMaxLength(20);

            this.Property(t => t.Password)
                .HasMaxLength(100);

            this.Property(t => t.UPSPassword)
                .HasMaxLength(100);

            this.Property(t => t.UPSUsername)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Customers");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CustomerName).HasColumnName("CustomerName");
            this.Property(t => t.ContactPerson).HasColumnName("ContactPerson");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.PhoneExt).HasColumnName("PhoneExt");
            this.Property(t => t.Fax).HasColumnName("Fax");
            this.Property(t => t.AltPhone).HasColumnName("AltPhone");
            this.Property(t => t.AltContactPerson).HasColumnName("AltContactPerson");
            this.Property(t => t.Email1).HasColumnName("Email1");
            this.Property(t => t.Email2).HasColumnName("Email2");
            this.Property(t => t.Address1).HasColumnName("Address1");
            this.Property(t => t.Address2).HasColumnName("Address2");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.Province).HasColumnName("Province");
            this.Property(t => t.PostalCode).HasColumnName("PostalCode");
            this.Property(t => t.Country).HasColumnName("Country");
            this.Property(t => t.SalesRepresentative).HasColumnName("SalesRepresentative");
            this.Property(t => t.CommissionRate).HasColumnName("CommissionRate");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.UPSPassword).HasColumnName("UPSPassword");
            this.Property(t => t.UPSUsername).HasColumnName("UPSUsername");

            // Relationships
            this.HasMany(t => t.Roles)
                .WithMany(t => t.Customers)
                .Map(m =>
                    {
                        m.ToTable("RoleCustomers");
                        m.MapLeftKey("Customer_Id");
                        m.MapRightKey("Role_Id");
                    });
        }
    }
}
