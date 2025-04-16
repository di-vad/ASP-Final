using System;
using System.ComponentModel.DataAnnotations;

namespace vehicleManagementSystem.Models
{
    public class ReportCriteria
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string VehicleType { get; set; }

        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }
    }


}
