using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.Modules.Rooms.Dto
{
    public class ClientBookRoomInputDto
    {
/*        public int roomId { get; set; }

        public int roomCategoryId { get; set; }*/

        public int BookingOnBehalf { get; set; }

        public string IdCardNumber { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string SpecialRequest { get; set; }

        /*public double TotalBill { get; set; }*/

    }
}
