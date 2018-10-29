using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrashCollector.Models
{
    public class Pickup
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Pickup Date")]
        public DateTime? PickupDate { get; set; }

        [Display(Name = "Day of Week Pickup")]
        public DayOfWeek DayOfWeekPickup { get; set; }

        [Display(Name = "Pickup Status")]
        public bool PickupStatus { get; set; }

        [Display(Name = "Pickup Charge")]
        public double PickupCharge { get; set; }

        [Display(Name = "Zip Code")]
        public string Zipcode { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
