using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.Modules.SearchingFilter.Dto
{
    public class RoomSearchingFilterDto
    {
        public int HotelCategoryId { get; set; }

        public string HotelCategory { get; set; }

        public int? HotelUnitId { get; set; }

        public string? UnitName { get; set; }

        public string? LocationDetail { get; set; }

        public int RoomId { get; set; }

        public string RoomAvatarFileName { get; set; }

        public int BookingCount { get; set; }

        public double AverageVotePoint { get; set; }

        public double AverageVoteStar { get; set; }

        public double LowestRoomPrice { get; set; }

        public List<RoomCategorySearchingFilterDto>? ListRoomCategory { get; set; }

    }
}
