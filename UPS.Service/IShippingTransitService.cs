using System;
namespace UPS.Service
{
    public interface IShippingTransitService
    {
        Vital.Model.CalculateRequestModel Calculate(Vital.Model.CalculateRequestModel model);
    }
}
