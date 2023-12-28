using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.DbEntities
{
    public class CustomerLevel : FullAuditedEntity, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public string Level { get; set; }

        public double DiscountRatio { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}
