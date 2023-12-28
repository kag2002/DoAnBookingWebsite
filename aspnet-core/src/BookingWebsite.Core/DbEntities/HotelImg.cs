using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.DbEntities
{
    public class HotelImg : FullAuditedEntity, IMayHaveTenant
    {
        public string ImgFileName { get; set; }

        public int RoomId { get; set; }

        public int? TenantId { get; set; }
    }
}
