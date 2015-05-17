using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Repository;
using Repository.Providers.EntityFramework;
using Vital.Service;
using Vital.Data.Models;

namespace Vital.Web.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();

            container.RegisterType<IUnitOfWork, UnitOfWork>(new PerRequestLifetimeManager());
            container.RegisterType<IDataContext, VitalContext>(new PerRequestLifetimeManager());
            container.RegisterType<UPS.Service.ITrackShipmentService, UPS.Service.TrackShipmentService>(new PerRequestLifetimeManager());
            container.RegisterType<UPS.Service.IShippingTransitService, UPS.Service.ShippingTransitService>(new PerRequestLifetimeManager());
            container.RegisterType<UPS.Service.IShippingService, UPS.Service.ShippingService>(new PerRequestLifetimeManager());
            container.RegisterType<UPS.Service.IPickupService, UPS.Service.ShipmentPickupService>(new PerRequestLifetimeManager());
            container.RegisterType<UPS.Service.ILabelRecoveryService, UPS.Service.LabelService>(new PerRequestLifetimeManager());
            container.RegisterType<UPS.Service.ILocationService, UPS.Service.LocationService>(new PerRequestLifetimeManager());
            container.RegisterType<UPS.Service.IQuantumService, UPS.Service.QuantumService>(new PerRequestLifetimeManager());
            container.RegisterType<UPS.Service.IRateService, UPS.Service.RateService>(new PerRequestLifetimeManager());
            container.RegisterType<UPS.Service.ITimeInTransitService, UPS.Service.TNTService>(new PerRequestLifetimeManager());

            #region Service
            container.RegisterType<ICustomerService, CustomerService>(new PerRequestLifetimeManager());
            container.RegisterType<ICustomerAccountService, CustomerAccountService>(new PerRequestLifetimeManager());
            container.RegisterType<ITermService, TermService>(new PerRequestLifetimeManager());
            container.RegisterType<IConsigneeService, ConsigneeService>(new PerRequestLifetimeManager());
            container.RegisterType<IAddressBookInfoService, AddressBookInfoService>(new PerRequestLifetimeManager());
            container.RegisterType<ICustomerShipmentService, CustomerShipmentService>(new PerRequestLifetimeManager());
            container.RegisterType<ILookupService, LookupService>(new PerRequestLifetimeManager());
            container.RegisterType<IAdminUserService, AdminUserService>(new PerRequestLifetimeManager());
            container.RegisterType<INewsService, NewsService>(new PerRequestLifetimeManager());
            container.RegisterType<ICalculateRateLTLService, CalculateRateLTLService>(new PerRequestLifetimeManager());
            container.RegisterType<IInvoiceService, InvoiceService>(new PerRequestLifetimeManager());
            container.RegisterType<IQVService, QVService>(new PerRequestLifetimeManager());
            container.RegisterType<IShipmentDraftService, ShipmentDraftService>(new PerRequestLifetimeManager());
            #endregion

            #region Repository
            container.RegisterType<IRepository<Customer>, Repository<Customer>>(new PerRequestLifetimeManager());
            container.RegisterType<IRepository<CustomerAccount>, Repository<CustomerAccount>>(new PerRequestLifetimeManager());
            container.RegisterType<IRepository<Term>, Repository<Term>>(new PerRequestLifetimeManager());
            container.RegisterType<IRepository<Consignee>, Repository<Consignee>>(new PerRequestLifetimeManager());
            container.RegisterType<IRepository<AddressBookInfo>, Repository<AddressBookInfo>>(new PerRequestLifetimeManager());
            container.RegisterType<IRepository<ConsigneeCustomer>, Repository<ConsigneeCustomer>>(new PerRequestLifetimeManager());
            container.RegisterType<IRepository<CustomerShipment>, Repository<CustomerShipment>>(new PerRequestLifetimeManager());
            container.RegisterType<IRepository<LookupTable>, Repository<LookupTable>>(new PerRequestLifetimeManager());
            container.RegisterType<IRepository<AdminUser>, Repository<AdminUser>>(new PerRequestLifetimeManager());
            container.RegisterType<IRepository<News>, Repository<News>>(new PerRequestLifetimeManager());
            container.RegisterType<IRepository<SkidRate>, Repository<SkidRate>>(new PerRequestLifetimeManager());
            container.RegisterType<IRepository<SkidWeight>, Repository<SkidWeight>>(new PerRequestLifetimeManager());
            container.RegisterType<IRepository<ShipmentDetail>, Repository<ShipmentDetail>>(new PerRequestLifetimeManager());
            container.RegisterType<IRepository<Invoice>, Repository<Invoice>>(new PerRequestLifetimeManager());
            container.RegisterType<IRepository<QVShipmentDetail>, Repository<QVShipmentDetail>>(new PerRequestLifetimeManager());
            container.RegisterType<IRepository<QVSubscriptionFile>, Repository<QVSubscriptionFile>>(new PerRequestLifetimeManager());
            container.RegisterType<IRepository<QVSyncSummary>, Repository<QVSyncSummary>>(new PerRequestLifetimeManager());
            container.RegisterType<IRepository<ShipmentDraft>, Repository<ShipmentDraft>>(new PerRequestLifetimeManager());
            #endregion
        }
    }
}
