using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vital.Data.Models.Mapping
{
    public class BillingSummaryMap : EntityTypeConfiguration<BillingSummary>
    {
        public BillingSummaryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Customer)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("BillingSummaries");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.BillingDate).HasColumnName("BillingDate");
            this.Property(t => t.Customer).HasColumnName("Customer");
            this.Property(t => t.TotalInvoiceAmount).HasColumnName("TotalInvoiceAmount");
            this.Property(t => t.ExemptBRK).HasColumnName("ExemptBRK");
            this.Property(t => t.CustomsGSTorVAT).HasColumnName("CustomsGSTorVAT");
            this.Property(t => t.ExemptCharges).HasColumnName("ExemptCharges");
            this.Property(t => t.TaxableBRK).HasColumnName("TaxableBRK");
            this.Property(t => t.BRKTax).HasColumnName("BRKTax");
            this.Property(t => t.GSTApp).HasColumnName("GSTApp");
            this.Property(t => t.GSTAmt).HasColumnName("GSTAmt");
            this.Property(t => t.HBCApp).HasColumnName("HBCApp");
            this.Property(t => t.HBCAmt).HasColumnName("HBCAmt");
            this.Property(t => t.HONApp).HasColumnName("HONApp");
            this.Property(t => t.HONAmt).HasColumnName("HONAmt");
            this.Property(t => t.HNSApp).HasColumnName("HNSApp");
            this.Property(t => t.HNSAmt).HasColumnName("HNSAmt");
            this.Property(t => t.HSTApp).HasColumnName("HSTApp");
            this.Property(t => t.HSTAmt).HasColumnName("HSTAmt");
            this.Property(t => t.InvoiceNumber).HasColumnName("InvoiceNumber");
            this.Property(t => t.Cost).HasColumnName("Cost");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.Commission).HasColumnName("Commission");
            this.Property(t => t.AgentCommission).HasColumnName("AgentCommission");
            this.Property(t => t.Agent).HasColumnName("Agent");
        }
    }
}
