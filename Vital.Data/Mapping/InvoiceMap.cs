using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vital.Data.Models.Mapping
{
    public class InvoiceMap : EntityTypeConfiguration<Invoice>
    {
        public InvoiceMap()
        {
            // Primary Key
            this.HasKey(t => t.invoiceId);

            // Properties
            this.Property(t => t.invoiceSubject)
                .IsRequired().IsMaxLength();

            this.Property(t => t.invoiceDetails)
                .IsRequired().IsMaxLength();

            this.Property(t => t.invoiceDate);

            this.Property(t => t.invoiceFileName)
                .IsRequired().IsMaxLength();

            this.Property(t => t.dateUpload);
            this.Property(t => t.username).IsMaxLength();
          

            // Table & Column Mappings
            this.ToTable("Invoice");
            this.Property(t => t.invoiceId).HasColumnName("invoiceId");
            this.Property(t => t.invoiceSubject).HasColumnName("invoiceSubject");
            this.Property(t => t.invoiceDetails).HasColumnName("invoiceDetails");
            this.Property(t => t.invoiceDate).HasColumnName("invoiceDate");
            this.Property(t => t.invoiceFileName).HasColumnName("invoiceFileName");
            this.Property(t => t.dateUpload).HasColumnName("dateUpload");
            this.Property(t => t.username).HasColumnName("username");
         
        }
    }
}
