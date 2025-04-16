using System;
using System.ComponentModel.DataAnnotations;

namespace vehicleManagementSystem.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        [Required]
        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public ReservationStatus Status { get; set; } = ReservationStatus.Pending;

        public Billing Billing { get; set; }
    }

    public enum ReservationStatus
    {
        Pending,
        Confirmed,
        Cancelled,
        Completed
    }


}
