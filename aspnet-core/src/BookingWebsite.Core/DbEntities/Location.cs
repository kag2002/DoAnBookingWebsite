using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.DbEntities
{
    public class Location : FullAuditedEntity, IMayHaveTenant
    {
        public string LocationName { get; set; }

        public string LocationInfor { get; set; }

        public string ImgName { get; set; }

        public ICollection<HotelUnit> HotelUnits { get; set; }

        public int? TenantId { get; set; }
    }
    
}
