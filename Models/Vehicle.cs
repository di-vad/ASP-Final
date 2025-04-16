using System;
using System.ComponentModel.DataAnnotations;

namespace vehicleManagementSystem.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string LicensePlate { get; set; }

        public string VehicleType { get; set; }

        public decimal DailyRate { get; set; }

        public bool IsAvailable { get; set; } = true;

        public ICollection<Reservation> Reservations { get; set; }
    }

}
