using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vital.Model
{
    public class ShipmentProgress
    {
        public string Location { get; set; }
        public string Date { get; set; }
        public string LocalTime { get; set; }
        public string Activity { get; set; }
    }

    public class ShipmentPackages
    {
        public string TrackingNumber { get; set; }
        public string Reference { get; set; }
        public string Status { get; set; }
        public string ShippedDate { get; set; }
        public string ScheduledDate { get; set; }
        public string Service { get; set; }
        public string Weight { get; set; }
    }

    public class TrackingResultModel
    {
        public string TrackingNumber { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }

    public class TrackingModel
    {
        public TrackingModel()
        {
            this.ShipmentProgress = new List<ShipmentProgress>();
            this.ShipmentPackage = new List<ShipmentPackages>();
        }

        public string ManifestDate { get; set; }
        public string ShipperNumber { get; set; }
        public List<ShipmentPackages> ShipmentPackage { get; set; }
        public List<ShipmentProgress> ShipmentProgress { get; set; }
        public string Status { get; set; }
        public string TrackingNumber { get; set; }
        public string Description { get; set; }

        public string BillingDate { get; set; }

        public string DeliveredTo { get; set; }

        public string Weight { get; set; }

        public string ActivityName { get; set; }

        public string ActivityLocation { get; set; }

        public string ActivityDate { get; set; }

        public string ActivityTime { get; set; }

        public string DeliveryDate { get; set; }

        public string SignedBy { get; set; }

        public int PackageCount { get; set; }

        public string PackageType { get; set; }

        public string LeftAt { get; set; }
    }
}
