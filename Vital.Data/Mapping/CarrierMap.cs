using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vital.Data.Models.Mapping
{
    public class CarrierMap : EntityTypeConfiguration<Carrier>
    {
        public CarrierMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.BillToAdd)
                .HasMaxLength(50);

            this.Property(t => t.Company)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.AccountNumber)
                .HasMaxLength(20);

            this.Property(t => t.ContactPerson)
                .HasMaxLength(50);

            this.Property(t => t.Telephone)
                .HasMaxLength(30);

            this.Property(t => t.Fax)
                .HasMaxLength(30);

            this.Property(t => t.Email)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Carriers");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.BillToAdd).HasColumnName("BillToAdd");
            this.Property(t => t.Company).HasColumnName("Company");
            this.Property(t => t.AccountNumber).HasColumnName("AccountNumber");
            this.Property(t => t.ContactPerson).HasColumnName("ContactPerson");
            this.Property(t => t.Telephone).HasColumnName("Telephone");
            this.Property(t => t.Fax).HasColumnName("Fax");
            this.Property(t => t.Email).HasColumnName("Email");
        }
    }
}
