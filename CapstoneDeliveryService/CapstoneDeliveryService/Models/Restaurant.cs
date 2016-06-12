using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapstoneDeliveryService.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string LocuVenueId { get; set; }
        public string Name { get; set; }
        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public string AddressZip { get; set; }
        public string AddressState { get; set; }

        public string PhoneNumber { get; set; }

        public string Category { get; set; }
        public string Description { get; set; }




    }
}