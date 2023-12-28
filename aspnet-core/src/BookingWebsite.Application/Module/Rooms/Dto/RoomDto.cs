using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.Modules.Rooms.Dto
{
    public class RoomDto
    {
        public string Describe { get; set; }

        public string AvatarFileName { get; set; }

        public int? HotelUnitId { get; set; }

        public int? RoomCategoryId { get; set; }

/*        public double PointVoteTb { get; set; }

        public double AverageVoteStar { get; set; }*/
    }
}
