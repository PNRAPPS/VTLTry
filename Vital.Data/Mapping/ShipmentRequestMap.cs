using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vital.Data.Models.Mapping
{
    public class ShipmentRequestMap : EntityTypeConfiguration<ShipmentRequest>
    {
        public ShipmentRequestMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.Status)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.SpecialInstruction1)
                .HasMaxLength(100);

            this.Property(t => t.SpecialInstruction2)
                .HasMaxLength(100);

            this.Property(t => t.SpecialInstruction3)
                .HasMaxLength(100);

            this.Property(t => t.ShipperName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ShipperReference)
                .HasMaxLength(100);

            this.Property(t => t.ShipperAddress1)
                .HasMaxLength(100);

            this.Property(t => t.ShipperAddress2)
                .HasMaxLength(100);

            this.Property(t => t.ShipperCity)
                .HasMaxLength(100);

            this.Property(t => t.ShipperProvince)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ShipperPostal)
                .HasMaxLength(100);

            this.Property(t => t.ShipperCountry)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ConsigneeName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ConsigneeReference)
                .HasMaxLength(100);

            this.Property(t => t.ConsigneeAddress1)
                .HasMaxLength(100);

            this.Property(t => t.ConsigneeAddress2)
                .HasMaxLength(100);

            this.Property(t => t.ConsigneeCity)
                .HasMaxLength(100);

            this.Property(t => t.ConsigneeProvince)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ConsigneePostal)
                .HasMaxLength(100);

            this.Property(t => t.ConsigneeCountry)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("ShipmentRequests");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.InvoiceNumber).HasColumnName("InvoiceNumber");
            this.Property(t => t.InvoiceDate).HasColumnName("InvoiceDate");
            this.Property(t => t.RequestDate).HasColumnName("RequestDate");
            this.Property(t => t.DueDate).HasColumnName("DueDate");
            this.Property(t => t.ShipmentDate).HasColumnName("ShipmentDate");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.SpecialInstruction1).HasColumnName("SpecialInstruction1");
            this.Property(t => t.SpecialInstruction1Amount).HasColumnName("SpecialInstruction1Amount");
            this.Property(t => t.SpecialInstruction2).HasColumnName("SpecialInstruction2");
            this.Property(t => t.SpecialInstruction2Amount).HasColumnName("SpecialInstruction2Amount");
            this.Property(t => t.SpecialInstruction3).HasColumnName("SpecialInstruction3");
            this.Property(t => t.SpecialInstruction3Amount).HasColumnName("SpecialInstruction3Amount");
            this.Property(t => t.WeightAs).HasColumnName("WeightAs");
            this.Property(t => t.SkidRate).HasColumnName("SkidRate");
            this.Property(t => t.EstimatedCost).HasColumnName("EstimatedCost");
            this.Property(t => t.ActualCost).HasColumnName("ActualCost");
            this.Property(t => t.SellingPrice).HasColumnName("SellingPrice");
            this.Property(t => t.NumberOfPieces).HasColumnName("NumberOfPieces");
            this.Property(t => t.FreightCharge).HasColumnName("FreightCharge");
            this.Property(t => t.FuelSurcharge).HasColumnName("FuelSurcharge");
            this.Property(t => t.CustomerMarkup).HasColumnName("CustomerMarkup");
            this.Property(t => t.SalesTax).HasColumnName("SalesTax");
            this.Property(t => t.Total).HasColumnName("Total");
            this.Property(t => t.ShipperName).HasColumnName("ShipperName");
            this.Property(t => t.ShipperReference).HasColumnName("ShipperReference");
            this.Property(t => t.ShipperAddress1).HasColumnName("ShipperAddress1");
            this.Property(t => t.ShipperAddress2).HasColumnName("ShipperAddress2");
            this.Property(t => t.ShipperCity).HasColumnName("ShipperCity");
            this.Property(t => t.ShipperProvince).HasColumnName("ShipperProvince");
            this.Property(t => t.ShipperPostal).HasColumnName("ShipperPostal");
            this.Property(t => t.ShipperCountry).HasColumnName("ShipperCountry");
            this.Property(t => t.ConsigneeName).HasColumnName("ConsigneeName");
            this.Property(t => t.ConsigneeReference).HasColumnName("ConsigneeReference");
            this.Property(t => t.ConsigneeAddress1).HasColumnName("ConsigneeAddress1");
            this.Property(t => t.ConsigneeAddress2).HasColumnName("ConsigneeAddress2");
            this.Property(t => t.ConsigneeCity).HasColumnName("ConsigneeCity");
            this.Property(t => t.ConsigneeProvince).HasColumnName("ConsigneeProvince");
            this.Property(t => t.ConsigneePostal).HasColumnName("ConsigneePostal");
            this.Property(t => t.ConsigneeCountry).HasColumnName("ConsigneeCountry");
            this.Property(t => t.CustomerId).HasColumnName("CustomerId");
            this.Property(t => t.ConsigneeId).HasColumnName("ConsigneeId");
            this.Property(t => t.CarrierId).HasColumnName("CarrierId");

            // Relationships
            this.HasRequired(t => t.Carrier)
                .WithMany(t => t.ShipmentRequests)
                .HasForeignKey(d => d.CarrierId);
            this.HasRequired(t => t.Consignee)
                .WithMany(t => t.ShipmentRequests)
                .HasForeignKey(d => d.ConsigneeId);
            this.HasRequired(t => t.Customer)
                .WithMany(t => t.ShipmentRequests)
                .HasForeignKey(d => d.CustomerId);

        }
    }
}
