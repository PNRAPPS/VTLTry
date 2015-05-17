using System;
namespace UPS.Service
{
    public interface IShippingService
    {
        Vital.Model.ShipmentModel ProcessShipment(Vital.Model.ShipmentModel model);
        void Void(string shipmentIdentificationNumber, string username, string password, out string message);
    }
}
