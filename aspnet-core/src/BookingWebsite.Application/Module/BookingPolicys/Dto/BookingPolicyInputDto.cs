using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.Modules.BookingPolicys.Dto
{
    public class BookingPolicyInputDto
    {
        public string CheckInfor { get; set; }

        public string Breakfast { get; set; }

        public string Checkin { get; set; }

        public string Checkout { get; set; }

        public string RoomPolicy { get; set; }

        public string ChildrenPolicy { get; set; }

        public string SubBedPolicy { get; set; }

        public string PetPolicy { get; set; }

        public string PaymentMethod { get; set; }

        public int? HotelUnitId { get; set; }
    }
}
