using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.DbEntities
{
    public class HotelCategory : FullAuditedEntity, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public string HotelCategoryName { get; set; }

        public string HotelAvatar { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
