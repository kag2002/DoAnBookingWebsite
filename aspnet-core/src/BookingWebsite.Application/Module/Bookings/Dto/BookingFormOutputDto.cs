using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.Modules.Bookings.Dto
{
    public class BookingFormOutputDto
    {
        public int Id { get; set; }

        public DateTime DateCheckin { get; set; }

        public DateTime DateCheckout { get; set; }
    }
}
