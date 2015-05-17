using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vital.Model
{
    public class SchedulePickupModel
    {

        public string collectionDate { get; set; }
        public string latestPickupTimeHour { get; set; }
        public string latestPickupTimeMinute { get; set; }
        public string earliestPickupTimeHour { get; set; }
        public string earliestPickupTimeMinute { get; set; }

        public string contactName { get; set; }
        public string telephone { get; set; }
        public string extension { get; set; }
        public string room { get; set; }
        public string floor { get; set; }

        public string pickupLocation { get; set; }

    }
}
