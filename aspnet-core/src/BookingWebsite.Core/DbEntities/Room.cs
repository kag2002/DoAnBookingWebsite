using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.DbEntities
{
    public class Room : FullAuditedEntity, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public string? Describe { get; set; }

        public string RoomAvatarFileName { get; set; }

        public int BookingCount { get; set; }

        public double AverageVotePoint { get; set; }

        public double AverageVoteStar { get; set; }

        public int? HotelUnitId { get; set; }

        public int? HotelCategoryId { get; set; }

        public ICollection<HotelImg> HotelImgs { get; set; }

        public ICollection<BookingDetail> BookingDetails { get; set; }

    }
}
