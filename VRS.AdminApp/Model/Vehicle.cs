using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRS.AdminApp.VRSServiceReference;

namespace VRS.AdminApp.Model
{
    public class Vehicle
    {
        public Vehicle()
        {
            
        }

        public Vehicle(VehicleDTO x)
        {
            this.Id = x.Id;
            Description = x.Description;
            VehicleModelId = x.VehicleModelId;
            Plate = x.Plate;
            Mileage = x.Mileage;
            InUse = x.InUse;
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public int VehicleModelId { get; set; }
        
        public string Plate { get; set; }

        public int? Mileage { get; set; }
        
        public bool InUse { get; set; }
    }
}
