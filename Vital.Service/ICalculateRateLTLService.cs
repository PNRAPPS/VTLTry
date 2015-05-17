using System;
using Vital.Model;
namespace Vital.Service
{
    public interface ICalculateRateLTLService
    {
        decimal getRateResultLTL(int consideredweight, string originCity, string originState, string originCountry, string destinationCity, string destinationState, string destinationCountry);
    }
}
