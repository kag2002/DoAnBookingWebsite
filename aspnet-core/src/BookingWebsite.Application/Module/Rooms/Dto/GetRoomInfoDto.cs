using Abp.Application.Services.Dto;
using BookingWebsite.Modules.BookingPolicys.Dto;
using BookingWebsite.Modules.HotelServices.Dto;
using BookingWebsite.Modules.Rooms.Dto;
using System.Collections.Generic;

namespace BookingWebsite.Modules.Phongs.Dto
{
    public class GetRoomInfoDto
    {
        public int LocationId { get; set; }

        public string LocationName { get; set; }

        public string LocationInfor { get; set; }


        public int HotelUnitId { get; set; }

        public string UnitName { get; set; }

        public string LocationDetail { get; set; }


        public int HotelCategoryId { get; set; }

        public string HotelCategory { get; set; }


        public int RoomId { get; set; }

        public string Describe { get; set; }

        public string RoomAvatarFileName { get; set; }


        public int BookingCount { get; set; }

        public double AverageVotePoint { get; set; }

        public double AverageVoteStar { get; set; }


        public List<RoomCategorySearchingDto> ListRoomCategory { get; set; }

        public List<BookingPolicyDto> BookingPolicy { get; set; }

        public List<HotelServiceDto> HotelService { get; set; }

        public List<string> HinhAnh { get; set; }


    }
}
