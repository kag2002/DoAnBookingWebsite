using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.Modules.Bookings.Dto
{
    public class BookingFormDto
    {
        public int Id { get; set; }

        public DateTime DateCheckin { get; set; }

        public DateTime DateCheckout { get; set; }

        public string Customer { get; set; }

        public string Employee { get; set; }
    }
}
