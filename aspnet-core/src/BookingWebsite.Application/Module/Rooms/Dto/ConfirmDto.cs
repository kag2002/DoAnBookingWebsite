using BookingWebsite.Modules.SearchingFilter.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.Modules.Rooms.Dto
{
    public class ConfirmDto
    {
        public int BookingOnBehalf { get; set; }

        public string IdCardNumber { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string SpecialRequest { get; set; }

        public DateTime DateCheckin { get; set; }

        public DateTime DateCheckout { get; set; }

        public int AdultCount { get; set; }

        public int ChildrenCount { get; set; }

        public int RoomCount { get; set; }

        public double TotalBill { get; set; }

        public int RoomId { get; set; }

    }
}
