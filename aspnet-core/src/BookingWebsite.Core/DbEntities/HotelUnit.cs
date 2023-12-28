using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.DbEntities
{
    public class HotelUnit : FullAuditedEntity, IMayHaveTenant
    {
        public string UnitName { get; set; }

        public string LocationDetail { get; set; }

        public string HotelAvatar { get; set; }

        public string Intro { get; set; }

        public int? LocationId { get; set; }

        public ICollection<Room> Rooms { get; set; }

        public ICollection<RoomCategory> RoomCategorys { get; set; }

        public ICollection<BookingPolicy> BookingPolicys { get; set; }

        public ICollection<HotelService> HotelServices { get; set; }

        public int? TenantId { get; set; }
    }
}
