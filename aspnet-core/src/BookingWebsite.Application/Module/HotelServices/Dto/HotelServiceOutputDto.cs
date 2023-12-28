using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.Modules.HotelServices.Dto
{
    public class HotelServiceOutputDto
    {
        public int Id { get; set; }

        public string ServiceName { get; set; }

        public string Detail { get; set; }

        public int? HotelUnitId { get; set; }
    }
}
