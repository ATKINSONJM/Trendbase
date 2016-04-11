using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trendbase.Web.Models
{
    public class TicketModel
    {
        public int Age { get; set; }
        public int RouteId { get; set; }
        public int DateOfPurchase { get; set; }
        public int RailcardUsed { get; set; }
        public decimal Price { get; set; }
        public string DateOfTravel { get; set; }
    }
}