using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.Service
{
    public interface IRateService
    {
        UPS.Service.RateWebService.RateResponse GetRate(Vital.Model.ShipmentModel model);
        UPS.Service.RateWebService.RateResponse GetRate(Vital.Model.ShipmentModel model, string ServiceCode);
    }
}
