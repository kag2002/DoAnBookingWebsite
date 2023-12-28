using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.Modules.RoomCategorys.Dto
{
    public class RoomCategoryOutputDto
    {
        public int Id { get; set; }

        public string RoomCategoryName { get; set; }

        public int Capacity { get; set; }

        public string Describe { get; set; }

        public string RoomCategoryService { get; set; }

        public double PricePerNight { get; set; }

        public double ServiceExtendPrice { get; set; }

        public double Discount { get; set; }

        public List<string> RoomCategoryServiceName { get; set; }

    }
}
