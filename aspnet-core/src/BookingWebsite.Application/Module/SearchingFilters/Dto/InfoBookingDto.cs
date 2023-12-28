using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.Modules.SearchingFilter.Dto
{
    public class InfoBookingDto
    {
        public int LocationId { get; set; }

        public DateTime DateCheckin { get; set; }

        public DateTime DateCheckout { get; set; }

        public int AdultCount { get; set; }

        public int ChildrenCount { get; set; }

       /* public List<> TreEm { get; set; }*/

        public int RoomCount { get; set; }
    }
}
