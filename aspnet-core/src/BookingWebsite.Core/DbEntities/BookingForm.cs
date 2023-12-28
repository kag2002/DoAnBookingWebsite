using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.DbEntities
{
    public class BookingForm : FullAuditedEntity, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public string FullName { get; set; }

        public string IdCardNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public DateTime DateCheckin { get; set; }

        public DateTime DateCheckout { get; set; }

        public int BookingOnBehalf { get; set; }

        public string SpecialRequest { get; set; }

        public ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
