using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.Modules.RoomCategorys.Dto
{
    public class RoomCategoryInputDto
    {
        public string RoomCategoryName { get; set; }

        public int Capacity { get; set; }

        public string Describe { get; set; }

        public string RoomCategoryService { get; set; }

        public float PricePerNight { get; set; }

        public float ServiceExtendPrice { get; set; }

        public float Discount { get; set; }

    }
}
