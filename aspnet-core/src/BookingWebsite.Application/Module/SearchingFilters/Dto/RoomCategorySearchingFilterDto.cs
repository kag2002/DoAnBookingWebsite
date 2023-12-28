using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.Modules.SearchingFilter.Dto
{
    public class RoomCategorySearchingFilterDto
    {
        public int RoomCategoryId { get; set; }

        public bool FreeCancel { get; set; }

        public double PricePerNight { get; set; }

        public double Discount { get; set; }

        public string RoomAvatar { get; set; }

    }
}
