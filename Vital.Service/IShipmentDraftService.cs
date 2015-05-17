using System;
using Vital.Model;

namespace Vital.Service
{
    public interface IShipmentDraftService
    {
        string SaveShipment(ShipmentModel model, string userName);
        Vital.Model.ShipmentModel DataToModel(Vital.Data.Models.ShipmentDraft data);
        Vital.Data.Models.ShipmentDraft ModelToData(Vital.Model.ShipmentModel model);
        Model.ShipmentModel GetShipmentData(Guid id);
        void FinalizeShipmentDraft(string action, Guid id);
        void UpdateShipmentDraft(Model.ShipmentModel model, Guid id);
        bool HasShipmentDraftData(string username);
        void CancelScheduledPickup(Guid id);
    }
}
