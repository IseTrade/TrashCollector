using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Address Address { get; set; }

        public string UserName { get; set; }

        [Display(Name = "Pickup Day")]
        public DayOfWeek PickupDay { get; set; }

        [Display(Name = "Pickup Start Date")]
        public DateTime? PickupStartDate { get; set; }

        [Display(Name = "Pickup End Date")]
        public DateTime? PickupEndDate { get; set; }

        [Display(Name = "Special Pickup")]
        public DateTime? SpecialPickup { get; set; }

        [Display(Name = "Suspend Start Date")]
        public DateTime? SuspendStartDate { get; set; }

        [Display(Name = "Suspend End Date")]
        public DateTime? SuspendEndDate { get; set; }

        [Display(Name = "Money Owed")]
        public double MoneyOwed { get; set; }

        public double Balance { get; set; }
    }
}
