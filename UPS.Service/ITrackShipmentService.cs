using System;
using System.Collections.Generic;
using Vital.Model;
namespace UPS.Service
{
    public interface ITrackShipmentService
    {
        System.Collections.Generic.List<Vital.Model.TrackingResultModel> Search(string trackingNumbers);
        Vital.Model.TrackingResultModel SearchInquiry(string trackingNumbers);
        List<TrackingModel> GetInformation(string trackingNumbers);
    }
}
