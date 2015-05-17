using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vital.Data.Models.Mapping
{
    public class ConsigneeMap : EntityTypeConfiguration<Consignee>
    {
        public ConsigneeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.AddressBookName)
                .HasMaxLength(100);

            this.Property(t => t.ConsigneeName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ConsigneeAddress1)
                .HasMaxLength(50);

            this.Property(t => t.ConsigneeAddress2)
                .HasMaxLength(50);

            this.Property(t => t.ConsigneeAddress3)
                .HasMaxLength(50);

            this.Property(t => t.ConsigneeCity)
                .HasMaxLength(50);

            this.Property(t => t.ConsigneeStateOrProvince)
                .HasMaxLength(50);

            this.Property(t => t.COnsigneePostalOrZip)
                .HasMaxLength(50);

            this.Property(t => t.ConsigneeCountry)
                .HasMaxLength(15);

            this.Property(t => t.ConsigneeContactPerson)
                .HasMaxLength(50);

            this.Property(t => t.ConsigneePhone)
                .HasMaxLength(30);

            this.Property(t => t.ConsigneePhoneExt)
                .HasMaxLength(20);

            this.Property(t => t.ConsigneeEmail)
                .HasMaxLength(100);

            this.Property(t => t.UPSId)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("Consignees");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AddressBookName).HasColumnName("AddressBookName");
            this.Property(t => t.ConsigneeName).HasColumnName("ConsigneeName");
            this.Property(t => t.ConsigneeAddress1).HasColumnName("ConsigneeAddress1");
            this.Property(t => t.ConsigneeAddress2).HasColumnName("ConsigneeAddress2");
            this.Property(t => t.ConsigneeAddress3).HasColumnName("ConsigneeAddress3");
            this.Property(t => t.ConsigneeCity).HasColumnName("ConsigneeCity");
            this.Property(t => t.ConsigneeStateOrProvince).HasColumnName("ConsigneeStateOrProvince");
            this.Property(t => t.COnsigneePostalOrZip).HasColumnName("COnsigneePostalOrZip");
            this.Property(t => t.ConsigneeCountry).HasColumnName("ConsigneeCountry");
            this.Property(t => t.ConsigneeContactPerson).HasColumnName("ConsigneeContactPerson");
            this.Property(t => t.ConsigneePhone).HasColumnName("ConsigneePhone");
            this.Property(t => t.ConsigneePhoneExt).HasColumnName("ConsigneePhoneExt");
            this.Property(t => t.ConsigneeEmail).HasColumnName("ConsigneeEmail");
            this.Property(t => t.ConsigneeIsResidential).HasColumnName("ConsigneeIsResidential");
            this.Property(t => t.UPSId).HasColumnName("UPSId");
        }
    }
}
