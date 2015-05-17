using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.Service
{
    public interface ITimeInTransitService
    {
        Vital.Model.TNTResponse GetTimeInTransit(Vital.Model.ShipmentModel data);
    }
}
