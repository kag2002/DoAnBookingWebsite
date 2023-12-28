using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.Modules.SearchingFilter.Dto
{
    public class SearchingFilterRoomOutputDto
    {
        public int Id { get; set; }

        public string UnitName { get; set; }

        public string HotelCategory { get; set; }

        public string RoomCategory { get; set; }

        public string LocationDetail { get; set; }

        public float StarVote { get; set; }

        public float PointVote { get; set; }

        public int VoteCount { get; set; }

        public float PricePerNight { get; set; }

        public List<string> PolicyAboutBooking { get; set; }
    }
}
