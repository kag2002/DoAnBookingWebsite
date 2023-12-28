using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.Modules.HotelUnits.Dto
{
    public class HotelUnitInputDto
    {
        public int Id { get; set; }

        public string UnitName { get; set; }

        public string LocationDetail { get; set; }

        public string HotelAvatar { get; set; }

        public string RoomPolicy { get; set; }

        public string ChildrenPolicy { get; set; }

        public string PetPolicy { get; set; }

        public string Intro { get; set; }

        public int? LocationId { get; set; }
    }
}
