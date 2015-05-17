using System;
using System.Collections.Generic;

namespace Vital.Data.Models
{
    public partial class ShipmentRequest
    {
        public string Id { get; set; }
        public int InvoiceNumber { get; set; }
        public System.DateTime InvoiceDate { get; set; }
        public System.DateTime RequestDate { get; set; }
        public System.DateTime DueDate { get; set; }
        public System.DateTime ShipmentDate { get; set; }
        public string Status { get; set; }
        public string SpecialInstruction1 { get; set; }
        public decimal SpecialInstruction1Amount { get; set; }
        public string SpecialInstruction2 { get; set; }
        public decimal SpecialInstruction2Amount { get; set; }
        public string SpecialInstruction3 { get; set; }
        public decimal SpecialInstruction3Amount { get; set; }
        public decimal WeightAs { get; set; }
        public decimal SkidRate { get; set; }
        public decimal EstimatedCost { get; set; }
        public decimal ActualCost { get; set; }
        public decimal SellingPrice { get; set; }
        public int NumberOfPieces { get; set; }
        public decimal FreightCharge { get; set; }
        public decimal FuelSurcharge { get; set; }
        public decimal CustomerMarkup { get; set; }
        public decimal SalesTax { get; set; }
        public decimal Total { get; set; }
        public string ShipperName { get; set; }
        public string ShipperReference { get; set; }
        public string ShipperAddress1 { get; set; }
        public string ShipperAddress2 { get; set; }
        public string ShipperCity { get; set; }
        public string ShipperProvince { get; set; }
        public string ShipperPostal { get; set; }
        public string ShipperCountry { get; set; }
        public string ConsigneeName { get; set; }
        public string ConsigneeReference { get; set; }
        public string ConsigneeAddress1 { get; set; }
        public string ConsigneeAddress2 { get; set; }
        public string ConsigneeCity { get; set; }
        public string ConsigneeProvince { get; set; }
        public string ConsigneePostal { get; set; }
        public string ConsigneeCountry { get; set; }
        public System.Guid CustomerId { get; set; }
        public System.Guid ConsigneeId { get; set; }
        public System.Guid CarrierId { get; set; }
        public virtual Carrier Carrier { get; set; }
        public virtual Consignee Consignee { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
