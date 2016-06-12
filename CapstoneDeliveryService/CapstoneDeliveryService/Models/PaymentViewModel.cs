using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapstoneDeliveryService.Models
{
    public class PaymentViewModel
    {

        public string CustomerID;
        public int? ItemNumber;
        public decimal Shipping;
        public decimal Tax;
        public decimal Price;
        public string ItemName;
        public decimal Total;
        public decimal Subtotal;
    }
}