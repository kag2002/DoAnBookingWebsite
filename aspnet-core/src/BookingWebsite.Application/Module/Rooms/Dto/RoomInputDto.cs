using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.Modules.Rooms.Dto
{
    public class RoomInputDto
    {
        public int Id { get; set; }

        public string Describe { get; set; }

        public string RoomAvatarFileName { get; set; }

/*        public int? HotelUnitId { get; set; }*/

        public int? RoomCategoryId { get; set; }

    }
}
