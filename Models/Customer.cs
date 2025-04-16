using System;
using System.ComponentModel.DataAnnotations;

namespace vehicleManagementSystem.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }


}
