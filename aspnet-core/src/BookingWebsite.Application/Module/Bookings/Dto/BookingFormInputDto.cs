using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.Modules.Bookings.Dto
{
    public class BookingFormInputDto
    {
        public DateTime DateCheckin { get; set; }

        public DateTime DateCheckout { get; set; }

        public int CustomerId { get; set; }

        public int EmployeeId { get; set; }

    }
}
