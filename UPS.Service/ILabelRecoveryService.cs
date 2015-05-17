using System;

namespace UPS.Service
{
    public interface ILabelRecoveryService
    {
        Vital.Model.ShipmentModel CreateProcessLabel(Vital.Model.ShipmentModel model);
        string GetImageFromStream(byte[] imageBytes);
    }
}
