using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.DbEntities
{
    public class Employee : FullAuditedEntity, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public string FullName { get; set; }

        public long PhoneNumber { get; set; }

        public string BirthPlace { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public string Address { get; set; }

        public int Gender { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string EmployeeAvatar { get; set; }

    }
}
