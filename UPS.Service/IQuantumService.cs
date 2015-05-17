using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.Service
{
    public interface IQuantumService
    {
        IEnumerable<string> GetOutboundCustomViews();
        IEnumerable<string> GetOutboundSearchFilters();
        Vital.Model.QuantumViewResponse GetQuantumData();
        string GetTextFromXMLFile(string file);
        Vital.Model.QuantumViewModel ProcessData(Vital.Model.QuantumViewResponse Response);
        List<Vital.Model.QuantumViewShipmentDetail> GetSubscriptionEventData(Vital.Model.QuantumViewResponse response, string name);
        List<Vital.Model.QuantumViewSummary> GetSubscriptionSummary(List<Vital.Model.QuantumViewShipmentDetail> data, string name);
    }
}
