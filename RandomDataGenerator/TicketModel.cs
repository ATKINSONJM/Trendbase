using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDataGenerator
{
    public class TicketModel
    {
        public int CustomerId { get; set; }
        public int RouteId { get; set; }
        public string DateOfPurchase { get; set; }
        public int RailcardUsed { get; set; }
        public decimal Price { get; set; }
        public string DateOfTravel { get; set; }
    }
}
