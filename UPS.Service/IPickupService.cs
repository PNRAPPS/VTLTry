using System;

namespace UPS.Service
{
    public interface IPickupService
    {
        Vital.Model.ShipmentModel SchedulePickup(Vital.Model.ShipmentModel shipmentModel);
    }
}
