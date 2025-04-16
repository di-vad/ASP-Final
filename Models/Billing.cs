using System;
using System.ComponentModel.DataAnnotations;

namespace vehicleManagementSystem.Models
{
    public class Billing
    {
        public int Id { get; set; }

        public int ReservationId { get; set; }

        public Reservation Reservation { get; set; }

        public decimal Subtotal { get; set; }

        public decimal Tax { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime IssuedDate { get; set; } = DateTime.Now;
    }


}
