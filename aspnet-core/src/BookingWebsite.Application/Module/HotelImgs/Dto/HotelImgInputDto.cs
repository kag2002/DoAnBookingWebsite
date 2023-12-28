using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.Modules.HotelImgs.Dto
{
    public class HotelImgInputDto
    {
        public int ID { get; set; }

        public string ImgFileName { get; set; }

        public int RoomId { get; set; }
    }
}
