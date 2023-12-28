using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.Modules.Rooms.Dto
{

    public class RoomCategorySearchingDto
    {
        public int RoomCatergoryId { get; set; }

        public string RoomCategory { get; set; }

        public int Capacity { get; set; }

        public int TotalRoomCount { get; set; }

        public int EmptyRoomCount { get; set; }

        public bool FreeCancelBook { get; set; }

        public double PricePerNight { get; set; }

        public double Discount { get; set; }

        public double SpecialDiscount { get; set; }

        public double ServiceExtendPrice { get; set; }

        public string RoomAvatar { get; set; }

        public List<ServiceSearchingDto> Service { get; set; }
    }
}
