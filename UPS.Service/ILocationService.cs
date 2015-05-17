using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vital.Model;

namespace UPS.Service
{
    public interface ILocationService
    {
        LocationResponseModel SearchLocation(LocationsModel model);
    }
}
