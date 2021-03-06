using System;
using System.Collections.Generic;

namespace Vital.Data.Models
{
    public partial class ShipmentDetail : Repository.EntityBase
    {
        public System.Guid Id { get; set; }
        public System.DateTime InvoiceDate { get; set; }
        public int InvoiceNumber { get; set; }
        public string AccountNumber { get; set; }
        public System.DateTime TransactionDate { get; set; }
        public string ShipmentReferenceNumber { get; set; }
        public int PackageQuantity { get; set; }
        public string TrackingNumber { get; set; }
        public int EnteredWeight { get; set; }
        public string EnteredWeightUnitOfMeasure { get; set; }
        public int BilledWeight { get; set; }
        public string BilledWeightUnitOfMeasure { get; set; }
        public string ContainerType { get; set; }
        public int Zone { get; set; }
        public string ChargeClassificationCode { get; set; }
        public string ChargeDescription { get; set; }
        public string InvoiceCurrencyCode { get; set; }
        public decimal FreightCharge { get; set; }
        public decimal Fuel { get; set; }
        public decimal SalesTax { get; set; }
        public decimal Total { get; set; }
        public string SenderName { get; set; }
        public string SenderCompanyName { get; set; }
        public string SenderAddressLine1 { get; set; }
        public string SenderAddressLine2 { get; set; }
        public string SenderCity { get; set; }
        public string SenderState { get; set; }
        public string SenderPostal { get; set; }
        public string SenderCountry { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverCompanyName { get; set; }
        public string ReceiverAddressLine1 { get; set; }
        public string ReceiverAddressLine2 { get; set; }
        public string ReceiverCity { get; set; }
        public string ReceiverState { get; set; }
        public string ReceiverPostal { get; set; }
        public string ReceiverCountry { get; set; }
        public string SoldToCompanyName { get; set; }
        public string SoldToAddressLine1 { get; set; }
        public string SoldToAddressLine2 { get; set; }
        public string SoldToCity { get; set; }
        public string SoldToState { get; set; }
        public string SoldToPostal { get; set; }
        public string SoldToCountry { get; set; }
        public string LeadShipmentNumber { get; set; }
        public string WorldEaseNumber { get; set; }
        public int EnteredHeight { get; set; }
        public int EnteredWidth { get; set; }
        public int EnteredLength { get; set; }
        public bool IsLargePackage { get; set; }
        public bool IsAdditionalHandling { get; set; }
        public int PackageDeclaredValue { get; set; }
        public string ServiceCode { get; set; }
        public bool SendEmailNotificationFlag { get; set; }
        public bool ReceiveConfirmationAndDeliveryFlag { get; set; }
        public bool DeliveryOnSundayFlag { get; set; }
        public bool CODFlag { get; set; }
        public string ReferenceNumber1 { get; set; }
        public string ReferenceNumber2 { get; set; }
        public string ReferenceNumber3 { get; set; }
        public string BillShippingChargesTo { get; set; }
    }
}
