using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrashCollector.Models
{
    public class Address
    {
        [Key]
        //public int CustomerId { get; set; }
        //public int CustomerAddressId { get; set; }
        public int Id { get; set; }
        [Display(Name = "Number and Street")]
        public string NumberAndStreet { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public string Zipcode { get; set; }

    }
}
