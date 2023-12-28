using BookingWebsite.Modules.SearchingFilter.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.Modules.Phongs.Dto
{
    public class GetRoomInforToBookOutputDto
    {
        public int hotelUnitId { get; set; }

        public string unitName { get; set; }

        public int roomId { get; set; }

        public string tenFIleAnh { get;set; }
        public int roomCategoryId { get; set; }

        public string RoomCategoryName { get; set; }

        public int roomCapacity { get; set; }

        public string roomDescibe { get; set; }

        public string roomCategoryService { get; set; }

        public double pricePerNight { get; set; }

        public double serviceExtendPrice { get; set; }

        public double discount { get; set; }

        public double specialDiscount { get; set; }

        public bool freeCancelBook { get; set; }

        public double totalBill { get; set; }
    }
}
