using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.Modules.SearchingFilter.Dto
{
    public class SearchingFilterRoomInputDto
    {
        /*        public int pageIndex { get; set; }

                public int pageSize { get; set; }


        */

        public List<RoomSearchingFilterDto>? lst { get; set; }

        public bool FreeCancel { get; set; }


        public double LowestRoomPrice { get; set; }
        
        public double HighestRoomPrice { get; set; }


        public List<double> StarVote { get; set; }

        public List<int> HotelCategoryId { get; set; }


        public int SortCondition { get; set; }

    }
}
