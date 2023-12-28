using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.DbEntities
{
    public class RoomService : FullAuditedEntity, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public string ServiceName { get; set; }

        public string Describe { get; set; }

        public int RoomCategoryId { get; set; }
    }
}
