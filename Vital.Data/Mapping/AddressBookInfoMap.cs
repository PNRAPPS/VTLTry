using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vital.Data.Models.Mapping
{
    public class AddressBookInfoMap : EntityTypeConfiguration<AddressBookInfo>
    {
        public AddressBookInfoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.NickName)
                .HasMaxLength(100);

            this.Property(t => t.CompanyOrName)
                .HasMaxLength(100);

            this.Property(t => t.Contact)
                .HasMaxLength(100);

            this.Property(t => t.Country)
                .HasMaxLength(100);

            this.Property(t => t.AddressLine1)
                .HasMaxLength(100);

            this.Property(t => t.AddressLine2)
                .HasMaxLength(100);

            this.Property(t => t.AddressLine3)
                .HasMaxLength(100);

            this.Property(t => t.City)
                .HasMaxLength(100);

            this.Property(t => t.Province)
                .HasMaxLength(100);

            this.Property(t => t.PostalCode)
                .HasMaxLength(100);

            this.Property(t => t.Telephone)
                .HasMaxLength(100);

            this.Property(t => t.Extension)
                .HasMaxLength(100);

            this.Property(t => t.Fax)
                .HasMaxLength(100);

            this.Property(t => t.EmailAddress)
                .HasMaxLength(100);

            this.Property(t => t.LocationID)
                .HasMaxLength(100);

            this.Property(t => t.ReceiverUPSAccount)
                .HasMaxLength(100);

            this.Property(t => t.ReceiverPostalCode)
                .HasMaxLength(100);

            this.Property(t => t.ReferenceType1)
                .HasMaxLength(100);

            this.Property(t => t.ReferenceType2)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("AddressBookInfoes");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.NickName).HasColumnName("NickName");
            this.Property(t => t.CompanyOrName).HasColumnName("CompanyOrName");
            this.Property(t => t.Contact).HasColumnName("Contact");
            this.Property(t => t.Country).HasColumnName("Country");
            this.Property(t => t.AddressLine1).HasColumnName("AddressLine1");
            this.Property(t => t.AddressLine2).HasColumnName("AddressLine2");
            this.Property(t => t.AddressLine3).HasColumnName("AddressLine3");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.Province).HasColumnName("Province");
            this.Property(t => t.PostalCode).HasColumnName("PostalCode");
            this.Property(t => t.IsResidential).HasColumnName("IsResidential");
            this.Property(t => t.Telephone).HasColumnName("Telephone");
            this.Property(t => t.Extension).HasColumnName("Extension");
            this.Property(t => t.Fax).HasColumnName("Fax");
            this.Property(t => t.EmailAddress).HasColumnName("EmailAddress");
            this.Property(t => t.LocationID).HasColumnName("LocationID");
            this.Property(t => t.SaveAsShipperFromFlag).HasColumnName("SaveAsShipperFromFlag");
            this.Property(t => t.ReceiverUPSAccount).HasColumnName("ReceiverUPSAccount");
            this.Property(t => t.ReceiverPostalCode).HasColumnName("ReceiverPostalCode");
            this.Property(t => t.ReferenceType1).HasColumnName("ReferenceType1");
            this.Property(t => t.ReferenceType2).HasColumnName("ReferenceType2");
            this.Property(t => t.OwnerOfAddressBook_Id).HasColumnName("OwnerOfAddressBook_Id");
            this.Property(t => t.Customer_Id).HasColumnName("Customer_Id");

            // Relationships
            this.HasOptional(t => t.Customer)
                .WithMany(t => t.AddressBookInfoes)
                .HasForeignKey(d => d.Customer_Id);

        }
    }
}
