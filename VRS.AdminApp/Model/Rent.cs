using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRS.AdminApp.VRSServiceReference;

namespace VRS.AdminApp.Model
{
    public class Rent
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int VehicleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public double? Price { get; set; }
        public bool Finished { get; set; }

        public Rent(RentDTO dto)
        {
            Id = dto.Id;
            ClientId = dto.ClientId;
            VehicleId = dto.VehicleId;
            StartDate = dto.StartDate;
            FinishDate = dto.FinishDate;
            Price = dto.Price;
            Finished = dto.Finished;
        }
        
    }
}
