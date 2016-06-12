using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapstoneDeliveryService.Models
{
    public class MenuItem
    {
        public int Id { get; set; }

        public int RestaurantId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }


    }
}