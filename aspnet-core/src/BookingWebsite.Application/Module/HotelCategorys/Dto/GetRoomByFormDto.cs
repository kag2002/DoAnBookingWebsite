using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.Module.HotelCategorys.Dto
{
    public class GetRoomByFormDto
    {
        public int? HotelCategory { get; set; }

        public string HotelCategoryName { get; set; }

        public int RoomId { get; set; }

        public string UnitName { get; set; }

        public List<string> RoomCategory { get; set; }

        public string Address { get; set; }

        public string HotelAvatar { get; set; }

        public string RoomPolicy { get; set; }

        public string ChildrenPolicy { get; set; }

        public string PetPolicy { get; set; }

        public List<string> Service { get; set; }

        public List<string> HoteImg { get; set; }

    }
}
