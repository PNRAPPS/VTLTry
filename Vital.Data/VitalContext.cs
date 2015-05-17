using Repository.Providers.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Vital.Data.Models.Mapping;

namespace Vital.Data.Models
{
    public partial class VitalContext : DataContext
    {
        static VitalContext()
        {
            Database.SetInitializer<VitalContext>(null);
        }

        public VitalContext()
            : base("Name=VitalConnection")
        {
        }

        public DbSet<provision_marker_dss> provision_marker_dss { get; set; }
        public DbSet<schema_info_dss> schema_info_dss { get; set; }
        public DbSet<scope_config_dss> scope_config_dss { get; set; }
        public DbSet<scope_info_dss> scope_info_dss { get; set; }
        public DbSet<AccessorialChargeAmount> AccessorialChargeAmounts { get; set; }
        public DbSet<AccessorialCharge> AccessorialCharges { get; set; }
        public DbSet<AddressBookInfo> AddressBookInfoes { get; set; }

        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<BillingSummary> BillingSummaries { get; set; }
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<ConsigneeCustomer> ConsigneeCustomers { get; set; }
        public DbSet<Consignee> Consignees { get; set; }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<CustomerMarkup> CustomerMarkups { get; set; }
        public DbSet<CustomerShipment> CustomerShipments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerSpInstructionAmount> CustomerSpInstructionAmounts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<News> Newss { get; set; }
        public DbSet<PostalCode> PostalCodes { get; set; }
        public DbSet<PostalCodeZone> PostalCodeZones { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ShipmentDetail> ShipmentDetails { get; set; }
        public DbSet<ShipmentRequest> ShipmentRequests { get; set; }
        public DbSet<ShippingType> ShippingTypes { get; set; }
        public DbSet<SkidRate> SkidRates { get; set; }
        public DbSet<Skid> Skids { get; set; }
        public DbSet<SkidWeight> SkidWeights { get; set; }
        public DbSet<SpecialInstructionAmount> SpecialInstructionAmounts { get; set; }
        public DbSet<SpecialInstruction> SpecialInstructions { get; set; }
        public DbSet<TableTest> TableTests { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Weight> Weights { get; set; }
        public DbSet<ZoneDiscountPercentage> ZoneDiscountPercentages { get; set; }
        public DbSet<ZoneRate> ZoneRates { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<LookupTable> LookupTable { get; set; }
        public DbSet<QVShipmentDetail> QVShipmentDetail { get; set; }
        public DbSet<QVSubscriptionFile> QVSubscriptionFile { get; set; }
        public DbSet<QVSyncSummary> QVSyncSummary { get; set; }
        public DbSet<ShipmentDraft> ShipmentDraft { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new provision_marker_dssMap());
            modelBuilder.Configurations.Add(new schema_info_dssMap());
            modelBuilder.Configurations.Add(new scope_config_dssMap());
            modelBuilder.Configurations.Add(new scope_info_dssMap());
            modelBuilder.Configurations.Add(new AccessorialChargeAmountMap());
            modelBuilder.Configurations.Add(new AccessorialChargeMap());
            modelBuilder.Configurations.Add(new AddressBookInfoMap());
            modelBuilder.Configurations.Add(new AdminUserMap());
            modelBuilder.Configurations.Add(new BillingSummaryMap());
            modelBuilder.Configurations.Add(new CarrierMap());
            modelBuilder.Configurations.Add(new ConsigneeCustomerMap());
            modelBuilder.Configurations.Add(new ConsigneeMap());
            modelBuilder.Configurations.Add(new CustomerAccountMap());
            modelBuilder.Configurations.Add(new CustomerMarkupMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new CustomerShipmentMap());
            modelBuilder.Configurations.Add(new CustomerSpInstructionAmountMap());
            modelBuilder.Configurations.Add(new InvoiceMap());
            modelBuilder.Configurations.Add(new NewsMap());
            modelBuilder.Configurations.Add(new PostalCodeMap());
            modelBuilder.Configurations.Add(new PostalCodeZoneMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new ShipmentDetailMap());
            modelBuilder.Configurations.Add(new ShipmentRequestMap());
            modelBuilder.Configurations.Add(new ShippingTypeMap());
            modelBuilder.Configurations.Add(new SkidRateMap());
            modelBuilder.Configurations.Add(new SkidMap());
            modelBuilder.Configurations.Add(new SkidWeightMap());
            modelBuilder.Configurations.Add(new SpecialInstructionAmountMap());
            modelBuilder.Configurations.Add(new SpecialInstructionMap());
            modelBuilder.Configurations.Add(new TableTestMap());
            modelBuilder.Configurations.Add(new TaxMap());
            modelBuilder.Configurations.Add(new TermMap());
            modelBuilder.Configurations.Add(new UserAccountMap());
            modelBuilder.Configurations.Add(new WeightMap());
            modelBuilder.Configurations.Add(new ZoneDiscountPercentageMap());
            modelBuilder.Configurations.Add(new ZoneRateMap());
            modelBuilder.Configurations.Add(new ZoneMap());
            modelBuilder.Configurations.Add(new LookupTableMap());
            modelBuilder.Configurations.Add(new ShipmentDraftMap());
            modelBuilder.Configurations.Add(new QVShipmentDetailMap());
            modelBuilder.Configurations.Add(new QVSubscriptionFileMap());
            modelBuilder.Configurations.Add(new QVSyncSummaryMap());
        }
    }
}
